using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tarjet;
    public Vector3 offset;
    public float distancia = 5;
    public float velRot;
    private void Update()
    {
        Posicionar();
        Rotar();
    }

    private void OnDrawGizmosSelected()
    {
        Posicionar();   
    }
    void Posicionar()
    {
        if (tarjet)
        {
            transform.parent.position = tarjet.position;
            transform.localPosition = new Vector3(0,distancia,-distancia) + offset;
        }
        else
        {
            Debug.LogWarning("Asignar un objetivo a la camara");
        }
    }
    void Rotar()
    {
        float amountY = Input.GetAxis("RotCam") * velRot * Time.deltaTime;
        transform.parent.rotation *= Quaternion.Euler(0,amountY, 0);
    }
}
