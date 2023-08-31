using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    //어떤 종류의 쓰레기통인지.
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
        //쓰레기가 들어올때 
        RecycleObject obj = other.GetComponent<RecycleObject>();
        obj = obj.enabled ? obj : null;
        if (!obj)
            return;
        //맞는 쓰레기통에 넣었니?
        if (TrashType == obj.myType)
        {
            Debug.Log("너 맞음");
            ScoreManager.instance.SCORE+= obj.add_score;
        }
        else {
            Debug.Log("너 틀림");
            ScoreManager.instance.SCORE -= obj.less_score;
        }
        Destroy(other.gameObject);
    }
}
