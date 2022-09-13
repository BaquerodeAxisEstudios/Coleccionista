using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItems : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> puntos;
    public float radioForPonit;
    public int cantidadForPoint;
    [ContextMenu("Generar")]
    public void GenerateArray()
    {
        for (int i = 0; i < puntos.Count; i++)
        {
            for (int c = 0; c < cantidadForPoint; c++)
            {
                Vector3 offset = new Vector3(Random.Range(-radioForPonit,radioForPonit), 1.36f, Random.Range(-radioForPonit, radioForPonit));
                Instantiate(prefab, puntos[i].position + offset, prefab.transform.rotation, puntos[i]);
            }
        }
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < puntos.Count; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(puntos[i].position, radioForPonit * Vector3.one * 2);
        }
    }
}