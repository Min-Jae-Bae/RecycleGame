using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        RecycleObject obj = other.gameObject.GetComponent<RecycleObject>();
        if (obj) {
            ScoreManager.instance.SCORE -= obj.less_score;
            SoundManager.instance.PlaySFX(clip);
            Destroy(other.gameObject);
            
        }
        
    }

    
}
