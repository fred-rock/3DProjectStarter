![tunguska-logo](https://github.com/fred-rock/3DProjectStarter/assets/4206210/b875326f-bb57-4082-8517-da5b68596f41)
# 3D Starter Project by Tunguska Softworks 

This is intended as a starter project for my 3D games. It's not really intended to be an API, or and importable package. In its current state, it's a collection of modular systems to help reduce the time putting together a prototype or starting a larger game project. Right now, the priority is building features for FPP (first person perspective) games with retro inspiration, like boomer shooters, classic Bethesda-style RPGs, old-school immersive sims, and horror walking simulators.

### Input
* This project uses the new Unity input system. Keybindings are defined by an action map in an input action asset. 
* The PlayerInputModule centralizes the actions from the action map, and makes the input values available to other player modules.
* Actions like movement, jumping, and firing weapons are accomplished by called the respective functions from a player state, passing in data from the input module.

### Player
* Player class is a state machine which initializes a bunch of modules which implement the IPlayerModule interface.
* Player states mostly determine which module functions can be called by player input. E.g. While in a PlayerCombatState, the player can utilize movement, jumping, firing weapons, etc. from their respective modules, while in PlayerSpawnState, the player cannot move, jump, or fire until transitioning into PlayerCombatState.
* Most of the settings on player modules are set by a PlayerData scriptable object. The main exceptions are weapon modules, which are set by WeaponData scriptable objects.

### Enemy
* Enemy class is a state machine which initializes a bunch of modules which implement the IEnemyModule interface.
* Enemy states define simple AI behaviors, like wandering, pursuing, and attacking with ranged or melee.
* Pathfinding is handled by navmesh, and enemies are navmesh agents.
* Enemy settings are configured by an EnemyData scriptable object.

### Weapons
* Weapons are player modules which inherit from the BaseWeaponModule class.
* There are currently modules for designing hitscan and projectile-based weapon types.
* Settings are configured by scriptable object, and there are scriptable object classes for each weapon type. However, settings for the fired projectile of a projectile-based weapon are defined on the projectile itself, using the ProjectileData scriptable object.
* The PlayerWeaponContainerModule can house up to 9 weapons, and has multiple methods for switching weapons to support different needs.

### Scene Management
* SingletonManager is the only singleton, but can carry along with it other managers as children.
* GameManager is intended to monitor overall game progress by keeping track of event flags, and have game functions like e.g. Start, Load, Quit.
* LevelManager is meant to be a base class, and each level scene should have its own. It's mostly for keeping track of level events, such as keys found and which enemies are activated.
* ObjectPool is a component for the LevelManager. Right now it just pools projectiles.

### Coming soon
* UI tools like a HUD, main menu, and level completion summary like in classic shooters.
* Breakable objects like crates and glass.
* Interactables, particularly doors and switches.
* Explosions for rockets and barrels.
* More options for player weapons, like sustained fire, charged shots, melee.
