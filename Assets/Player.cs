using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public RecycleObject rec;
    void Update()
    {
        //버튼을 눌렀을때
        if (Input.GetMouseButtonDown(0)) { 
            //카메라에서 레이를 만들고
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //레이를 발사~~~
            if (Physics.Raycast(ray, out hitinfo)) {
                //만약, ray에 닿은놈이.
                rec = hitinfo.collider.gameObject.GetComponent<RecycleObject>();
                //있느냐.

            }
            
        }
        if (Input.GetMouseButtonUp(0)) {
            rec = null;
        }
        if (Input.GetMouseButton(0)) {
            if (rec) {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
                //Vector3 n = new Vector3(worldPosition.x, 10, worldPosition.y);
                Rigidbody rbody = rec.GetComponent<Rigidbody>();
                rbody.useGravity = false;
                rec.transform.position = worldPosition;

            }
        }

        
    }
}
