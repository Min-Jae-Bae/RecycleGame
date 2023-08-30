using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RecycleObject : MonoBehaviour
{

    //플라스틱인지,종이인지, 쓰레기 종류에 대한 정의가 필요하다.
    public enum ObjectType { 
        None,Paper,Plastic,Can,Glass
    }
    public ObjectType myType;
    //자식이 있는지, 없는지를 기본적으로 정해야한다,


    //누구의 타입인지.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
