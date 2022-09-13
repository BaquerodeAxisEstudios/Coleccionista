using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float fuerza;
    public ForceMode forceMode;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerza, forceMode);
        Invoke(nameof(Quemar), 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().Kill();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Quemar()
    {
        Destroy(gameObject);
    }
}
