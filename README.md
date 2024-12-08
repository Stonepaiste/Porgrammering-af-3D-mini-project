Overview of the Game:
The idea of the project is a reference to two of my favorite games Commander Keen and Doom having a weird child together. DoomKeen’s spaceship has fallen down on a weird worm planet and he has to shoot his way out. The game has worms patrolling the map trying to kill you if you get too close. There is also a boss.. 
The main parts of the game are:
•	Player – KeenDoom, moved with the keyboard WASD, Shift for sprint and space for jump. 
•	Camera –Third person camera controlled with the mouse
•	Enemies – Worms, trying to kill you with spitting green spitballs at you. The small worms gives 10 damage and the big boss gives 20. The small has 3 healthpoints and the boss has 25. 
•	Play field – The map is a big forest with paths to walk on.
•	Lives – the player starts with 100 health points, once all lives are removed the KeenDoomGuy dies and the game ends.
•	Wepon: the player has a weapon that can be used on the Left mouse button. From start the player have 100 shots. 
Game features:
•	When you kill a worm you get 500 points. 
For each 1000 points the player gets 10 ammo. 

How were the Different Parts of the Course Utilized:
The movement of the character consists of our 3D model with a camera attached (actually a virtual camera since the main camera is controlled by the cinemachine brain) that are moved with affine transformations via changing the position, and rotation parameters. The camera is of the perspective type, meaning that objecs further away appear smaller. The animations of the character model is controlled by an animator that calls the specific animation when the 3Dmodel is transformed.
The enemies is controlled by a navmesh and all has patrolling points. As soon as the player comes within a predefined distance messured via Unitys built in vector3.Distance method (calculating the distance between two transform.positions) they will start attacking. When shooting they are looking at the player position to define a vector3 and shoot the spitball in the direction of the player with a force.Acceleration that add a continious acceleration to the spitball ignoring the balls mass. 
The worm spitball is using a collison system with onCollisionEnter to check if it hits the player and then giving damage to the player. 
The deatheffect of the worms are facilitated by instanciating a different worm model that has been through a cell fracture process in blender to cut it up in 350 pieces with a rigidbody and meshcollider set to convex and when the worm is instantiated at the transform of the previous it falls apart looking like the worm was shot to pieces giving it a cool death effect. 
The player shoots via Raycasting adding a hit effect to the point of where the ray hits at the rotation towards the player so we can see it. If the hitpoint is a enemy it will give damage. The direction of the projectile is also utilizing raycasts.
The Character is a 3D model I found on sketchfab and put through Mixamo’s autorigger to give bones and death animation, the other animations and the playercontroller are from the unity ThirdpersonStarterasset package. 
The terrain is constructed via the unity terrain tools using the terrain tool starter pack.
The water is a imported shader asset I have done minor colur chages to
And the smoke and fire vfx is a imported particle system. 
The Scoreboard is a canvas with textMeshPro obejcts that shows the score, remaing health and shots left and the code is triggered in the respective scripts for shooting and health of enemy and player. 


Project Parts:
•	Scripts:
o	ThirdPersonController: Used to control the character, moving the camera, playing animations and playing footsteps sound
o	BasicRigidBodyPush – used to give gravity to the player via code since we can’t have a charactercontroller and a Rigitbody on the same gameobject. 
o	DeathMenu: Controlling the endmenu when th eplayer dies 
o	EnemyAICombined: Main enemyscript resposible for navmeshpatrolling, attacking, and following the player. 
o	EnemyDamage: Controlling health of the enemy and instiantiating the deathworm Effect
o	HUDManager: Controls and updates the scoreboard.
o	PlayerHealth : Controlling the health of the player 
o	ProjectileMove2: Controls the movement of the projectile
o	RaycastShoot: Controls the shooting mechanism, and effects. 
o	SpawnProjectileEffect: Spawns the projectile effect at the end of the gun. Also stops the spawn when ammo is out. 
o	Spit: Manageing the collison of the spitball and giving damage to the player. 
o	
•	Models & Prefabs:
o	DoomKeen model from sketchfab: https://sketchfab.com/3d-models/commander-keen-doom-26e9da1116b14378b722f8deaf00ee15
o	License https://creativecommons.org/licenses/by/4.0/
	Original artist: https://sketchfab.com/DJ_Nugget
	Changes to the model was made to texture of the gun because non was applied to the original 
	Also a knife on the hand was removed because it conflicted with the autorigging process.
o	Worm, Fish, and spaceship models from skecthfab: https://sketchfab.com/3d-models/commander-keen-ship-enemies-2bfe025c44a5468eb6906bf584f6beff
o	License https://creativecommons.org/licenses/by/4.0/
	Original Artist https://sketchfab.com/Yuihocmwsy
	Changes was made to the worm in order to make the deatheffect
o	Tress and windzone from: https://assetstore.unity.com/packages/3d/vegetation/trees/mountain-trees-dynamic-nature-107004
o	Fire and smoke package
        https://assetstore.unity.com/packages/vfx/particles/fire-explosions/fire-smoke-dynamic-nature-217775
o	Water Shader
        https://assetstore.unity.com/packages/2d/textures-materials/water/simple-water-shader-urp-191449
o	Third person character controller 
        https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526
o	Muzzleflash, Projectile and Hits VFX from kyeoms in unity asset store https://assetstore.unity.com/packages/vfx/particles/stylized-shoot-hit-vol-1-216558

•	Scenes:
o	Game consists of one scene
•	Testing:
o	Game was tested on Mac OSX
