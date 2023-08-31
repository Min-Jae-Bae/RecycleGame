using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //test
    public AudioClip[] clips;

    public Vector3 MouseOffset;
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
            int mask = 1 << LayerMask.NameToLayer("Parent");
            //���̸� �߻�~~~
            if (Physics.Raycast(ray, out hitinfo,100,mask)) {
                //����, ray�� ��������.
                rec = hitinfo.collider.gameObject.GetComponent<RecycleObject>();
                rec.movement.stopmove();
                //�ִ���.
                SoundManager.instance.PlaySFX(clips[0]);
            }
            
        }
        if (Input.GetMouseButtonUp(0)) {
            if (rec) {
                rec.movement.rbody.useGravity = true;
                rec.movement.rbody.isKinematic = false;
                rec = null;
                SoundManager.instance.PlaySFX(clips[1]);
            }
            
        }
        if (Input.GetMouseButton(0)) {
            if (rec) {
                //rec.STATE = RecycleObject.ObjectState.Click;
                Vector3 mousePosition = Input.mousePosition;
                //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;
                int mask =  1 << LayerMask.NameToLayer("floor");

                if (Physics.Raycast(ray, out hit,50.0f, mask)) {
                    Debug.Log("ss");
                    rec.transform
                        .position = hit.point + Vector3.up + MouseOffset;
                    rec.movement.rbody.velocity = Vector3.zero;
                }
                
                
                //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                //Vector3 pos2 = Camera.main.ViewportToWorldPoint(pos);
                //Debug.Log(pos2);
                //worldPosition.z = 0;
                //Vector3 n = new Vector3(worldPosition.x, 10, worldPosition.y);
                //worldPosition.y = rec.transform.position.y;
                Rigidbody rbody = rec.GetComponent<Rigidbody>();
                rbody.useGravity = false;
                //rbody.isKinematic = true;
                //rec.transform.position = pos2;
                //Debug.Log("�����̴���" + pos);

            }
        }

        if (Input.GetKeyDown(KeyCode.E) && rec){
            rec.res();
        }
        
    }
}
