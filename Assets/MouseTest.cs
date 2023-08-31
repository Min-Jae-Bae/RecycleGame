using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;

        mousepos.z = 10;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousepos);
        
        Debug.Log(pos);
        transform.position = new Vector3(pos.x,pos.z,pos.y);
    }
}
