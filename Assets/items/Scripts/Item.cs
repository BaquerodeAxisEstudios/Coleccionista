using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemInfo info;
    public GameObject go;

    public abstract void Use();
    public abstract void Tomar();
}
