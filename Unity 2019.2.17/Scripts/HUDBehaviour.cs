using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_NumScore;
    [SerializeField] private TextMeshProUGUI text_Operator;

    //mostrar na hud o valor na bolsa
    public void SetText_NumScore(int num)
    {
        text_NumScore.text = num.ToString();
    }

    //mostrar na hud qual operação está regendo
    public void SetText_Operator(int ope)
    {
        switch (ope)
        {
            case 0:
                text_Operator.text = "+";
                break;
            case 1:
                text_Operator.text = "-";
                break;
            case 2:
                text_Operator.text = "x";
                break;
            case 3:
                text_Operator.text = "/";
                break;
        }
    }
}
