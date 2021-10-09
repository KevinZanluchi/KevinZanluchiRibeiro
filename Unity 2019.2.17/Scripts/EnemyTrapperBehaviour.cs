using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrapperBehaviour : EnemyBehaviour
{

    [SerializeField] private GameObject prefabTrap;
    [SerializeField] private int maxNumTrap;
    private int numTrap;

    private float time;

    private void Start()
    {
        time = 0;
    }

    //em certa quantidade de tempo cria uma armadilha e checa se tem o número limite de armadilhas no mapa
    public override void Update()
    {
        base.Update();
        if (!CheckNumTrap())
        {
            time += Time.deltaTime;

            if (time >= 5)
            {
                ChangeState(State_Machine.Attack);
                time = 0;
            }
        }

    }

    //cria as armadilhas
    public override void Attack()
    {
        numTrap++;
        base.Attack();
        GameObject aux; 
        aux = Instantiate(prefabTrap,transform.position, Quaternion.identity);
        aux.GetComponent<TrapBehaviour>().SetScript(this);
        ChangeState(State_Machine.Walk);
    }

    // verifica se pode criar mais armadilha
    private bool CheckNumTrap()
    {
        if (numTrap == maxNumTrap)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //diminue o número de armadilhas existentes no mapa
    public void DrecriseNumTrap()
    {
        numTrap--;
    }
}
