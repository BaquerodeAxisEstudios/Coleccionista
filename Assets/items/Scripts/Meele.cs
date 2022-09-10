using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : Gun
{
    public override void Use()
    {
        Strike();
    }

    void Strike()
    {
        
    }
    public override void Tomar()
    {
        throw new System.NotImplementedException();
    }
}
