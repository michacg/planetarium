using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
   
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDir = Vector3.zero;

    [SerializeField] public UnityEvent onInteraction;

    [Header("Player Movement Controls")]
    [SerializeField] public float speed = 4f;
    [SerializeField] public float rotSpeed = 80f;
    [SerializeField] float rot = 0f;
    [SerializeField] public float radarDistance = 1.5f;

    [Header("Player Keybinds")]
    [SerializeField] public KeyCode interaction = KeyCode.Space;



    void Start()
    {
        //m_RigidBody = GetComponent<Rigidbody>;
        controller = GetComponent<CharacterController>();
        anim       = GetComponent<Animator>();
    }

    void Update()
    {
        move();
       // interact();

    }

    void move()
    {

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("walk", 1);
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        else
        {
            anim.SetInteger("walk", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

    private void interact()
    {
        if (Input.GetKeyDown(interaction))    //TODO: delete/replace code with nontesting code
        {
            onInteraction.Invoke();
        }
    }


}
