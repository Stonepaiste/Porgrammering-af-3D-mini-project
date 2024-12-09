Here's an improved and more readable version for your GitHub README:

---

# **KeenOnDoom: A Weird Adventure**

## **Overview**

**DoomKeen** is a unique blend inspired by two iconic games, **Commander Keen** and **Doom**. In this game, DoomKeen’s spaceship crash-lands on a strange worm-infested planet, and he must shoot his way to survival. 

### **Key Features**
- **Player**: Control DoomKeen with:
  - **WASD**: Move
  - **Shift**: Sprint
  - **Space**: Jump
- **Camera**: Third-person view controlled by the mouse.
- **Enemies**: 
  - Worms patrol the map and spit green projectiles at you.
  - **Small Worms**: Deal 10 damage; have 3 health points.
  - **Boss Worm**: Deals 20 damage; has 25 health points.
- **Playfield**: Explore a large forest with paths to navigate.
- **Lives**: Start with 100 health points. Game over when health reaches zero.
- **Weapon**: Use the left mouse button to shoot. Start with 100 bullets.
- **Scoring**:
  - Earn **500 points** per worm kill.
  - Gain **10 ammo** for every 1000 points.

---

## **Development Details**

### **Gameplay Mechanics**
1. **Player Movement**:
   - Controlled using Unity’s **Third-Person Starter Assets**.
   - Uses affine transformations for position and rotation updates.
2. **Camera**:
   - Utilizes a **Cinemachine virtual camera** for perspective.
3. **Enemies**:
   - AI is driven by **NavMesh** with patrol points.
   - Worms attack the player if within range, calculated using `Vector3.Distance`.
   - Spitballs are fired towards the player, using raycasts for trajectory and physics for motion.
4. **Combat**:
   - Player shooting uses raycasting to determine hit effects and enemy damage.
   - Worms have a unique death effect: a **Blender cell fracture** splits the worm into pieces with rigid bodies for realistic disintegration.
5. **Scoreboard**:
   - Implemented using **TextMeshPro** on a canvas to display health, ammo, and score.

### **Assets**
#### **Models & Prefabs**
- **DoomKeen Character**:
  - [Commander Keen + Doom model](https://sketchfab.com/3d-models/commander-keen-doom-26e9da1116b14378b722f8deaf00ee15) by DJ_Nugget.
  - Licensed under [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/).
  - Modified: Adjusted gun texture and removed knife for rigging compatibility.
- **Worms and Spaceship**:
  - [Models](https://sketchfab.com/3d-models/commander-keen-ship-enemies-2bfe025c44a5468eb6906bf584f6beff) by Yuihocmwsy.
  - Licensed under [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/).
  - Modified: Worm model optimized for death effects.
- **Environment**:
  - Trees and wind zone: [Mountain Trees Dynamic Nature](https://assetstore.unity.com/packages/3d/vegetation/trees/mountain-trees-dynamic-nature-107004).
  - Water: [Simple Water Shader (URP)](https://assetstore.unity.com/packages/2d/textures-materials/water/simple-water-shader-urp-191449).
- **VFX**:
  - Fire and smoke: [Fire & Smoke Dynamic Nature](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/fire-smoke-dynamic-nature-217775).
  - Muzzle flash, projectiles, and hit effects: [Stylized Shoot & Hit Vol. 1](https://assetstore.unity.com/packages/vfx/particles/stylized-shoot-hit-vol-1-216558).

---

### **Scripts**
- **Player Scripts**:
  - `ThirdPersonController`: Handles player movement, animations, and camera control.
  - `BasicRigidBodyPush`: Adds gravity to the player using a Rigidbody.
  - `PlayerHealth`: Manages player health and damage.
  - `RaycastShoot`: Handles shooting mechanics and hit effects.
  - `SpawnProjectileEffect`: Manages gun effects and ammo depletion.
- **Enemy Scripts**:
  - `EnemyAICombined`: Controls patrols, attacks, and AI behavior.
  - `EnemyDamage`: Handles enemy health and death effects.
  - `Spit`: Manages spitball collision and player damage.
- **UI & Game Management**:
  - `HUDManager`: Updates the scoreboard.
  - `DeathMenu`: Displays the game-over screen.

---

### **Development Tools**
- **Terrain**: Created with Unity’s **Terrain Tools** and starter pack assets.
- **Character Rigging**: Used **Mixamo** for automatic rigging and animations.
- **Testing**: Conducted on **MacOS**.

---

## **Gameplay Scenes**
The game comprises a single fully realized scene.

---

Feel free to clone the repository and enjoy the adventure!
•	Testing:
o	Game was tested on Mac OSX
