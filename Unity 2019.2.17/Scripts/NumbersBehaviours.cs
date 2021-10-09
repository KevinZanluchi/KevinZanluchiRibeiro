using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumbersBehaviours : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private TextMeshProUGUI numberText;

    //set e mudar text dos números
    public void SetNumber(int num)
    {
        number = num;
        numberText.text = num.ToString();
    }

    //caso o player colida
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(1);
            other.gameObject.GetComponent<PlayerBehaviour>().IncriseNumScore(number);
            Destroy(this.gameObject);
        }
    }
}
