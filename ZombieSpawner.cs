using System;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // The Zombie made public so it can be reached inside the unity editor
    public GameObject zombies;
    //Array of spawn positions made  public so it can be reached inside the unity editor
    public Transform[] spawnPositions;
    //Time passed since startup
    private float timePassed;
    //Gets subtracted att every frame, no new zombies are allowed to be spawn then this value is larger than 0;
    private float pauseSpawn;
    //SPawn speed is used to reset the pause spawn once it hits 0;
    //If you want faster or slower spawning change this value. lower is faster spawning, higher is slower.
    private float spawnSpeed = .5f;

    public float spawnZombies = 2f; //  number of zombies to spawn
    private float zombiesLeft; // number of zombies left to spawn
                               //  Vector3 myVector;
    private int spawnPostion = 0; // which spawn position this next spawn is going to

    private void Start()
    {
        //Set the pauseSpawn field to spawnSpeed.
        pauseSpawn = spawnSpeed;
        zombiesLeft = spawnZombies;
    }

    // Update gets called every frame.
    private void Update()
    {
        //Set Time passed to accual time passed since game started
        timePassed = Time.realtimeSinceStartup;
        //Every 10 seconds Add another zombie to the mix.
        //timepassed is a float, meaning a decimal number like 5,4.
        //We round using math round to get a whole number likte 5
        //then we use the modulus aka the remainder aka % operator to check if time passed divided by 10 has a reminder off 0.
        //We use the pause spawn so that only one zombie is spawned. Otherwise there would be as many as there are frames in one second. (72)

        if (zombiesLeft > 0)
        {

            //   if (Math.Round(timePassed) % 10 == 0 && pauseSpawn < 0)
            if (Math.Round(timePassed) % 10 == 0 && pauseSpawn < 0)
            {
                SpawnNewZombie();
                pauseSpawn = spawnSpeed;
            }
        }

        //0.0138f is the amount subtracted every frame which comes out to 1 per second or (1/72)
        pauseSpawn -= 0.0138f;
    }

    //Method that spawns a new zombie
    void SpawnNewZombie()
    {
        // Since this methot gets called every time a zombie is killed I wanted I slight delay, it will wait between 0 and 4 seconds to spawn a zombie.
        new WaitForSeconds(UnityEngine.Random.Range(0, 5));

        //Here we instantiate a new zombie in a random slot in the array of spawnpositions
        //   GameObject zombie = Instantiate (zombies, spawnPositions[UnityEngine.Random.Range (0, 5)]);
        GameObject zombie = Instantiate(zombies, spawnPositions[spawnPostion]);
        spawnPostion++;
        zombiesLeft--;

        //Place the zombie at the same postition as the parent. the parent in this case is the spawn position.
        zombie.transform.localPosition = Vector3.zero;
    }

}