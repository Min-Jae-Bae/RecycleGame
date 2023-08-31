using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum MainGameState { 
        Start,Pause,Defeat
    }
    public MainGameState myGameState;
    public Text warningText;
    public MainGameState GameStateManage {
        set {
            myGameState = value;
            switch (value) {
                case MainGameState.Start:
                    break;
                case MainGameState.Pause:
                    break;
                case MainGameState.Defeat:
                    break;
            }
        }

    }
    public static GameManager instance;

    public Text timeText;
    public Text CommentText;
    public Image timeImage;

    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentTime = maxTime;
        StartCoroutine(Timer(currentTime, 1));

        SoundManager.instance.PlayBGM(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int maxTime;
    public int currentTime;
    IEnumerator Timer(int waitTime, int stopTime) {
        for (int i = waitTime; i >= 0; i-= stopTime) {
            yield return new WaitForSeconds(stopTime);
            currentTime -= stopTime;
            timeImage.fillAmount = ((float)(currentTime) / (float)(maxTime));
        }

        GameOver();
    }

    IEnumerator Timer(int waitTime,System.Action<int> action)
    {
        for (int i = waitTime; i >= 0; i--)
        {
            yield return new WaitForSeconds(waitTime);
            action(i);
            currentTime -= waitTime;
        }
    }

    public GameObject gameover;
    public AudioClip gameOverClip;
    public GameObject WarningUI;
    public void GameOver() {
        CommentText.text =  ScoreManager.instance.GameOver();
        WarningUI.SetActive(false);
        gameover.SetActive(true);
        SoundManager.instance.PlayBGM(gameOverClip);
        Time.timeScale = 0;
    
    }
    public Animator anim;
    public void Onanim() {
        anim.SetTrigger("On");
    }
    public void Offanim() {
        anim.SetTrigger("Off");
    }


    public void restart() {
        SceneManager.LoadScene(1);
    }

    public void exit() {
        Application.Quit();
    }
}
