using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunterBehaviour : EnemyBehaviour
{

    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    //verifica qual estado está
    public override void Update()
    {
        base.Update();
        switch (state)
        {
            case State_Machine.Walk:
                //caso chegue perto do player começa a perseguição, caso não a bolsa esteja zerada ele não persegue
                if (player.gameObject.GetComponent<PlayerBehaviour>().GetNumScore() != 0)
                {
                    if (Vector3.Distance(transform.position, player.position) < 7)
                    {
                        ChangeState(State_Machine.Attack);
                        agent.speed = 4;
                    }
                }
                break;
            case State_Machine.Attack:
                Attack();
                //case se distancie do player volta para a ronda
                if (Vector3.Distance(transform.position, player.position) > 8)
                {
                    agent.speed = 3.5f;
                    ChangeState(State_Machine.Walk);
                }
                break;
        }
    }

    // rouba todo o valor na bolsa
    private void Steal()
    {
        GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(4);
        player.gameObject.GetComponent<PlayerBehaviour>().ClearNumScore();
        ChangeState(State_Machine.Walk);
    }

    // persegue o player e verifica se chegou perto o bastante para roubar
    public override void Attack()
    {
        base.Attack();
        agent.destination = player.position;

        if (Vector3.Distance(transform.position, player.position) < 1)
        {
            Steal();
        }
    }
}
