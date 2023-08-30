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
            int rand = Random.Range(0, 5);
            //������ ������Ʈ�� �����ϰ�
            GameObject go = GameObject.CreatePrimitive((PrimitiveType)(rand));
            go.transform.position = transform.position;
            //�����Ѱ��� Ÿ���� ������.
            RecycleObject obj = go.AddComponent<RecycleObject>();
            go.AddComponent<Movement>();
            obj.myType = (RecycleObject.ObjectType)(rand);
        }



    }
}
