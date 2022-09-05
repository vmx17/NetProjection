#include "pch.h"
#include "BoxRenderer.h"
#if __has_include("BoxRenderer.g.cpp")
#include "BoxRenderer.g.cpp"
#endif

using namespace Concurrency;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::SimpleMathComponent::implementation
{
    Microsoft::UI::Xaml::DependencyProperty BoxRenderer::m_backColorProperty =
        Microsoft::UI::Xaml::DependencyProperty::Register(
            L"BackColor",
            winrt::xaml_typename<winrt::hstring>(),
            winrt::xaml_typename<SimpleMathComponent::BoxRenderer>(),
            Microsoft::UI::Xaml::PropertyMetadata{ winrt::box_value(L"ForestGreen"), Microsoft::UI::Xaml::PropertyChangedCallback{ &BoxRenderer::OnBackColorChanged } }
    );
    BoxRenderer::BoxRenderer()
    {
        DefaultStyleKey(winrt::box_value(L"BoxRendererApp.BoxRenderer"));
    }

    void BoxRenderer::OnBackColorChanged(Microsoft::UI::Xaml::DependencyObject const& d, Microsoft::UI::Xaml::DependencyPropertyChangedEventArgs const& /* e */)
    {
        if (SimpleMathComponent::BoxRenderer theControl{ d.try_as<SimpleMathComponent::BoxRenderer>() })
        {
            // Call members of the projected type via theControl.

            SimpleMathComponent::implementation::BoxRenderer* ptr{ winrt::get_self<SimpleMathComponent::implementation::BoxRenderer>(theControl) };
            // Call members of the implementation type via ptr.
        }
    }
}
