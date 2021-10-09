using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
   [SerializeField] private EnemyTrapperBehaviour scriptTrapper;

    //ação caso colida com o player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(4);
            other.gameObject.GetComponent<PlayerBehaviour>().IncriseNumScore(-1);
            scriptTrapper.DrecriseNumTrap();
            Destroy(this.gameObject);
        }
    }

    // receber qual inimigo o gerou
    public void SetScript(EnemyTrapperBehaviour script)
    {
        scriptTrapper = script;
    }

}
