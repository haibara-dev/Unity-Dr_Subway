using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelecaBullet : MonoBehaviour
{

    IEnumerator EraseBullet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(EraseBullet());
    }
    
}
