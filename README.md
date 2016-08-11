# Intrinsics-Dude
Opensource Visual Studio 2015 extension for compiler instrinsics in C/C++. This extension can be found in the visual studio extensions gallery or download latest installer IntrinsicsDude.vsix (v0.0.0.0)

### Features

#### Quickinfo Tooltips
QuickInfo is an IntelliSense feature that displays method signatures and descriptions when a user moves the pointer over a method name. The minimal default tooltips are replaced by more informative ones. 

[TODO PICTURE]

#### Statement Completion
Statement completion is the process by which the language service helps users finish a language keyword or element that they have started typing in the editor. The minimal default tooltips are replaced by more informative ones. If the current keyword starts with _m the code completion key combination (typically CTRL+SPACE) will populate a separate completion list called Intrinsics.

[TODO PICTURE]

#### Signature Help

Signature Help (also known as Parameter Info) displays the signature of a method in a tooltip when a user types the parameter list start character (typically an opening parenthesis). As a parameter and parameter separator (typically a comma) are typed, the tooltip is updated to show the next parameter in bold.

[TODO PICTURE]

### The Source

If you are reading this you are most likely a C/C++ programmer, if you are still interested in some dirty C# you can run the extension from source code. To do that, Visual Studio 2015 SDK needs to be installed. To run the extension, hit F5 or choose the Debug > Start Debugging menu command. A new instance of Visual Studio will launch under the experimental hive.

### Feature Requests: (desire something - let me know)
* No syntax highlighting for intrinsic keywords that are not enabled.
* 

### Updates
* 25 Juli 2016: Start of project
* ? August 2016: First release (v1.0.0.0)
