# Zombie-ShooterVR

## Description
**Zombie-ShooterVR** is a fully playable zombie survival mini-game designed for Virtual Reality (VR) environments. The game immerses players in a fast-paced survival scenario where they must fend off waves of zombies using various weapons. Built in Unity with the Oculus Integration package, this game is optimized for the Oculus Rift S on the Windows platform.

Please note that this repository contains only the C# scripts; Unity project files are not included. However, the provided code covers essential aspects of the game, such as gun mechanics, zombie AI, 3D model animations, sound effects, and other game logic details.

## Features
- **VR Environment**: Fully immersive gameplay designed for VR using the Oculus Rift S.
- **Multiple Levels**: Various levels with increasing difficulty.
- **3D Model Animation**: Includes animations for zombie movement, attacking, and dying.
- **Dynamic Game Objects**: Interactive game objects such as weapons and zombies.
- **Survival Mechanics**: Players must shoot zombies to survive, with gameplay mechanics such as ammo management and health.
- **Sound Effects**: Immersive sound design to enhance the gaming experience.

## Installation
To use the C# scripts in your own Unity project, follow these steps:

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/Zombie-ShooterVR.git

   cd Zombie-ShooterVR

2. **Integrate into Unity:**

    - Open your existing Unity project or create a new one.
    - Copy the C# scripts from this repository into your project's Assets/Scripts directory.

3. **Set Up the Scene:**

    - Import the necessary 3D models, textures, and animations.
    - Set up your VR environment using the Oculus Integration package.
    - Assign the scripts to the appropriate game objects, such as the player’s weapon and the zombies.

4. **Configure the Build Settings:**

    - Ensure that the platform is set to Windows (or Android if targeting Oculus Quest).
    - Adjust player settings and API levels as needed for your VR device.

5. **Run and Test the Game:**

    - Use the Unity Editor to test the game, or build and deploy it to your Oculus device for full VR gameplay.

## Example Code

Here is an example snippet from the Zombie.cs script, which handles zombie behavior:

    public void KillZombie() {
    GetComponent<Animator>().enabled = false; // Stop animation
    Ragdoll(false); // Apply physics to the zombie's body parts
    foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>()) {
        rb.AddExplosionForce(500f, transform.position, 1f); // Simulate death force
    }
    this.enabled = false; // Disable further behavior
}

    private void Ragdoll(bool state) {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>()) {
            rb.isKinematic = !state; // Toggle physics
        }
    }

This function handles the process of "killing" a zombie, including disabling animations and applying ragdoll physics to create a realistic death effect.

## Video Tutorial
Shout out to mrPCoding - his video tutorial, helped out a lot. You can view it here: 
[ZOMBIE VR GAME](https://www.youtube.com/watch?v=Vzzc7BHLs08).

## License
This project is licensed under the MIT License. See the LICENSE file for more information.
