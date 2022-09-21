# A sample project of a C++/WinRT XAML object to make C#/.Net projection

A sample project to make UserControl (based on SwapChainPanel in C++/WinRT) and projection project for .Net.
This repository was made to "Ask Question" in Microsoft Q&A but I also want help from other persons. The code does not work, currently. How can I make it work, is the Question.

The repository includes;

- One Windows Runtime Component and Projecting project, _CppWinRTComponentProjectionSample_.
- Two stub projects to use it. One is the original _ConsoleAppSample_, the others new _StubWinUI3Desktop_. Ppreviously another solution _ConsoleAppSample_ existed but was removed. This is to simplify the point of error.

The most of the code comes from _"original code"_ on Reference "SimpleMath" by Microsoft.

## Motivation

I'm now building a WindowsAppSDK(WinUI3) based C#/.Net desktop application. (most probably I will use C#/WinRT.)
Now the era of Modern UI. Windows App SDK gave us new way to make desktop application using WinUI3 in XAML.<br>
So I think that I can get performance in C++ and get productivity in C#. Espacially around DirectX, the SwapChainPanel was re-defined in Microsoft.UI.XAML.Controls namespace. This means, Microsoft let us use the SwapChainPanel drived by DirectX with C++/WinRT, and in other parts make us use C#. Interop of C#/WinRT and C++/WinRT using WindowsAppSDK make it possible...<br>

but it's a dream. <br>

In a *Page* of the C# app, "_StubWinUI3Desktop_", I want place a *SwapChainPanel* in WinUI3 and use DirectX to draw something in C++/WinRT. So I want to check if the *SwapChainPanel* or *UserControl* derived from the Projection project can be a boundary of interop C++/WinRT and C#.<br>

After all, the question comes to "Is it possible?"<br>

Though the repository code tried to refer WRC via NuGet package, it just accord a way of "SimpleMath". I realized the nuget package is very hard to debug. Generally speaking, most people prefer to refer to it as conventional DLL or project reference, I think.

## Reproducing Error

updated: 9/22/2022

Windows SDK 10.0.22621.0 and 10.0.19040.0(as minimum).
with VisualStudio 2022;

Confirm, this modification was done in _develoip_ branch only.

I remove _SimpleManth.idl_ and related modules. Though it was in the same namespace of _BoxRenderer.idl_, when I unified them, the compiler output a multiple declaration error. So I decided to remove _SimpleMath.idl_ and its staff. And to simplify, I removed property from _BoxRenderer.idl_ also. Now the code "ConsoleAppSample.sln" does not work. Then its solution files were removed.
 Before starting, confirm you're in _develoip_ branch. This is experimental branch.

1) Open _CppWinRTComponentProjectionSample.sln_
2) Restore NuGet packages.
3) Set Release/x64 (**NOT** Debug)
4) build solution. If "SimpleMathProjection/nuget/SimpleMathComponent.0.3.0-prerelease.nupkg" generated, close the solution.<br>
   The control "**BoxRenderer**" is included in it. This is a user control derived from SwapChainPanel.
5) Open _StubWinUI3Desktop.sln_ and restore NuGet packages. This should include "_SimpleMathComponent.0.3.0-prerelease.nupkg_" got in 4.
   set release/x64 or Debug/x64 then build.
6) Run it and push "Next Page" button. Now it works without errors but seems no SwapChainPanel appeared. IS it?

## What doesn't work

- cannot refer to *BoxRenderer* XAML control which is just contain *SwapChainPanel* in WindowsRuntimeComponent in C++/WinRT. 

## Update

- 9/22/2022 delete SimpleMath part from "_CppWinRTComponentProjectionSample.sln_". Now it has only one *.idl, "BoxRenderer". It just a SwapChainPanel.
- 9/21/2022 reduce parameters and properties from the experimental souce Ci7.
- 09/14/2022 Fix reference bug on _StubWinUI3Desktop.sln_. Change property from _BackColor_ to _BoxSize_. Because WinUI3's SwapChainPane does not have the BackColor property then define an independent property (not used, currently). CsWinRT was added/updated to required projects.<br>
  _StubWinUI3Desktop_ has a normal SwapChainPanel at the first page to compare WRC's SwapChainPanel-based user control.
- 09/05/2022 SwapChainPanel placed in XAML in Generic.xaml directly (but it did not work). Property changed to represents background color (but it does not work).
- 09/06/2022 by JunjieZhu-MSFT's comment, the compile errors were disappeared.
- 09/09/2022 I realize that the SwapChainPanel is not shown. Add normal SwapChainPanel (in WinUI3) page to compare propergated from NuGet package (in C++/WinRT). and realized that SwapChainPaned does not appeared to the consuming app. Though I've once put DirectX resource on it but delete again.

## Reference

- [original code](https://github.com/microsoft/CsWinRT/tree/master/src/Samples/NetProjectionSample)
- [Generate a C# projection from a C++/WinRT component, distribute as a NuGet for .NET apps](https://docs.microsoft.com/en-us/windows/apps/develop/platform/csharp-winrt/net-projection-from-cppwinrt-component)
- [Windows Runtime components with C++/WinRT](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/create-a-windows-runtime-component-in-cppwinrt)
- [Build XAML controls with C++/WinRT](https://docs.microsoft.com/en-us/windows/apps/winui/winui3/xaml-templated-controls-cppwinrt-winui-3)
- [Call Windows Runtime APIs in desktop apps](https://docs.microsoft.com/en-us/windows/apps/desktop/modernize/desktop-to-uwp-enhance)

## About the repository

- To change main requires pull request.
- develop branch can be modified freely.
- If there are another branch, that's a experimental. Do not use, besically.
