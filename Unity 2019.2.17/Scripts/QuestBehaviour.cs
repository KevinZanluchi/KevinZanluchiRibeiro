using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int num;
    private void Awake()
    {
        ChangeText(num);
    }

    //mudança do valor no text
    private void ChangeText(int num)
    {
        text.text = num.ToString();
    }

    public int GetNum()
    {
        return num;
    }
    
    public void SetNum(int currentNum)
    {
        num = currentNum;
        ChangeText(num);
    }
}
