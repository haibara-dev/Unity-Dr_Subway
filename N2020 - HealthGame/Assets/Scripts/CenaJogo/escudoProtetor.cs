using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudoProtetor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meleca")
        {
            Destroy(collision.gameObject);
        }
    }
}
