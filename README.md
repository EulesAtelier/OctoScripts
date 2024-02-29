# OctoScripts
## These C# scripts are part of a stealth game where you play as an octopus in an aquarium.
### Octo:
 - *Items*
    1. ***GrabbableItem.cs*** - Handles communication between an object and OctopusController and allows it to be held.
        2. **fishScript.cs** - Alters the GrabbableItem onTriggerEnter2D function to allow the script to communicate with a UI text element, and to destroy the gameObject in the case that the fish is "eaten".
        3. **rockScript.cs** - Contains a value that the OctopusController will use to apply a force to the script's gameObject. Alters the GrabbableItem onTriggerEnter2D function to allow the script to destroy specified types of gameObjects or start a coroutine that alters the Guard gameObject and GaurdAI.cs.
    2. **FlashlightLook.cs** - in the case that a flashlight gameObject with the attached GrabbableItem.cs script being held by the player, change the rotation of the flashlight to look at the cursor.
 1. **FixedCamera.cs** - dynamically lerps the camera to follow the a gameObject(in this case the Octopus Player's) transform.
 2. **Tentacle.cs & TenticleTest.cs** - handle rendering the line for the tentacle
 3. **TentacleInfo.cs** - Contains nessacary info related to the Tentacle gameObject for other Scripts to access.
 4. ***OctopusController.cs*** - Master controller script for the player octopus. Takes user inputs, communicates with almost every other script.
 5. **thoughtDisplayScript.cs** - Handlers the displaying of GameObjects for the thought bubbles, which give the player abstract information.
### LevelScripts:
1. ***endLevelMaster.cs*** - empty main class for future use.
    1. **endLevelLocation.cs** - Contains a bool for other scripts to access that allows the SceneChanger script to change scenes to end a level.
2. **(levelID)LevelScript.cs** - Handles the end conditions for a level and needed visual elements such as particles.
3. **SceneChange.cs** - A utility Script for changing Scenes.
### Gaurds:
1. **GaurdAI.cs** - Handles use of Navmesh agent, detecting the player, graphical changes, and 2D rotation.
2. ~communicationScript.cs~ - defunct script
3. **detectionScript.cs** - Handles the detection of the player and communicates with GaurdAI.cs.
4. ~leavingLOS.cs~ - defunct
5. **CatchingScript.cs** - Handles game overs