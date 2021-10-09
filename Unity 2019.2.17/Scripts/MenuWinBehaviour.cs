using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinBehaviour : MonoBehaviour
{
    public void Retry()
    {
        ClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        ClickSound();
        SceneManager.LoadScene("Main Menu");
    }

    private void ClickSound()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
    }
}

