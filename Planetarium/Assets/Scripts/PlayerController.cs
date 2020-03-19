using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
   
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDir = Vector3.zero;

    // [SerializeField] public UnityEvent onInteraction;

    [Header("Player Movement Controls")]
    [SerializeField] public float speed = 4f;
    [SerializeField] public float rotSpeed = 80f;
    [SerializeField] float rot = 0f;
    [SerializeField] public float radarDistance = 1.5f;

    [Header("Player Keybinds")]
    [SerializeField] public KeyCode interactionKey = KeyCode.Space;

    private bool isSitting;

    void Start()
    {
        //m_RigidBody = GetComponent<Rigidbody>;
        isSitting = false;
        controller = GetComponent<CharacterController>();
        anim       = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetInteger("sit") == 1)
            SitUpdate();
        else
            move();
    }

    void SitUpdate()
    {
        if (Input.GetAxis("Vertical") != 0 && anim.GetInteger("sit") == 1)
        {
            anim.SetInteger("sit", 0);
            anim.SetInteger("walk", 1);
        }

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

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("chair"))
        {
            print("chair");

            if (Input.GetKey(interactionKey) && anim.GetInteger("sit") == 0)
            {
                transform.position = other.transform.position;
                transform.rotation = other.transform.rotation;

                print("sit");
                anim.SetInteger("sit", 1);

            }
            
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("chair"))
    //    {
    //        anim.SetInteger("sit", 0);
    //    }
    //}


}
