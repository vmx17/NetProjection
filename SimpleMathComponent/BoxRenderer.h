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
        winrt::hstring BackColor()
        {
            return winrt::unbox_value<winrt::hstring>(GetValue(m_backColorProperty));
        }

        void BackColor(winrt::hstring const& value)
        {
            SetValue(m_backColorProperty, winrt::box_value(value));
        }

        static Microsoft::UI::Xaml::DependencyProperty BackColorProperty() { return m_backColorProperty; };
        static void OnBackColorChanged(Microsoft::UI::Xaml::DependencyObject const&, Microsoft::UI::Xaml::DependencyPropertyChangedEventArgs const&);

    private:
        static Microsoft::UI::Xaml::DependencyProperty m_backColorProperty;
    };
}

namespace winrt::SimpleMathComponent::factory_implementation
{
    struct BoxRenderer : BoxRendererT<BoxRenderer, implementation::BoxRenderer>
    {
    };
}
