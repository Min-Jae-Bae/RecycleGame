using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    Vector2 off;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        off += Vector2.left * Time.deltaTime * speed;
        renderer.material.mainTextureOffset = off;
    }
}
