using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tarjet;
    public Vector3 offset;
    public float distancia = 5;
    private void Update()
    {
        Posicionar();
    }

    private void OnDrawGizmosSelected()
    {
        Posicionar();   
    }
    void Posicionar()
    {
        if (tarjet)
        {
            transform.position = tarjet.position + new Vector3(0,distancia,-distancia) + offset;
        }
        else
        {
            Debug.LogWarning("Asignar un objetivo a la camara");
        }
    }
}
