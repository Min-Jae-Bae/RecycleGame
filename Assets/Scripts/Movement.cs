using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    public bool ismove;
    public float speed;
    void Update()
    {
        
    }

    Coroutine cor;
    public void stopmove()
    {
        if(cor!=null)
            StopCoroutine(cor);

    }
    private void OnCollisionEnter(Collision collision)
    {
        move();
    }

    public void move() {
        if (cor == null)
        {
            cor = StartCoroutine(MoveCor());

        }
    }
    IEnumerator MoveCor() {
        yield return null;
        while (true) {
            yield return new WaitForSeconds(Time.deltaTime);
            rbody.velocity = new Vector3(-1, rbody.velocity.y, rbody.velocity.z);
        }
    }
}
