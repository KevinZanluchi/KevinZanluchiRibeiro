using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] pathWays;

    [SerializeField] protected NavMeshAgent agent;
    public enum State_Machine { Walk, Attack }
    public State_Machine state;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(State_Machine.Walk);
    }

    //ao chegar perto do destino muda para outro
    public virtual void Update()
    {
        if (state == State_Machine.Walk)
        {
            if (Vector3.Distance(transform.position, agent.destination) < 3)
            {
                Path();
            }
        }
    }

    // direcionar para as ações do seu estado atual
    protected void ChangeState(State_Machine newState)
    {
        state = newState;
        switch (state)
        {
            case State_Machine.Walk:
                Path();
                break;
            case State_Machine.Attack:
                Attack();
                break;
        }
    }

    // ação de rounda
    private void Path()
    {
        agent.destination = RandomPath();
    }

    //escolhe aleatoriamente um destino
    private Vector3 RandomPath()
    {
        int i = Random.Range(0, pathWays.Length);
        return pathWays[i].position;
    }

    // ação de ataque
    public virtual void Attack()
    {

    }
}
