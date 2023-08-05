#include "pch.h"
//#include "BoxRenderer.h"
#if __has_include("BoxRenderer.g.cpp")
#include "BoxRenderer.g.cpp"
#endif

using namespace Concurrency;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::SwapChainComponent::implementation
{
    /*Microsoft::UI::Xaml::DependencyProperty BoxRenderer::m_boxSizeProperty =
        Microsoft::UI::Xaml::DependencyProperty::Register(
            L"BoxSize",
            winrt::xaml_typename<int32_t>(),
            winrt::xaml_typename<SwapChainComponent::BoxRenderer>(),
            Microsoft::UI::Xaml::PropertyMetadata{ winrt::box_value(100), Microsoft::UI::Xaml::PropertyChangedCallback{ &BoxRenderer::OnBoxSizeChanged } }
    );*/
    BoxRenderer::BoxRenderer()
    {
        DefaultStyleKey(winrt::box_value(L"SwapChainComponent.BoxRenderer"));
    }

    winrt::com_ptr<::ID3D11Device> d3dDevice;
    winrt::com_ptr<::IDXGIAdapter> dxgiAdapter;
    bool m_hasLoaded = false;

    /// <summary>
    /// a demo to draw something on SwapChainPanel
    /// code comes from: https://learn.microsoft.com/ja-jp/windows/uwp/gaming/directx-and-xaml-interop
    /// but could not point swapChainPanel at Theme\Generic.xaml
    /// </summary>
    void BoxRenderer::InitializeD3D()
    {
        uint32_t creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

        D3D_FEATURE_LEVEL featureLevels[] =
        {
            D3D_FEATURE_LEVEL_11_1,
            D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL_10_0,
            D3D_FEATURE_LEVEL_9_3,
            D3D_FEATURE_LEVEL_9_2,
            D3D_FEATURE_LEVEL_9_1
        };

        // Create the Direct3D device.
        //winrt::com_ptr<::ID3D11Device> d3dDevice;
        D3D_FEATURE_LEVEL supportedFeatureLevel;
        winrt::check_hresult(::D3D11CreateDevice(
            nullptr,
            D3D_DRIVER_TYPE_HARDWARE,
            0,
            creationFlags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            d3dDevice.put(),
            &supportedFeatureLevel,
            nullptr)
        );
        // Get the Direct3D device.
        winrt::com_ptr<::IDXGIDevice> dxgiDevice{ d3dDevice.as<::IDXGIDevice>() };
        // Create the Direct2D device and a corresponding context.
        winrt::com_ptr<::ID2D1Device> d2dDevice;
        ::D2D1CreateDevice(dxgiDevice.get(), nullptr, d2dDevice.put());

        winrt::com_ptr<::ID2D1DeviceContext> d2dDeviceContext;
        winrt::check_hresult(
            d2dDevice->CreateDeviceContext(
                D2D1_DEVICE_CONTEXT_OPTIONS_NONE,
                d2dDeviceContext.put()
            )
        );

        // make logical swap chain
        // MainPage.cpp | paste this at the end of MainPage::ClickHandler
        // Get the DXGI adapter.
        dxgiDevice->GetAdapter(dxgiAdapter.put());

        // Get the DXGI factory.
        winrt::com_ptr< ::IDXGIFactory2 > dxgiFactory;
        dxgiFactory.capture(dxgiAdapter, &IDXGIAdapter::GetParent);

        DXGI_SWAP_CHAIN_DESC1 swapChainDesc{ 0 };
        swapChainDesc.Width = 500;
        swapChainDesc.Height = 500;
        swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM; // This is the most common swapchain format.
        swapChainDesc.Stereo = false;
        swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
        swapChainDesc.SampleDesc.Quality = 0;
        swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        swapChainDesc.BufferCount = 2;
        swapChainDesc.Scaling = DXGI_SCALING_STRETCH;
        swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // We recommend using this swap effect for all applications.
        swapChainDesc.Flags = 0;

        // Create a swap chain by calling IDXGIFactory2::CreateSwapChainForComposition.
        winrt::com_ptr< ::IDXGISwapChain1 > swapChain;
        dxgiFactory->CreateSwapChainForComposition(
            d3dDevice.get(),
            &swapChainDesc,
            nullptr,
            swapChain.put());

        // Get native interface for SwapChainPanel
        // 1)
        ISwapChainPanelNative* panelNative;
        winrt::get_unknown(this->swapChainPanel())->QueryInterface(__uuidof(ISwapChainPanelNative), (void**)&panelNative);
        // 2)
        //auto panelNative{ swapChainPanel().as<ISwapChainPanelNative>()};
        // 3)
        auto panelNative{ swapChainPanel.as<ISwapChainPanelNative>() };

        winrt::check_hresult(
            panelNative->SetSwapChain(swapChain.get())
        );

        // Create a Direct2D target bitmap associated with the
        // swap chain back buffer, and set it as the current target.
        D2D1_BITMAP_PROPERTIES1 bitmapProperties =
            D2D1::BitmapProperties1(
                D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS_CANNOT_DRAW,
                D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
                96.f,
                96.f
            );

        winrt::com_ptr<::IDXGISurface> dxgiBackBuffer;
        swapChain->GetBuffer(0, __uuidof(dxgiBackBuffer), dxgiBackBuffer.put_void());

        winrt::com_ptr< ::ID2D1Bitmap1 > targetBitmap;
        winrt::check_hresult(
            d2dDeviceContext->CreateBitmapFromDxgiSurface(
                dxgiBackBuffer.get(),
                &bitmapProperties,
                targetBitmap.put()
            )
        );

        d2dDeviceContext->SetTarget(targetBitmap.get());

        // Draw using Direct2D context.
        d2dDeviceContext->BeginDraw();

        d2dDeviceContext->Clear(D2D1::ColorF(D2D1::ColorF::Orange));

        winrt::com_ptr<::ID2D1SolidColorBrush> brush;
        winrt::check_hresult(d2dDeviceContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::Chocolate),
            D2D1::BrushProperties(0.8f),
            brush.put()));

        D2D1_SIZE_F const size{ 500, 500 };
        D2D1_RECT_F const rect{ 100.0f, 100.0f, size.width - 100.0f, size.height - 100.0f };
        d2dDeviceContext->DrawRectangle(rect, brush.get(), 100.0f);

        d2dDeviceContext->EndDraw();

        swapChain->Present(1, 0);
    }

    void BoxRenderer::SwapChainPanel_SizeChanged(Microsoft::UI::Xaml::DependencyObject const& d, Microsoft::UI::Xaml::DependencyPropertyChangedEventArgs const& /* e */)
    {
        if (SwapChainComponent::BoxRenderer theControl{ d.try_as<SwapChainComponent::BoxRenderer>() })
        {
            // Call members of the projected type via theControl.

            SwapChainComponent::implementation::BoxRenderer* ptr{ winrt::get_self<SwapChainComponent::implementation::BoxRenderer>(theControl) };
            // Call members of the implementation type via ptr.
        }
    }
}
