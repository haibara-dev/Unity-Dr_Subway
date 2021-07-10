using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMask : MonoBehaviour
{
    // Para destruir os objetos na cena depois de um tempo
    IEnumerator EraseBullet()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(EraseBullet());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Mascarado")
        {
            Destroy(gameObject);
        }
    }

}
