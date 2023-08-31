using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//의존성
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Movement))]
public class RecycleObject : MonoBehaviour
{
    //분해효과음
    public AudioClip clip;

    //플라스틱인지,종이인지, 쓰레기 종류에 대한 정의가 필요하다.
    public enum ObjectType { 
        Plastic,Paper,Can,Glass,Complex,Landfill,Last
    }
    public ObjectType myType;
    //자식이 있는지, 없는지를 기본적으로 정해야한다,


    //누구의 타입인지.

    //내가 지금 어떤 상태인지.
    public enum ObjectState { 
        Default,Click,Move
    }
    public ObjectState myState;

    public string WarningText;
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
    //자신을 분해하면 어떤 오브젝트로 분해될것인지.
    public List<RecycleObject> childObject = new List<RecycleObject>();
    

    //점수를 몇점 줄것인지
    public int add_score = 5;
    //틀렸을때 점수를 몇점 감소시킬건지.
    public int less_score = 5;
    public Movement movement;
    // Start is called before the first frame update


    //분해되었을때 무엇으로 변할것인지.
    public ObjectType RealType;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        //movement.enabled = IsParent;
        //원래는 이렇게 하면 안되는디.. 2차까지만 분해니까 자동으로 리스트 주입
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
        
        //복합적인 물체는 자신의 자식을 비활성화
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

    //쓰레기의 구조는 부모,자식 계층으로 구성되어있다.
    //쓰레기를 분리한다는 의미는 다시말해 부모를 가지지 않는다는것.
    public void NoParent() {
        
    }
    //또한 부모로부터 나오면서 자신은 독립적으로 다시 상호작용함.
    //즉 리지드바디와 MoveMent를 활성화 시키는것.

    //분해 버튼을 눌렀을때, 나는 너를 분해하겠다.
    public void res() {
        //너는 너의 요소들을 알고있다.
        SoundManager.instance.PlaySFX(clip);
        foreach (RecycleObject resobject in childObject) {
            //나도 변하고 
            this.myType = RealType;
            //너와 너의 요소들의 연결을 끊는다!
            resobject.transform.parent = null;
            //그리고 그 요소들은 독립적으로 작동한다.
            resobject.gameObject.layer = LayerMask.NameToLayer("Parent");
            resobject.movement.rbody.isKinematic = false;
            resobject.movement.enabled = true;
            resobject.movement.rbody.useGravity = true;
            resobject.movement.mycoll.enabled = true;
        }
    }

}
