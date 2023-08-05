#pragma once
#include <microsoft.ui.xaml.media.dxinterop.h>
#include "winrt/Microsoft.UI.Xaml.h"
#include "winrt/Microsoft.UI.Xaml.Markup.h"
#include "winrt/Microsoft.UI.Xaml.Controls.Primitives.h"
#include "BoxRenderer.g.h"

namespace winrt::SwapChainComponent::implementation
{
    struct BoxRenderer : BoxRendererT<BoxRenderer>
    {
        BoxRenderer();
        void InitializeD3D();
        void SwapChainPanel_SizeChanged(Microsoft::UI::Xaml::DependencyObject const& d, Microsoft::UI::Xaml::DependencyPropertyChangedEventArgs const&);
        static winrt::Microsoft::UI::Xaml::DependencyProperty BoxSizeProperty() { return m_boxSizeProperty; }
        static void BoxSizeProperty(winrt::Microsoft::UI::Xaml::DependencyProperty const& value) { m_boxSizeProperty = value; };
        int32_t BoxSize() { return winrt::unbox_value<int32_t>(GetValue(m_boxSizeProperty)); }
        void BoxSize(int32_t const& value) { SetValue(m_boxSizeProperty, winrt::box_value(value)); }
    private:
        static Microsoft::UI::Xaml::DependencyProperty m_boxSizeProperty;
        static Microsoft::UI::Xaml::Controls::SwapChainPanel swapChainPanel;
    };
}

namespace winrt::SwapChainComponent::factory_implementation
{
    struct BoxRenderer : BoxRendererT<BoxRenderer, implementation::BoxRenderer>
    {
    };
}
