using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RecycleObject : MonoBehaviour
{

    //�ö�ƽ����,��������, ������ ������ ���� ���ǰ� �ʿ��ϴ�.
    public enum ObjectType { 
        None,Paper,Plastic,Can,Glass
    }
    public ObjectType myType;
    //�ڽ��� �ִ���, �������� �⺻������ ���ؾ��Ѵ�,


    //������ Ÿ������.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
