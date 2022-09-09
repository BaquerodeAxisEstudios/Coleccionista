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
    Vector3 mov;

    [Header("Salto")]
    public ForceMode forceModeJump;
    public float forceJump = 4;
    bool isGround;
    public string tagGround = "Suelo";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (mov.magnitude > 0.1f)
        {
            float ang = Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, ang, 0);
        }
    }
    private void FixedUpdate()
    {
        if (!isGround) return;
        mov = mov.normalized;
        if (Input.GetButton("Run"))
        {
            mov *= (velocidad * 2);
        }
        else
        {
            mov *= velocidad;
        }
        //rb.MovePosition(transform.position + mov * Time.fixedDeltaTime);
        rb.velocity = new Vector3(mov.x, rb.velocity.y,mov.z);
        if (Input.GetButtonDown("Jump"))
        {
            isGround = false;
            rb.AddForce(transform.up * forceJump, forceModeJump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagGround))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(tagGround))
        {
            isGround = false;
        }
    }
}
