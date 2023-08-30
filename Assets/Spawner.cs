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
            //랜덤한 수를 정하고
            int rand = Random.Range(0, 5);
            //랜덤한 오브젝트를 생성하고
            GameObject go = GameObject.CreatePrimitive((PrimitiveType)(rand));
            go.transform.position = transform.position;
            //생성한곳에 타입을 지정함.
            RecycleObject obj = go.AddComponent<RecycleObject>();
            go.AddComponent<Movement>();
            obj.myType = (RecycleObject.ObjectType)(rand);
        }



    }
}
