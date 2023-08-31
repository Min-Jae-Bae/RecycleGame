using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    //� ������ ������������.
    public RecycleObject.ObjectType TrashType;
    // Start is called before the first frame update
    public GameObject particle;
    public GameObject particle2;

    public AudioClip[] clips;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 ParticleOffset;
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
            //���� �鸮��
            checkInstantiate(particle, transform.position + ParticleOffset, Quaternion.identity);
            //Instantiate(particle,transform.position + ParticleOffset, Quaternion.identity);
            SoundManager.instance.PlaySFX(clips[0]);
        }
        else {
            Debug.Log("�� Ʋ��");
            ScoreManager.instance.SCORE -= obj.less_score;
            checkInstantiate(particle2, transform.position + ParticleOffset, Quaternion.identity);
            //Instantiate(particle2, transform.position + ParticleOffset, Quaternion.identity);
            SoundManager.instance.PlaySFX(clips[1]);

            if (obj.WarningText.Length > 0) {
                GameManager.instance.warningText.text = obj.WarningText;
                GameManager.instance.Onanim();
            }
        }
        Destroy(other.gameObject);
    }

    public void checkInstantiate(GameObject gm,Vector3 pos,Quaternion rot) {
        if (gm) {
            Instantiate(gm, pos , rot);
        }
    }
}
