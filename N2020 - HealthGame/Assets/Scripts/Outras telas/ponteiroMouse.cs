using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponteiroMouse : MonoBehaviour
{
   

    private Vector3 target;

    void Start()
    {
        Cursor.visible = false;
    }

   
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = new Vector3(target.x, target.y, -9);
    }

}
