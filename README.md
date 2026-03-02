# VR Farm Environment

This project was developed as part of the Web 3.0 Residência em TIC 29 program.

## Description
A simple navigable VR environment built in Unity to demonstrate fundamental XR concepts.
The scene represents a basic farm environment and is compatible with the Meta XR SDK.

Note: We organized the project under a `_Project` folder inside `Assets`.

## Project Structure

```
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
```

## How to Run
1. Open the project in Unity Hub using Unity version 6000.3.9f1.
2. Open the main scene located in Assets/_Project/Scenes.
3. Press Play to test movement on PC.

## Player Controls (PC)
- W/A/S/D → Move
- Mouse → Look around / camera rotation

Movement is tested without VR enabled to allow PC testing on Linux.

## Author
Tomás Araújo


# Technical Report  
**VR Farm Environment   — My First VR Environment**  
Web 3.0 | Residência em TIC 29  

---

## 1. Identification

**Student:** Tomás Araújo  
**Program:** Residência em TIC 29 — Web 3.0  

**Reported Hardware Limitation:**  
Development was performed on a Linux (Ubuntu) environment without access to Meta Quest hardware for physical testing.

During XR integration, the OpenXR loader generated a `DllNotFoundException: UnityOpenXR` error. This occurs because the OpenXR runtime attempts to load native Windows-only DLLs, which are not supported on Linux systems.

To ensure project continuity and allow Play Mode execution inside the Unity Editor, XR-related packages were temporarily removed. All feasible technical steps were implemented within the constraints of the operating system and available hardware.

---

## 2. Project Concept

### 2.1 Project Name  
**VR Farm Environment**

### 2.2 Objective  

The objective of this project is to demonstrate understanding of fundamental XR concepts through the creation of a simple navigable virtual environment in Unity.

The project focuses on:

- Proper scene hierarchy organization  
- 3D spatial composition  
- Player movement implementation  
- Clean project architecture for future XR integration  

Rather than emphasizing advanced interactivity, the goal was to build a technically coherent and structurally organized VR-ready environment.

---

## 3. Virtual Environment Description

The scene represents a basic rural farm environment containing:

- A walkable terrain  
- A central barn structure  
- Vegetation elements  
- Environmental objects  
- Configured skybox for outdoor immersion  

Lighting is implemented using a standard Directional Light to simulate sunlight.  
The Main Camera is attached to an FPS-style Player object for Editor-based testing.

---

## 4. Technical Configuration

### 4.1 Unity Version  

**Unity 6000.3.9f1 (LTS)**  

Selected due to long-term support stability and compatibility with the modern XR pipeline (OpenXR / Meta XR SDK).

---

### 4.2 Meta XR SDK Integration (Technical Description)

The intended XR setup included:

1. Installing XR Plugin Management via Package Manager  
2. Enabling OpenXR  
3. Switching platform to Android  
4. Importing Meta XR All-in-One SDK  

However, enabling OpenXR on Linux caused a critical runtime error:


DllNotFoundException: UnityOpenXR


Unity attempted to initialize Windows-native XR DLLs, which are not supported on Linux.  
This prevented Play Mode from starting and blocked script execution.

To proceed with development:

- OpenXR was removed from `Packages/manifest.json`
- XR Plugin Management was disabled
- Development continued using PC-based movement testing

The project structure remains compatible for XR reactivation on Windows/macOS.

---

### 4.3 Planned Android / Meta Quest Configuration

The intended build configuration includes:

- Platform: Android  
- Texture Compression: ASTC  
- Minimum API Level: Android 10 (Level 29)  
- XR Plugin enabled under Android  

Due to OS and hardware limitations, APK generation was not performed.

---

## 5. Player Movement (PC Testing)

Movement was implemented using:

- Unity New Input System (`.inputactions`)  
- Custom C# script: `PlayerMovement.cs`  
- Auto-generated `PlayerControls.cs` class  

**Controls:**

- W / A / S / D → Movement  
- Mouse → Camera rotation  

The Main Camera is a child of the Player object, following an FPS architecture.

---

## 6. Assets and Scene Elements

### Main Elements

**Barn**  
- Type: Imported 3D asset  
- Function: Central structure of the farm  

**Terrain**  
- Type: Unity built-in Terrain  
- Function: Walkable ground surface  

**Skybox**  
- Type: Imported material  
- Function: Outdoor environmental immersion  

After asset import, the Skybox required manual reassignment in Lighting Settings.

---

### Environment Assets

**Apple Tree**  
- Type: Imported 3D asset  
- Function: Vegetation element used to enrich the farm environment  

**Fence**  
- Type: Imported 3D asset  
- Function: Defines boundaries and improves environmental composition  

---

### Characters and Animals

**Farmer**  
- Type: 3D character asset  
- Function: Represents the human presence within the farm environment  

**Cow**  
- Type: 3D animal asset  
- Function: Adds realism and thematic consistency to the rural setting  

**Chicken**  
- Type: 3D animal asset  
- Function: Additional farm animal used to increase environmental detail  

---

### Vehicles

**Tractor**  
- Type: Imported 3D asset  
- Function: Represents agricultural machinery commonly associated with farm environments

---

## 7. GameObject Hierarchy

Scene: `MainScene`

```

[--- MANAGEMENT ---]
EventSystem

[--- PLAYER ---]
Player
├── Main Camera
├── PlayerMovement (Script)
└── CharacterController

[--- ENVIRONMENT ---]
Terrain
Directional Light

Barn
├── Mesh Renderer
├── Box Collider
└── Rigidbody (adjusted to prevent unintended physics drop)

Vegetation Objects
```

### Development Notes

- The barn initially fell due to Rigidbody without constraints.  
- Box Collider required manual resizing to correctly match mesh bounds.  
- Some “Missing Script” references occurred during asset migration and were resolved by cleaning unused components.

---

## 8. Repository Structure

```

/Assets/_Project
/Art
/Scenes
/Scripts
/ProjectSettings
/Packages
.gitignore (excluding /Library and /Temp)
```

The structure was designed to maintain clear separation between art assets, scenes, and scripts.

---

## 9. Development Process

1. Install Unity LTS  
2. Create 3D project  
3. Organize internal folder structure  
4. Import farm assets  
5. Configure terrain and lighting  
6. Implement FPS Player movement  
7. Adjust colliders and physics  
8. Test inside Unity Editor  
9. Attempt XR integration (limited by OS constraints)  

---

## 10. Reflection

### Learning Outcomes

- Practical understanding of GameObject hierarchy  
- Collider and physics configuration  
- Usage of Unity’s New Input System  
- Diagnosis of OpenXR runtime initialization errors  
- Manual dependency management via `manifest.json`  

### Challenges

- `DllNotFoundException: UnityOpenXR` on Linux  
- XR auto-initialization blocking Play Mode  
- Missing script references after asset migration  
- Manual Skybox reconfiguration  

### Future Improvements

- Reactivate XR Plugin in Windows environment  
- Generate Android APK for Meta Quest  
- Integrate XR Interaction Toolkit components  
- Add interactive objects and user interaction mechanics  

---

This project fulfills the core objectives of creating a structured, navigable virtual environment while documenting technical limitations and implementation decisions.