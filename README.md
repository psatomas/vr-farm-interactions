# VR Farm Interactions

## Fundamentals of the Metaverse: Creating Your First Interactive VR Experience

---

## 👤 Student Information

**Full Name:** Tomás Patrício da Silva Araújo  
**Class / Residency:** TIC 29  
**Course:** Web 3.0 — Metaverse Development  
**Unity Version:** 6000.3.9f1  

---

## 🎮 Project Overview

VR Farm Interactions is a Unity-based first-person 3D interaction prototype that simulates a simple farm environment inspired by metaverse interaction principles.

The player explores a rural scene using keyboard and mouse controls and interacts with objects through a raycast-based system that triggers real-time audio feedback.

The focus is on interaction systems rather than visual fidelity.

---

## 🌍 Context and Objective

This project represents a simplified metaverse-style environment designed to demonstrate core interaction mechanics used in immersive systems.

### Objectives:
- Build a functional 3D interactive environment in Unity  
- Implement first-person navigation (PC prototype)  
- Create raycast-based object interaction  
- Provide real-time audio feedback  
- Demonstrate interaction loop design (input → action → response)  

---

## 🛠️ Technical Specifications

- Engine: Unity 6000.3.9f1  
- Platform: PC (Editor / Standalone)  
- Input: Keyboard (WASD) + Mouse  
- Controller: CharacterController  
- Interaction: Raycast click system  
- Audio: SFX-based feedback system  

⚠️ Note: This project does not use VR or XR SDKs. It is a PC-based prototype simulating interaction logic commonly used in XR systems.

---

## 🧠 Core Interaction System

### Main Mechanic
The player interacts with a chicken object using a raycast system.

### Flow:
- Raycast emitted from camera center  
- Detects interactable object  
- Mouse click triggers interaction  
- Chicken responds with sound  

### Features:
- Audio playback (cluck sound)  
- Random pitch variation  
- Random volume variation  
- Cooldown system to prevent spam  

---

## 📁 Project Structure

Assets
- Scripts
  - PlayerMovement.cs
  - PlayerControls.cs
  - ChickenSound.cs
- Audio
  - Mixer (audio routing setup)
  - SFX (sound effects)
- Scenes
  - Farm_Prototype.unity

ProjectSettings  
Packages  
.gitignore  

---

## 🌾 Scene Structure

Scene: Farm_Prototype

MANAGEMENT
- EventSystem

PLAYER
- Player (CharacterController)
- Main Camera

ENVIRONMENT
- Terrain
- Directional Light
- Skybox
- Farm objects

INTERACTABLES
- Chicken Object
  - ChickenSound script

---

## 🔄 Interaction Logic

1. Player moves using WASD  
2. Camera follows mouse movement  
3. Raycast is emitted forward  
4. If object is hit:
   - Click triggers interaction  
5. Object responds with audio feedback  

---

## 🔊 Audio System

- SFX folder contains interaction sounds  
- Mixer folder prepared for audio routing  
- Chicken sound includes:
  - Pitch variation  
  - Volume variation  
  - Cooldown control  

---

## 🧪 Development Process & Challenges

During development, the project went through multiple iterations focused on stabilizing input systems, interaction reliability, audio feedback behavior, and repository structure.

---

### 1. Environment Optimization (Skybox & Performance)
Initially, a high-resolution 4K skybox was used to improve visual quality. However, this caused issues during repository submission due to excessive file size and GitHub upload limitations, affecting cloning reliability.

**Solution:**  
The skybox was replaced with a lower-resolution 1K version, significantly reducing project size and ensuring successful repository cloning without data loss or performance issues.

---

### 2. Build Configuration Stability
In early development stages, Build Settings were not properly configured, which affected project consistency and execution reliability across different environments.

**Solution:**  
Build settings were later correctly defined and validated, ensuring a stable Unity project configuration and correct execution in the Editor.

---

### 3. Input System & Interaction Complexity
A major challenge was implementing and stabilizing the interaction system using Unity’s Input System combined with raycast-based detection.

Difficulties included:
- Mapping Input Actions correctly for movement and interaction  
- Ensuring consistent raycast detection for the chicken interaction system  
- Understanding script execution flow during runtime  

Additionally, identifying whether scripts were executing correctly was initially difficult due to limited runtime visibility.

**Solution:**  
Debug logs were strategically implemented to trace execution flow, allowing precise validation of input handling and interaction behavior during runtime.

---

### 4. Audio System Integration
The interaction system required coordination between:
- Audio Source configuration  
- Audio Clips (SFX)  
- ChickenSound script logic  
- Audio Mixer structure (prepared for organization and routing)

Challenges included ensuring that audio feedback felt natural and not repetitive during repeated interactions.

**Solution:**  
Pitch and volume variation were implemented alongside a cooldown system, improving responsiveness and preventing audio spam during rapid interactions.

---

### 5. TextMeshPro Dependency Issue
A dependency issue related to TextMeshPro created unnecessary complications in project portability and repository management.

**Solution:**  
Unnecessary generated dependencies were excluded using `.gitignore`, ensuring a clean repository structure and preventing missing package issues during cloning.

---

### 6. Version Control Consistency
Early commits included oversized or unnecessary assets, which affected repository cloning performance and increased project size.

**Solution:**  
The project structure was cleaned and optimized for GitHub compatibility, ensuring lightweight, reproducible, and stable repository distribution. 

---

## 📌 Learning Outcomes

- Raycast-based interaction design  
- First-person controller architecture  
- Event-driven input systems  
- Audio feedback loops in Unity  
- Clean modular scripting structure  

---

## 🚀 Future Improvements

- Migration to VR using Meta XR SDK  
- Multiple interactable farm objects  
- Expanded environment simulation  
- Multiplayer interaction system  
- Physics-based interactions  

---

## 📎 Technical Reflection (Appendix)

### Project Summary
A Unity-based interactive farm prototype focused on core interaction mechanics in a simulated metaverse environment.

### Technical Stack
- Unity Editor (no XR SDK)
- CharacterController movement
- Raycast interaction system
- Audio feedback system

### Interaction System
- Input → Raycast → Detection → Audio Response
- Designed to simulate XR-style interaction loops without VR hardware

### Reflection
This project demonstrates foundational principles of immersive interaction systems, focusing on input handling, feedback loops, and modular Unity architecture.