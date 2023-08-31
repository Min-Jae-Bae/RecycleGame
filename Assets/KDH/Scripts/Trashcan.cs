using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    //� ������ ������������.
    public RecycleObject.ObjectType TrashType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�����Ⱑ ���ö� 
        RecycleObject obj = other.GetComponent<RecycleObject>();
        obj = obj.enabled ? obj : null;
        if (!obj)
            return;
        //�´� �������뿡 �־���?
        if (TrashType == obj.myType)
        {
            Debug.Log("�� ����");
            ScoreManager.instance.SCORE+= obj.add_score;
        }
        else {
            Debug.Log("�� Ʋ��");
            ScoreManager.instance.SCORE -= obj.less_score;
        }
        Destroy(other.gameObject);
    }
}
