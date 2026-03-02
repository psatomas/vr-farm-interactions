# VR Farm Environment

This project was developed as part of the Web 3.0 Residência em TIC 29 program.

## Description
A simple navigable VR environment built in Unity to demonstrate fundamental XR concepts.
The scene represents a basic farm environment and is compatible with the Meta XR SDK.

Note: We organized the project under a `_Project` folder inside `Assets`.

## Project Structure
Assets/_Project/
├─ Art/
│  ├─ Farm/        # 3D objects
│  ├─ Materials/   # Materials used in the scene
│  ├─ Skybox/      # Skybox textures
│  └─ Terrain/     # Ground and terrain
├─ Scenes/         # Main scene(s)
└─ Scripts/
   └─ Player/
      ├─ PlayerControls.cs
      └─ PlayerMovement.cs

## How to Run
1. Open the project in Unity Hub using Unity version 6000.3.9f1.
2. Open the main scene located in Assets/_Project/Scenes.
3. Press Play to test movement on PC.
4. Build settings are configured for Android (Meta Quest).

## Player Controls (PC)
- W/A/S/D → Move
- Mouse → Look around / camera rotation
- Space → Jump (if implemented)

Movement is tested without VR enabled to allow PC testing on Linux.

## Author
Tomás Araújo
