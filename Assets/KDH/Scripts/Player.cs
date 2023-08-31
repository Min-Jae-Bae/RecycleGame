using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //test
    public AudioClip[] clips;

    public Vector3 MouseOffset;
    public GameObject ClickEffect;
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

            //레이어 마스크를 이용해서 제한대상 설정(왜 되는거였지? 까먹음)
            int mask1 = 1 << LayerMask.NameToLayer("Parent");
            int mask2 = 1 << LayerMask.NameToLayer("floor");
            int mask = mask1 | mask2;
            //레이를 발사~~~
            if (Physics.Raycast(ray, out hitinfo,200,mask)) {

                //만약, ray에 닿은놈이.
                rec = hitinfo.collider.gameObject.GetComponent<RecycleObject>();
                //땅바닥에 클릭한경우
                if (rec == null)
                {
                    Debug.Log("왜 안되냐?");
                    Instantiate(ClickEffect, hitinfo.point, Quaternion.identity);
                    SoundManager.instance.PlaySFX(clips[2]);

                }
                else {
                    
                    rec.movement.stopmove();
                    //있느냐.
                    SoundManager.instance.PlaySFX(clips[0]);
                }
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
                //Debug.Log("움직이는중" + pos);

            }
        }

        if (Input.GetKeyDown(KeyCode.E) && rec){
            rec.res();
        }
        
    }
}
