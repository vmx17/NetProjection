#pragma once

#include "winrt/Microsoft.UI.Xaml.h"
#include "winrt/Microsoft.UI.Xaml.Markup.h"
#include "winrt/Microsoft.UI.Xaml.Controls.Primitives.h"
#include "BoxRenderer.g.h"

namespace winrt::SimpleMathComponent::implementation
{
    struct BoxRenderer : BoxRendererT<BoxRenderer>
    {
        BoxRenderer();
        static winrt::Microsoft::UI::Xaml::DependencyProperty BoxSizeProperty() { return m_boxSizeProperty; }
        static void BoxSizeProperty(winrt::Microsoft::UI::Xaml::DependencyProperty const& value) { m_boxSizeProperty = value; };

        int32_t BoxSize() { return winrt::unbox_value<int32_t>(GetValue(m_boxSizeProperty)); }
        void BoxSize(int32_t const& value) { SetValue(m_boxSizeProperty, winrt::box_value(value)); }

        static void OnBoxSizeChanged(Microsoft::UI::Xaml::DependencyObject const&, Microsoft::UI::Xaml::DependencyPropertyChangedEventArgs const&);

    private:
        static Microsoft::UI::Xaml::DependencyProperty m_boxSizeProperty;
    };
}

namespace winrt::SimpleMathComponent::factory_implementation
{
    struct BoxRenderer : BoxRendererT<BoxRenderer, implementation::BoxRenderer>
    {
    };
}
