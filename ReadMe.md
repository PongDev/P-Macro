# P Macro
### Simple Macro Program Write In C# By PongDev

### Requirement
- Visual Studio (Originally Program build on Visual Studio 2017)
- Design for Windows OS
### Compile
- Use Visual Studio to Compile to Release Version
- Release Compile File will located in `P Macro/bin/Release/P Macro.exe`
## How to Use
### Program has 2 options
- Macro Record (And Play Record)
- Shortcut Macro
### Macro Record (And Play Record)
- Can Manually Insert/Edit/Delete Input Data or Use Start Record to Record Macro
- Can Save/Load Macro Record (Save file created in `P Macro Save/Record` folder)
    - Macro load automatically on open Program **But not auto save (Must save Manually)**
- Can Config Play Option (For Replay Macro)
    - Delay Before Activate Macro in Milliseconds
    - Macro Loop Amount (Or Loop Until Break Key Press)
### Shortcut Macro
- Can Setting Macro Command for Specific Key Press Combination
    - **Macro Property**
        - **Hide Cmd:** Select to Hide Cmd or not on Activate Shortcut
        - **Command:** Command to pass to Cmd
        - Can Update or Remove Macro
- Can Save/Load Shortcut Macro (Save file created in `P Macro Save/Shortcut` folder)
    - Macro load automatically on open Program **But not auto save (Must save Manually)** (`Save Macro` in Shortcut Macro Menu Save **All Shortcut Macro**)
### Run Program On Startup
- Select to Run Program on Startup or not by Check `Run On Startup` in Shortcut Macro Menu
### Exit Program
- If Click `X` in Program, Program will go to Windows System Tray and Working in Background
- To Exit Program Completely, Right Click Program Icon on Windows System Tray and Click `Exit`
