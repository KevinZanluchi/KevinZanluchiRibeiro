using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public void Play()
    {
        SoundClick();
        SceneManager.LoadScene("Game 1");
    }

    public void SoundClick()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
    }
}
