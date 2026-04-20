# Enhanced Basic Sprinkler

A Stardew Valley mod that makes the early-game Basic Sprinkler actually worth crafting.
If you want to play the game fair till you have achieved the sprinkler. So watering is still an experience that you made.

## 🌻 What it does
In vanilla Stardew Valley, the Basic Sprinkler only waters the 4 immediately adjacent tiles (up, down, left, right). This mod automatically expands that range overnight, watering a **12-tile diamond shape** instead.

It keeps the early game balanced but removes the awkward farm layouts required by the original 4-tile limit.

# Tech Stack
 C# is the used programming language.

##  Features
* Changes the Basic Sprinkler watering area from 4 tiles to 12 tiles.
* Seamlessly integrates with the overnight game cycle (`DayStarted` event).
* Lightweight and works completely out of the box—no configuration needed!

## Installation
1. Install the latest version of [SMAPI](https://smapi.io/).
2. Download the latest release of this mod.
3. Unzip the downloaded folder into your `Stardew Valley/Mods` folder.
4. Run the game using SMAPI!

## Compatibility
* Requires **Stardew Valley 1.6** or higher.
* Requires the latest version of SMAPI.
* **Multiplayer:** It is recommended that all players install the mod to ensure the watered dirt syncs correctly across everyone's screens.

##  Compiling from Source
If you want to build or modify this mod yourself:
1. Clone the repository to your local machine.
2. Ensure you have Stardew Valley installed (the project needs to reference the game's `.dll` files).
3. Open the `.sln` file in Visual Studio or your preferred C# IDE.
4. Build the project.

*(Note: If you have SMAPI's developer tools set up, compiling will automatically deploy the mod to your game's Mods folder).*