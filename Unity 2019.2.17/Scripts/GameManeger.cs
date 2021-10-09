using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelPause;

    private float masterVolume = 0.2f;

    public static GameManeger instance;

    //verficar se é o unico e não destruir entres as cenas
    private void OnLevelWasLoaded()
    {

        if (instance == null)
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) 
            Destroy(gameObject);  
        instance.StartGame();
    }
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) 
            Destroy(gameObject);
        instance.StartGame();
    }

    //ajustes para o inicio da fase
    private void StartGame()
    {
        GetComponentInChildren<MasterSoundBehaviour>().SetCurrentSlider(GameObject.Find("SliderVolume"));
        GetComponentInChildren<MasterSoundBehaviour>().SetAllVolume();

        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            panelPause = GameObject.Find("PanelPause");
            panelPause.SetActive(false);
            panelWin = GameObject.Find("MenuWin");
            panelWin.SetActive(false);

            //começa tutorial
            GameObject.Find("PanelTutorial").GetComponent<TutorialBehaviour>().StartTutorial();
        }

    }

    //abrir e fehcar menu
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!panelPause.active)
                {
                    GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
                    Time.timeScale = 0;
                    panelPause.SetActive(true);
                }
                else
                {
                    GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
                    if (!GameObject.Find("PanelTutorial").active)
                    {
                        Time.timeScale = 1;
                    }
                    panelPause.SetActive(false);
                }
            }
        }
    }

    // calcular dos altares
    public void Calculate(int num_Player, QuestBehaviour script_quest, int ope)
    {
        int result = 0;
        switch (ope)
        {
            case 0:
                result = num_Player + script_quest.GetNum();
                break;
            case 1:
                result = script_quest.GetNum() - num_Player;
                break;
            case 2:
                result = num_Player * script_quest.GetNum();
                break;
            case 3:
                result = script_quest.GetNum()/num_Player;
                break;
        }

        script_quest.SetNum(result);
        CheckWin();
    }

    //verifica se ganhou
    private void CheckWin()
    {
        int check = 0;
        QuestBehaviour[] allQuest = GameObject.FindObjectsOfType<QuestBehaviour>();
        for (int i = 1; i < allQuest.Length;i++)
        {
            if (allQuest[0].GetNum() == allQuest[i].GetNum())
            {
                check++;
            }
        }
        if (check == 3)
        {
            Win();
        }
        
    }

    //fim do jogo
    private void Win()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(5);
        Time.timeScale = 0;
        panelWin.SetActive(true);
    }

    public void SetMasterVolume(float v)
    {
        masterVolume = v;
    }
    public float GetMasterVolume()
    {
        return masterVolume;
    }
}
