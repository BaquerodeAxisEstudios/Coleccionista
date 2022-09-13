using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    public float t, length;
    float yPos;
    public Vector3 velRot;

    public AudioClip clip;
    private void Start()
    {
        yPos = transform.position.y;
    }
    private void Update()
    {
        float posy = Mathf.PingPong(t * Time.time, length);
        transform.position = new Vector3(transform.position.x, yPos + posy, transform.position.z);
        transform.Rotate(velRot * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.Amount(valor);

            AudioSource.PlayClipAtPoint(clip, Vector3.zero, 1f);
            Destroy(gameObject);
        }
    }
}
