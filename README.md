# A sample project of a C++/WinRT XAML object to make C#/.Net projection

A sample project to make UserControl (based on SwapChainPanel in C++/WinRT) and projection project for .Net.
This repository was made to "Ask Question" in Microsoft Q&A. So the code does not work, currently. How can I make it work, is the Question.

The repository includes;

- One Windows Runtime Component and Projecting project, _CppWinRTComponentProjectionSample_.
- Two stub projects to use it. One is the original _ConsoleAppSample_, the others new _StubWinUI3Desktop_.

The most of the code comes from _"original code"_ on Reference, "SimpleMath" by Microsoft.

## Intended

I'm now building a WindowsAppSDK(WinUI3) based C#/.Net desktop application. (most probably I will use C#/WinRT.)
In a *Page* of the app, I want place a *SwapChainPanel* in WinUI3 and use DirectX to draw something in C++/WinRT. So I want to check if the *SwapChainPanel* or *UserControl* derived from the Projection project can be a boudary of interop C++/WinRT and C#.
Is it possible?
Though the repository code tried to refer WRC via NuGet package, it just accord a way of "SimpleMath". Generally speaking, most people prefer to refer to it as conventional DLL or project reference, I think.


## Reproducing Error

Windows SDK 10.0.22621.0 and 10.0.19040.0(as minimum).
with VisualStudio 2022;

1) Open _CppWinRTComponentProjectionSample.sln_
2) Restore NuGet packages. (Please keep CsWinRT's version to 1.6.5, otherwise generate errors.)
3) Set Release/x64 (**NOT** _Debug_)
4) build SimpleMath projection. This project contains two .idl files. One is original the other is what I add.
   If "SimpleMathProjection/nuget/SimpleMathComponent.0.1.0-prerelease.nupkg" generated, close the solution.
5) (this is the working case, same as original code) Open _ConsoleAppSample.sln_
6) Set release/x64 (or Debug/x64) and build.
7) Confirm it works (some arithmetic calculation) then close the solution.
8) (this is the error case) open _StubWinUI3Desktop.sln_
9) Set Debug/x64 (or Release/x64) and build.
10) Run it. You'll get error saying;
    _"Error    WMC0001    Unknown type 'BoxRenderer' in XML namespace 'using:SimpleMathProjection'    StubWinUI3Desktop    <u>my-path</u>\NetProjection\StubWinUI3Desktop\DxPage.xaml    12    "_

## What doesn't work

- cannot refer to *BoxRenderer* which is just contain *SwapChainPanel* in WindowsRuntimeComponent in C++/WinRT. 

## Update

- 09/05/2022 SwapChainPanel placed in XAML in Generic.xaml directly (but it did not work). Property changed to represents background color (but it does not work).
- 09/09/2022 Add normal SwapChainPanel (in WinUI3) page to compare propergated from NuGet package (in C++/WinRT). and realized that SwapChainPaned does not appeared to the consuming app. Though I did put DirectX resource on it but in vain.

## Reference

- [original code](https://github.com/microsoft/CsWinRT/tree/master/src/Samples/NetProjectionSample)
- [Generate a C# projection from a C++/WinRT component, distribute as a NuGet for .NET apps](https://docs.microsoft.com/en-us/windows/apps/develop/platform/csharp-winrt/net-projection-from-cppwinrt-component)
- [Windows Runtime components with C++/WinRT](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt)
- [Build XAML controls with C++/WinRT](https://docs.microsoft.com/en-us/windows/apps/winui/winui3/xaml-templated-controls-cppwinrt-winui-3)
- [Call Windows Runtime APIs in desktop apps](https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/desktop-to-uwp-enhance)
