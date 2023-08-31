using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text testText;
    public int score;
    public int SCORE
    {
        get { return score; }
        set { 
                
            score = value; 
            if (score <= 0) {
                score = 0;
            }
            testText.text = "당신의 점수는" + score; }

    }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //초기화
        SCORE = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //점수가 몇점인지. 
    //그에 따른 칭찬하기.
    public string commnet;
    public string GameOver() {
        string comment = "";
        if (score  < 10) {
            comment += "잠깐 졸았나봐요! 일어나서 분리수거를 다녀오면 어떨까요?";
        }
        if (score > 10 && score < 20) {
            comment += "조금만 더 노력해보세요. 다시 한번 하면서 알아봅시다!";
        
        }
        if (score > 20 && score < 50)
        {
            comment += "열심히 했지만 안타깝네요. 화이팅입니다.";

        }
        if(score > 50  && score < 100){
            comment += "멋있습니다! 당신은 분리수거 고수입니다.";
        }
        if(score > 100)
        {

            comment += "대박! 당신은 분리수거로 인류를 구원할 것입니다.";
        }
        return comment;

    }

}
