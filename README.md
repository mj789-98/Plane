# ✈️ Plane - Android Flight Game

A thrilling 2D/3D Android flight game built with Unity where players control a plane through challenging obstacles while collecting power-ups and achieving high scores.

## 🎮 Game Overview

**Plane** is an action-packed mobile game featuring:
- **Touch-based flight controls** - Intuitive movement with smooth animations
- **Dynamic obstacle spawning** - Randomly generated challenges with object pooling
- **Power-up system** - Collect various power-ups to enhance gameplay
- **High score tracking** - Persistent leaderboard system
- **Immersive audio** - Background sounds and explosion effects
- **Modern UI** - Clean interface with pause/resume functionality

## 🛠️ Technical Specifications

### Unity Engine
- **Unity Version**: 2022.3.34f1 LTS
- **Target Platform**: Android (API 28-34)
- **Package Identifier**: `com.lightning.android.Plane`
- **Orientation**: Landscape

### Key Features
- **Object Pooling System** - Efficient memory management for spawned objects
- **Component-Based Architecture** - Modular and maintainable code structure
- **Input System Integration** - Unity's new Input System for cross-platform support
- **Post-Processing Effects** - Enhanced visual quality
- **Cinemachine Integration** - Smooth camera movements and transitions

## 🎯 Core Gameplay Mechanics

### Player Controls (`PlayerMovement.cs`)
- Touch-based movement with smooth lerp interpolation
- UI-aware touch detection (ignores UI elements)
- Animated state transitions based on movement direction
- Particle system integration for visual effects

### Spawn System (`SpawnMan.cs`)
- Advanced object pooling for performance optimization
- Random spawn positioning within defined bounds
- Configurable spawn intervals and delays
- State management for pooled objects

### Scoring System (`Score.cs`, `GameManager.cs`)
- Real-time score tracking
- Persistent high score storage using PlayerPrefs
- Automatic high score detection and saving

### Power System (`PowerSystem.cs`)
- Multiple power-up types and effects
- Collision-based power-up collection
- Enhanced gameplay mechanics

## 📱 Supported Platforms

- **Primary**: Android (SDK 28+)
- **Resolution**: Adaptive (1920x1080 default)
- **Orientation**: Landscape (both left and right)
- **Input**: Touch screen optimized

## 🎨 Assets & Resources

The project includes:
- **2D Sprites**: UI elements, backgrounds, characters
- **3D Models**: Plane models and environmental objects
- **Animations**: Character movements and transitions
- **Audio**: Background music and sound effects
- **Particle Systems**: Explosions and visual effects
- **Materials**: Custom shaders and visual enhancements

### Key Asset Packages
- Cinemachine (camera control)
- Unity Input System
- Post Processing Stack
- TextMeshPro (UI text rendering)
- Various explosion and visual effect packages

## 🚀 Installation & Setup

### Prerequisites
- Unity 2022.3.34f1 or later
- Android SDK (API 28-34)
- Android NDK (for IL2CPP builds)

### Getting Started
1. Clone the repository
2. Open the project in Unity 2022.3.34f1+
3. Ensure Android build support is installed
4. Open `Scene_1.unity` for the main game scene
5. Configure build settings for Android platform

### Build Configuration
- **Scripting Backend**: IL2CPP (recommended)
- **API Compatibility Level**: .NET Standard 2.1
- **Target Architecture**: ARM64 (required for Play Store)

## 📂 Project Structure

```
Assets/
├── Scenes/              # Game scenes (Menu.unity, Scene_1.unity)
├── Scripts/             # C# game logic
│   ├── PlayerMovement.cs
│   ├── GameManager.cs
│   ├── SpawnMan.cs
│   ├── PowerSystem.cs
│   └── [Other gameplay scripts]
├── Prefabs/             # Reusable game objects
├── Sprites/             # 2D artwork and UI elements
├── Materials/           # 3D materials and shaders
├── Animations/          # Animation clips and controllers
├── Plugins/             # Third-party plugins and SDKs
└── [Other asset folders]
```

## 🎮 Controls

- **Touch & Drag**: Move the plane smoothly across the screen
- **Touch Left Side**: Trigger idle animation
- **UI Buttons**: Navigate menus and access game functions

## 🔧 Performance Optimizations

- **Object Pooling**: Efficient memory management for frequently spawned objects
- **Sprite Batching**: Optimized rendering for 2D elements
- **Compressed Textures**: Reduced memory footprint
- **Frame Rate Management**: Configurable FPS settings
- **LOD System**: Level-of-detail for 3D models

## 📊 Analytics & Monitoring

- Built-in Unity Analytics support
- Performance profiling capabilities
- Crash reporting integration
- Custom debug logging system

## 🏆 Features in Development

- Enhanced power-up system
- Additional aircraft models
- Multiplayer functionality
- Achievement system
- Cloud save integration

## 🤝 Contributing

This is a personal/educational project. For suggestions or improvements:
1. Fork the repository
2. Create a feature branch
3. Submit a pull request with detailed descriptions

## 📄 License

This project is developed for educational and personal use. Please respect third-party asset licenses included in the project.

---

**Developer**: lightning.android  
**Version**: 0.1  
**Last Updated**: February 2025

*Built with Unity 2022.3 LTS - Optimized for Android devices*
