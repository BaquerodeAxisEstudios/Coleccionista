using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 1;
    public ForceMode forceModeMove;
    [HideInInspector] public Vector3 mov;

    [Header("Salto")]
    public ForceMode forceModeJump;
    public float forceJump = 4;
    bool isGround;
    public string tagGround = "Suelo";

    internal void Kill()
    {
        CanvasManager.instance.KillPlayer();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (mov.magnitude > 0.1f && !pickUp && isGround)
        {
            float ang = Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, ang, 0);
        }
    }
    private void FixedUpdate()
    {
        if (!isGround || pickUp)
        {
            return;
        }
        animator.transform.position = new Vector3(animator.transform.position.x, 0, animator.transform.position.z);
        mov = mov.normalized;
        if (Input.GetButton("Run"))
        {
            mov *= (velocidad * 2);
        }
        else
        {
            mov *= velocidad;
        }
        animator.SetFloat("Velocidad", mov.magnitude / velocidad);


        //rb.MovePosition(transform.position + mov * Time.fixedDeltaTime);
        rb.velocity = new Vector3(mov.x, rb.velocity.y,mov.z);
        if (Input.GetButtonDown("Jump"))
        {
            isGround = false;
            rb.AddForce(transform.up * forceJump, forceModeJump);
            animator.SetBool("Jump",true);
        }
        
    }
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagGround))
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(tagGround))
        {
            isGround = false;
        }
    }

    public bool pickUp;
    public void AnimPickUp(bool or)
    {
        animator.SetBool("PickUp",or);
        pickUp = or;
    }
}
