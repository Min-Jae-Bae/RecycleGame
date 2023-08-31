using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Movement))]
public class RecycleObject : MonoBehaviour
{
    
    //�ö�ƽ����,��������, ������ ������ ���� ���ǰ� �ʿ��ϴ�.
    public enum ObjectType { 
        Plastic,Can,Glass,Complex,Last
    }
    public ObjectType myType;
    //�ڽ��� �ִ���, �������� �⺻������ ���ؾ��Ѵ�,


    //������ Ÿ������.

    //���� ���� � ��������.
    public enum ObjectState { 
        Default,Click,Move
    }
    public ObjectState myState;

    public ObjectState STATE
    {
        set {

            myState = value;
            switch (myState)
            {
                case ObjectState.Click:
                    
                    movement.stopmove();
                    movement.rbody.isKinematic = true;
                    break;
                case ObjectState.Move:
                    movement.move();
                    break;

            }
        }
    
    }

    //������ ���� �ٰ�����
    public int add_score = 5;
    //Ʋ������ ������ ���� ���ҽ�ų����.
    public int less_score = 5;
    public Movement movement;
    // Start is called before the first frame update

    //�ڽ��� �����ϸ� � ������Ʈ�� ���صɰ�����.
    public RecycleObject[] childObject;

    private void Awake()
    {
        //movement.enabled = IsParent;

    }
    void Start()
    {
        movement = GetComponent<Movement>();
        if (myType == ObjectType.Complex && childObject.Length > 0) {
            foreach (RecycleObject resobject in childObject)
            {
                resobject.movement.rbody.isKinematic = true;
                resobject.movement.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�������� ������ �θ�,�ڽ� �������� �����Ǿ��ִ�.
    //�����⸦ �и��Ѵٴ� �ǹ̴� �ٽø��� �θ� ������ �ʴ´ٴ°�.
    public void NoParent() {
        
    }
    //���� �θ�κ��� �����鼭 �ڽ��� ���������� �ٽ� ��ȣ�ۿ���.
    //�� ������ٵ�� MoveMent�� Ȱ��ȭ ��Ű�°�.

    //���� ��ư�� ��������, ���� �ʸ� �����ϰڴ�.
    public void res() {
        //�ʴ� ���� ��ҵ��� �˰��ִ�.
        foreach (RecycleObject resobject in childObject) {
            //�ʿ� ���� ��ҵ��� ������ ���´�!
            resobject.transform.parent = null;
            //�׸��� �� ��ҵ��� ���������� �۵��Ѵ�.
            resobject.gameObject.layer = LayerMask.NameToLayer("Parent");
            resobject.movement.rbody.isKinematic = false;
            movement.enabled = true;
            movement.rbody.useGravity = true;

        }
    }

}
