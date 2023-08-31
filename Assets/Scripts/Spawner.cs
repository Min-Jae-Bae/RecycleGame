using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float spawnTime;
    IEnumerator Spawn()
    {
        while (true) {
            yield return new WaitForSeconds(spawnTime);
            //������ ���� ���ϰ�
            int rand = Random.Range(0, 5 - 1);
            //������ ������Ʈ�� �����ϰ�
            GameObject go = GameObject.CreatePrimitive((PrimitiveType)(rand ));
            go.transform.position = transform.position;
            RecycleObject obj = go.AddComponent<RecycleObject>();
            go.AddComponent<Movement>();
            go.gameObject.layer = LayerMask.NameToLayer("Parent");

            obj.myType = (RecycleObject.ObjectType)(Random.Range(0,(int)(RecycleObject.ObjectType.Last)));
            Color myColor = Color.white ;
            switch (obj.myType) {
                case RecycleObject.ObjectType.Plastic:
                    myColor = Color.red;
                    break;
                case RecycleObject.ObjectType.Can:
                    myColor = Color.green;
                    break;
                case RecycleObject.ObjectType.Glass:
                    myColor = Color.yellow;
                    break;
            }
            go.GetComponent<MeshRenderer>().material.color = myColor;
            //�����Ѱ��� Ÿ���� ������.

        }



    }
}
