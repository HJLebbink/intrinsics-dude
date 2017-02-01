# Intrinsics-Dude
Improved support for compiler intrinsics in Visual Studio. This extension can be found in the [visual studio extensions gallery](https://visualstudiogallery.msdn.microsoft.com/2deb6fbb-ff72-470b-a9ac-96115a0bf0ad) or download latest installer [IntrinsicsDude.vsix (v1.1.3.0)](https://github.com/HJLebbink/intrinsics-dude/releases/download/1.1.3.0/IntrinsicsDude.vsix). If intrinsics are not low level enough, consider [Asm-Dude](https://github.com/HJLebbink/asm-dude).

### Features

#### Quickinfo Tooltips
QuickInfo is an IntelliSense feature that displays method signatures and descriptions when a user moves the pointer over a method name. The minimal default tooltips are replaced by more informative ones. 

![label-analysis](https://github.com/HJLebbink/intrinsics-dude/blob/master/Images/QuickInfo.png?raw=true "QuickInfo")

#### Statement Completion
Statement completion is the process by which the language service helps users finish a language keyword or element that they have started typing in the editor. The minimal default tooltips are replaced by more informative ones. If the current keyword starts with _m the code completion key combination (typically CTRL+SPACE) will populate a separate completion list called Intrinsics.

![label-analysis](https://github.com/HJLebbink/intrinsics-dude/blob/master/Images/StatementCompletion.png?raw=true "Statement Completion")

#### Signature Help

Signature Help (also known as Parameter Info) displays the signature of a method in a tooltip when a user types the parameter list start character (typically an opening parenthesis). As a parameter and parameter separator (typically a comma) are typed, the tooltip is updated to show the next parameter in bold.

![label-analysis](https://github.com/HJLebbink/intrinsics-dude/blob/master/Images/SignatureHelp.png?raw=true "Signature Help")

### The Source

If you are reading this you are most likely a C/C++ programmer, if you are still interested in some dirty C# you can run the extension from source code. To do that, Visual Studio 2015 SDK needs to be installed. To run the extension, hit F5 or choose the Debug > Start Debugging menu command. A new instance of Visual Studio will launch under the experimental hive.

### Known Issues
* Incorrect syntax highlighting of SIMD registers and intrinsic functions in code comment blocks.
* No support for AMD-specific intrinsics (ammintrin.h)

### Feature Requests: (desire something - let me know)
* ~~Restrict code completion suggestions based on the return type when used as a parameter in an intrinsic.~~
* ~~Fix _may_i_use_cpu_feature: not showing the valid feature flags.~~
* ~~Add Performance data to QuickInfo tooltips.~~
* No syntax highlighting for intrinsic keywords that are not enabled.
* Descriptions for all int definitions such as _MM_ROUND_MASK etc.
* Support AMD-specific intrinsics (ammintrin.h)

### Updates
* 25 Juli 2016: Start of project
* 26 August 2016: First release (v1.0.0.7)
* 2 September 2016: Added Performance data to QuickInfo tooltips (v1.1.0.0)
