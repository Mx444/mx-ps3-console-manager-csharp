# PS3 Console Manager

This repository contains a Windows Forms application developed in C# for managing a PlayStation 3 console using the CCAPI library. It provides various functionalities to interact with a connected PS3, such as connecting, attaching to processes, retrieving console information, setting IDs, controlling console features like buzzing and LEDs, and basic memory editing.

## Repository Structure

The main application code is located within the `ConsoleManager` directory:

-   **ConsoleManager/**: Main application directory
    -   **Dialog/**: Contains custom dialog forms (Connect, Attach, Log).
    -   **Properties/**: Project properties, resources, and settings.
    -   **bin/Debug/**: Output directory for debug builds, including necessary libraries (`PS3Lib.dll`, `CCAPI.dll`, `MetroFramework.dll`).
    -   **Form1.cs**: Main application form logic.
    -   **Form1.Designer.cs**: Designer file for the main form.
    -   **Input.cs**: Helper class for input dialogs.
    -   **Program.cs**: Application entry point.
    -   **ConsoleManager.csproj**: Project file.
    -   **app.config**: Application configuration.
    -   **IP.txt**: File used to store PS3 IP addresses.
    -   Other files related to resources, settings, and designer components.
-   **ConsoleManager.sln**: Visual Studio solution file.
-   **README.MD**: This file.

## Features

The PS3 Console Manager offers the following features:

-   **Console Connection**: Connect to a PS3 console via IP address using CCAPI.
-   **Process Attachment**: Attach to running processes on the connected PS3.
-   **Console Information**: Display console firmware version, type, and temperature (CELL/RSX).
-   **Console ID Management**: Set Console ID (CID) and Boot Console ID (Boot CID).
-   **PSID Management**: Set PSID.
-   **Console Control**:
    -   Ring the console buzzer (Single, Double, Triple).
    -   Control console LEDs (Color: Green/Red, Status: On/Off/Blink).
    -   Send notifications to the PS3.
-   **Memory Editing**: Read and write memory values at specified offsets for attached processes.
-   **IP Address Management**: Save and load PS3 IP addresses from a local file (`IP.txt`).

## How to Use

1.  **Connect to PS3**:
    -   Ensure your PS3 is running CCAPI and is on the same network as your PC.
    -   Add the PS3's IP address to the list in the application (or ensure it's in `IP.txt`).
    -   Select the IP address from the list.
    -   Click the connect button (usually labeled "Connect" or similar in the UI, corresponding to the "aaToolStripMenuItem").
2.  **Attach to Process**:
    -   Once connected, navigate to the "Attach" section.
    -   Select the desired process from the dropdown list.
    -   Click the attach button.
3.  **Use Features**:
    -   Navigate through the application tabs to access different functionalities like setting IDs, controlling LEDs/Buzzer, sending notifications, or editing memory.

## Technical Implementation

The application is built using:

-   **C#**: The primary programming language.
-   **Windows Forms**: For the graphical user interface.
-   **DevExpress**: UI controls and components.
-   **PS3Lib (CCAPI)**: Library for interacting with the PS3 console.
-   **MetroFramework**: Used for some UI styling (based on project references).

## Requirements

-   **Operating System**: Windows.
-   **Development Environment**: Visual Studio (version compatible with .NET Framework 4.6).
-   **.NET Framework**: Version 4.6 or higher.
-   **PS3Lib and CCAPI**: The necessary DLLs (`PS3Lib.dll`, `CCAPI.dll`) must be present (typically in the `bin/Debug` directory after building).
-   **DevExpress Libraries**: Required DevExpress assemblies (referenced in the `.csproj` file).
-   **MetroFramework**: Required MetroFramework assembly (referenced in the `.csproj` file).
-   **PS3 Console**: A PlayStation 3 console with CCAPI installed and running.

## Getting Started

To get started with the PS3 Console Manager:

1.  Clone this repository.
2.  Open the `ConsoleManager.sln` file in Visual Studio.
3.  Ensure all required references (PS3Lib, CCAPI, DevExpress, MetroFramework) are correctly linked. You might need to manually add references if the paths in the `.csproj` file are specific to the original developer's setup.
4.  Build the solution.
5.  Run the `ConsoleManager.exe` executable from the `bin/Debug` (or `bin/Release`) directory.

---

*This project utilizes the PS3Lib and CCAPI libraries for communication with the PlayStation 3 console.*
```

        