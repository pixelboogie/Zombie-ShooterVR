using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource source;
    public AudioClip scream;
    private float timeLeft = 2.0f;
    private bool contact = false;

    void Update()
    {
        if (contact == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {

            if (contact == false)
            {
                source.PlayOneShot(scream);
                contact = true;
            }
        }

    }

}