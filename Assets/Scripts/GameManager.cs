using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum MainGameState { 
        Start,Pause,Defeat
    }
    public MainGameState myGameState;

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

    public Text timeText;
    public Image timeImage;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        StartCoroutine(Timer(60,1));
        

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
    public void GameOver() {
        gameover.SetActive(true);
    
    }
}
