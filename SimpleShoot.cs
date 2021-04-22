using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleShoot : MonoBehaviour {

      public AudioSource source;
      public AudioClip shot;

      public GameObject bulletPrefab;
      public GameObject casingPrefab;
      public GameObject muzzleFlashPrefab;
      public Transform barrelLocation;
      public Transform casingExitLocation;

      public float shotPower = 100f;

      private float hitCount = 0f;

      //  public float spawnZombies = 5; // number of zombies during dev

      private float timeLeft = 3.0f; // time to remain in scene before we go to next level

      private float spawnZombies;  // total number of zombies to spawn from zombiespanwer
      private float zombiesLeft; // number of zombies left to spawn

      //     public GameObject levelCaller; 
      private int levelIndex;

      void Start () {
            if (barrelLocation == null) {
                  barrelLocation = transform;
            }

            GameObject go = GameObject.Find ("ZombieSpawner");
            ZombieSpawner cs = go.GetComponent<ZombieSpawner> ();
            spawnZombies = cs.spawnZombies;
            zombiesLeft = spawnZombies;

      }

      void Update () {
            if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)) {
                  GetComponent<Animator> ().SetTrigger ("Fire");
                  source.PlayOneShot (shot);
            }

            if (hitCount >= (spawnZombies)) {
                  timeLeft -= Time.deltaTime;
                  if (timeLeft < 0) {
                        levelIndex = SceneManager.GetActiveScene ().buildIndex + 1;
                        SceneManager.LoadScene (levelIndex);
                  }
            }
      }

      void Shoot () {
            GameObject tempFlash;
            Instantiate (bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody> ().AddForce (barrelLocation.forward * shotPower);
            tempFlash = Instantiate (muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            RaycastHit hitLocationInfo;
            bool hit = Physics.Raycast (barrelLocation.position, barrelLocation.forward, out hitLocationInfo, 150);
            var tagOfHitPoint = hitLocationInfo.rigidbody?.tag;
            if (hit && tagOfHitPoint == "Zombie") {
                  hitCount++;
                  zombiesLeft--;

                  hitLocationInfo.collider.SendMessageUpwards ("KillZombie", hitLocationInfo, SendMessageOptions.DontRequireReceiver);
            }
      }

      void CasingRelease () {
            GameObject casing;
            casing = Instantiate (casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
            casing.GetComponent<Rigidbody> ().AddExplosionForce (550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
            casing.GetComponent<Rigidbody> ().AddTorque (new Vector3 (0, Random.Range (100f, 500f), Random.Range (10f, 1000f)), ForceMode.Impulse);
      }

}