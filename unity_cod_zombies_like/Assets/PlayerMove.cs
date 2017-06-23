using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{

    PlayerController controller;
    float secondsLeft;
    bool isJumping = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && controller.IsGrounded)
        {
            GetComponent<Rigidbody>().AddForce(controller.jumpForce * Vector3.up, ForceMode.Impulse);
        }


        
        if (Input.GetButton("Forward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward, ForceMode.Acceleration);

        }
        /*
         * Cette partie bug car le GetButtonDown est bloquant et ducoup l'objet redescent par a coups lors des sauts (atterissage)
         * De meme lorsque que je faisais : bool isMovingForward = Input.GetAxis("Vertical") > 0;
         * 
        if (Input.GetButtonDown("Forward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward, ForceMode.Acceleration);

        }
        else if (Input.GetButtonDown("Backward"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.forward * (-1f), ForceMode.Force);
        }
        else if (Input.GetButtonDown("Right"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right, ForceMode.Force);
        }
        else if (Input.GetButtonDown("Left"))
        {
            controller.IsMoving = true;
            GetComponent<Rigidbody>().AddForce(controller.speed * transform.right * (-1f), ForceMode.Force);
        }
        else
        {
            controller.IsMoving = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        */

    }

    public void Initialize(PlayerController controller)
    {
        this.controller = controller;
    }
}
