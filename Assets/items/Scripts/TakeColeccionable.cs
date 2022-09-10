using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeColeccionable : Coleccionable
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvasManager.instance.ShowPress();
            if (Input.GetButtonDown("Submit"))
            {
                print("tomar");
                Tomar();
            }
        }
        else
        {
            CanvasManager.instance.DontShowPress();
        }
    }
    public override void Tomar()
    {
        print("tomar");
        ScoreManager.instance.Amount(((ColeccionableInfo)info).valor);
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
