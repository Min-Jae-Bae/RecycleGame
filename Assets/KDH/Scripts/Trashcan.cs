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
            Instantiate(particle,transform.position + ParticleOffset, Quaternion.identity);
            SoundManager.instance.PlaySFX(clips[0]);
        }
        else {
            Debug.Log("�� Ʋ��");
            ScoreManager.instance.SCORE -= obj.less_score;
            Instantiate(particle2, transform.position + ParticleOffset, Quaternion.identity);
            SoundManager.instance.PlaySFX(clips[1]);
        }
        Destroy(other.gameObject);
    }
}
