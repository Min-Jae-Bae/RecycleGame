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
        set { score = value; testText.text = "당신의 점수는" + value; }

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
}
