using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialBehaviour : MonoBehaviour
{
    [SerializeField] private string[] textTutoriais;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform[] cameraPosition;
    [SerializeField] private GameObject[] groupbButtons;

    private int count = -1;

    //iniciar tutorial
    public void StartTutorial()
    {
        Time.timeScale = 0;
        NextTutorial();
    }

    private void Update()
    {
        MoveCamera(count);
    }

    //próxima página do tutorial
    public void NextTutorial()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
        count++;
        if (count == textTutoriais.Length -1)
        {
            ChangeButtons();
        }
        text.text = textTutoriais[count];
    }

    //movimentação e trocar posição da camera
    private void MoveCamera(int c)
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position,cameraPosition[c].position, 2f);
    }

    //alteração de botões na última página do tutorial
    private void ChangeButtons()
    {
        groupbButtons[0].SetActive(false);
        groupbButtons[1].SetActive(true);
    }

    //botão de pular e iniciar o game
    public void EndTutorial()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(2);
        mainCamera.transform.position = cameraPosition[0].position;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
