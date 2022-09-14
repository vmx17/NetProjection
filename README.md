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
2) Restore NuGet packages.
3) Set Release/x64 (**NOT** _Debug_)
4) build SimpleMath projection. This project contains two .idl files. One is original the other is what I add. If "SimpleMathProjection/nuget/SimpleMathComponent.0.1.6-prerelease.nupkg" generated, close the solution.
5) Open _ConsoleAppSample.sln_ and set release/x64 or Debug/x64 then build.
6) Run. Now you see a runtime error below.
```
C:\my_path\NetProjection\_build\x64\Debug\ConsoleAppSample\bin\ConsoleAppSample.exe (process 11888) exited with code -529697949.
```
7) close the solution.
8) Open _StubWinUI3Desktop.sln_ and set release/x64 or Debug/x64 then build.
9) Run it and push left button. Now it works without errors but seems no SwapChainAppeared.

## What doesn't work

- have some reference error on _ConsoleAppSample_. It seems to come from a tiny reference error but I cannot find the fix by now. (degraded...orz)
- cannot refer to *BoxRenderer* which is just contain *SwapChainPanel* in WindowsRuntimeComponent in C++/WinRT. 

## Update

- 09/14/2022 Fix reference bug on _StubWinUI3Desktop.sln_. Change property from _BackColor_ to _BoxSize_. Because WinUI3's SwapChainPane does not have the BackColor property then define an independent property. Some text was put on SwapChainPanels.<br>
_StubWinUI3Desktop_ has a normal SwapChainPanel at he first page to compare WRC's SwapChainPanel-based user control.
- 09/05/2022 SwapChainPanel placed in XAML in Generic.xaml directly (but it did not work). Property changed to represents background color (but it does not work).
- 09/06/2022 by JunjieZhu-MSFT's comment, the compile errors were disappeared.
- 09/09/2022 I realize that the SwapChainPanel is not shown. Add normal SwapChainPanel (in WinUI3) page to compare propergated from NuGet package (in C++/WinRT). and realized that SwapChainPaned does not appeared to the consuming app. Though I've once put DirectX resource on it but delete again.

## Reference

- [original code](https://github.com/microsoft/CsWinRT/tree/master/src/Samples/NetProjectionSample)
- [Generate a C# projection from a C++/WinRT component, distribute as a NuGet for .NET apps](https://docs.microsoft.com/en-us/windows/apps/develop/platform/csharp-winrt/net-projection-from-cppwinrt-component)
- [Windows Runtime components with C++/WinRT](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt)
- [Build XAML controls with C++/WinRT](https://docs.microsoft.com/en-us/windows/apps/winui/winui3/xaml-templated-controls-cppwinrt-winui-3)
- [Call Windows Runtime APIs in desktop apps](https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/desktop-to-uwp-enhance)
