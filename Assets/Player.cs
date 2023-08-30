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
        //��ư�� ��������
        if (Input.GetMouseButtonDown(0)) { 
            //ī�޶󿡼� ���̸� �����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //���̸� �߻�~~~
            if (Physics.Raycast(ray, out hitinfo)) {
                //����, ray�� ��������.
                rec = hitinfo.collider.gameObject.GetComponent<RecycleObject>();
                //�ִ���.

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
