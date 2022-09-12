using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guardian : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform destino;
    public Transform[] routePoints;
    int actualPointDes;
    public float velocidad = 5;
    
    [Header("Player settings")]
    Transform player;
    public float distanDetection;

    [Header("Weapon Settings")]
    public Transform spawnPointBullet;
    public GameObject bulletPrefab;
    public LayerMask visibleGuardianLayers;
    public float distanDisparo;
    public float frecuanciaDisparo = 5;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = velocidad;
    }

    Ray ray;
    private void Update()
    {
        if (destino)
        {
            navMeshAgent.SetDestination(destino.position);
        }

        ray = new Ray(transform.position, (player.position-transform.position).normalized);
        if (Physics.Raycast(ray,out RaycastHit hit,distanDetection,visibleGuardianLayers))
        {
            if (hit.collider.CompareTag("Player"))
            {
                destino = player;
                if (Vector3.Distance(transform.position, player.position) < distanDisparo)
                {
                    if(!IsInvoking(nameof(Shoot)))
                        InvokeRepeating(nameof(Shoot), 0, frecuanciaDisparo);
                }
                else
                {
                    CancelInvoke(nameof(Shoot));
                }
            }
            else
            {
                ChangePoint();
            }
            
        }
        else
        {
            ChangePoint();
        }
    }
    public void ChangePoint()
    {
        CancelInvoke(nameof(Shoot));
        float dis = Vector3.Distance(transform.position, destino.position);
        if (dis < velocidad && destino != null)
        {
            actualPointDes = Random.Range(0,routePoints.Length);
            destino = null;
        }
        if (destino == null || destino == player)
        {
            destino = routePoints[actualPointDes];
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, spawnPointBullet.position, spawnPointBullet.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}