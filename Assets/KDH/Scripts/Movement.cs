using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rbody;
    public Collider mycoll;
    // Start is called before the first frame update
    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        mycoll = GetComponent<Collider>();
        rbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    void Start()
    {
        
    }
    public bool ismove;
    public float speed;
    void Update()
    {
        
    }

    Coroutine cor;
    public void stopmove()
    {
        if (cor != null) { 
            StopCoroutine(cor);
            cor = null;
        }
            

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Belt")) {
            move();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Belt"))
        {
            stopmove();
        }
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
            rbody.velocity = new Vector3(1, rbody.velocity.y, rbody.velocity.z);
        }
    }
}
