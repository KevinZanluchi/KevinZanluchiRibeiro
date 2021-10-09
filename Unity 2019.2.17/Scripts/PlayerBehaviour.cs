using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6;

    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float originalStepOffset;

    [SerializeField] private int numScore = 0;
    [SerializeField] private int operators = 0;

    [SerializeField] private HUDBehaviour scriptHud;


    // troca de operadores
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SetOperators(0);
        }
        else if (Input.GetKeyDown("2"))
        {
            SetOperators(1);
        }
        else if (Input.GetKeyDown("3"))
        {
            SetOperators(2);
        }
        else if (Input.GetKeyDown("4"))
        {
            SetOperators(3);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    // movimentação e pulo
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(x, 0, z);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        gravity += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            controller.stepOffset = originalStepOffset;
            gravity = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }

        Vector3 move = movementDirection * magnitude;
        move.y = gravity;

        controller.Move(move * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }

    // interação com o altar
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Quest")
        {
            if (numScore != 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.Find("MasterSound").GetComponent<MasterSoundBehaviour>().PlaySound(3);
                    GameObject.Find("GameManeger").GetComponent<GameManeger>().Calculate(numScore,other.gameObject.GetComponent<QuestBehaviour>(),operators);
                    ClearNumScore();
                }
            }
        }
    }

    // adição dos números na bolsa
    public void IncriseNumScore(int num)
    {
        numScore += num;
        scriptHud.SetText_NumScore(numScore);
    }

    //zerar a bolsa
    public void ClearNumScore()
    {
        numScore = 0;
        scriptHud.SetText_NumScore(numScore);
    }

    private void SetOperators(int ope)
    {
        operators = ope;
        scriptHud.SetText_Operator(operators);
    }

    public int GetNumScore()
    {
        return numScore;
    }
}
