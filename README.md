![tunguska-logo](https://github.com/fred-rock/3DProjectStarter/assets/4206210/b875326f-bb57-4082-8517-da5b68596f41)
# 3D Starter Project by Tunguska Softworks 
![goodScreenshot](https://github.com/fred-rock/3DProjectStarter/assets/4206210/c1d15907-6933-4bdd-8d2c-7288c1bd8b36)

This project is a framework for making small 3D games using a first person perspective. It is best suited for games with a retro inspiration, like boomer shooters, classic Bethesda-style RPGs, old-school immersive sims, and horror walking simulators. This is still in development so many features aren't fully implemented or tested yet. But if you want to try it out now, you are welcome. If you have any suggestions, please feel free to send them to me.

## Installation and setup
1. Clone the repo into a folder of your choosing
2. Add the project in Unity Hub
3. Open the project and start creating

## Features
#### Player modules
* Modules for movement, looking, input, spawning, ground checks, health, ammo, FX, hitboxes, hitscan weapons, and projectile weapons.
* Most modules work independently of one another. E.g. you can build a player which can move but not shoot, or shoot but not move.
* Player objects are configured by scriptable object for convenience and ease of use.
* The main Player class is a state machine. Player states call the functionality in the modules.
* Player states are where unique gameplay is defined, so modify them and create new ones according to your needs. The player states that currently exist in the project are built around the use case of "boomer shooter."

#### Enemy modules
* Modules for movement, spawning, detecting, playing animations, health, hitboxes, FX, ranged attacks, and melee attack.
* Enemy objects are configured by scriptable object.
* The Enemy class is a state machine which handles simple enemy AI. Enemies can wander, patrol, pursue a target, attack from a ranged or melee distance, and flinch when hit.

#### Input
* The project utilizes Unity's "new" input system, and includes an action map for first person shooter controls.
* Input is centralized into the player input module.

#### Weapons
* Weapons are player modules based on typical weapon types, e.g. hitscan, projectile (and more coming soon!)
* Weapon details, such as fire rate, damage, splash damage radius, ammo type and usage rate, sound effects, etc. are all configured by scriptable object.
* The weapon container module is used for building a player character which needs to switch between multiple weapons.
* Projectiles are prefabs which can be pooled, and their details like damage and splash radius are set on demand.

#### Utilities and Managers
* SFX Player can play sound effects when you want to limit the audio sources in a scene.
* Object Pool allows for pooling of projectiles in a scene.
* Singleton Manager is the only singleton, and doesn't do anything on its own. However, you can attach other managers to it if you want to employ a singleton.

#### Pickups
* Health pickups increase health. Ammo pickups increase ammo.
* The Base Pickup class can be extended to build pickups for whatever you need.

## In progress
* Game Manager keeps track of progression events, options and settings, etc. (NOT YET IMPLEMETED)
* Level Manager keeps track of level events, like keys found and doors opened. (NOT YET IMPLEMEMTED)
* HUD prefab displays ammo and health, an aiming reticle, elements to show hit feedback, etc. and is loosely coupled with the Player class.
* Game Menu handles game start, load, setting options, etc. and is loosely coupled with the Game Manager. (NOT YET IMPLEMENTED)

## Future features and updates
* Damageable items like exploding barrels and smashable crates
* Interactables like doors and switches
* Better systems for creating Enemy AI
* Scriptable object-based event system
* Better tools for handling animation
