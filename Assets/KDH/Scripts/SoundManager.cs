using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource BGMChanel;
    public AudioSource SFXChanel;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(AudioClip clip) {
        BGMChanel.clip = clip;
        BGMChanel.Play();
    }
    public void PlaySFX(AudioClip clip) {
        SFXChanel.PlayOneShot(clip);
    }
}
