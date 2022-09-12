using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeColeccionable : Coleccionable
{
    CharacterController cc;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cc = other.GetComponent<CharacterController>();
            CanvasManager.instance.ShowPress();
            if (Input.GetButtonDown("Submit") && cc.mov.sqrMagnitude <= 0.1)
            {
                Tomar();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvasManager.instance.DontShowPress();
            cc = null;
        }
    }
    public override void Tomar()
    {
        print("tomar");
        cc.AnimPickUp(true);
        Invoke(nameof(Destruir),10);
        CanvasManager.instance.DontShowPress();
        ScoreManager.instance.Amount(((ColeccionableInfo)info).valor);
        GetComponent<Collider>().enabled = false;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
    void Destruir()
    {
        cc.AnimPickUp(false);
        Destroy(gameObject);
    }
}
