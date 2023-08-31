using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Movement))]
public class RecycleObject : MonoBehaviour
{
    //����ȿ����
    public AudioClip clip;

    //�ö�ƽ����,��������, ������ ������ ���� ���ǰ� �ʿ��ϴ�.
    public enum ObjectType { 
        Plastic,Paper,Can,Glass,Complex,Last
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
    //�ڽ��� �����ϸ� � ������Ʈ�� ���صɰ�����.
    public List<RecycleObject> childObject = new List<RecycleObject>();
    

    //������ ���� �ٰ�����
    public int add_score = 5;
    //Ʋ������ ������ ���� ���ҽ�ų����.
    public int less_score = 5;
    public Movement movement;
    // Start is called before the first frame update


    //���صǾ����� �������� ���Ұ�����.
    public ObjectType RealType;

    private void Awake()
    {
        //movement.enabled = IsParent;
        //������ �̷��� �ϸ� �ȵǴµ�.. 2�������� ���شϱ� �ڵ����� ����Ʈ ����
        for (int i = 0; i < transform.childCount; i++)
        {

            RecycleObject rec = transform.GetChild(i).GetComponent<RecycleObject>();
            if (rec != null)
            {
                childObject.Add(rec);
            }

        }
    }
    void Start()
    {
        movement = GetComponent<Movement>();
        //�������� ��ü�� �ڽ��� �ڽ��� ��Ȱ��ȭ
        if (myType == ObjectType.Complex && childObject.Count > 0) {
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
        SoundManager.instance.PlaySFX(clip);
        foreach (RecycleObject resobject in childObject) {
            //���� ���ϰ� 
            this.myType = RealType;
            //�ʿ� ���� ��ҵ��� ������ ���´�!
            resobject.transform.parent = null;
            //�׸��� �� ��ҵ��� ���������� �۵��Ѵ�.
            resobject.gameObject.layer = LayerMask.NameToLayer("Parent");
            resobject.movement.rbody.isKinematic = false;
            resobject.movement.enabled = true;
            resobject.movement.rbody.useGravity = true;
            resobject.movement.mycoll.enabled = true;
        }
    }

}
