using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayOrQuit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorReplay"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Scene1");
        }
        if (other.CompareTag("DoorQuit"))
        {


#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}
