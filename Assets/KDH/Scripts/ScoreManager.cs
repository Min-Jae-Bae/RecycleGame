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
            testText.text = "����� ������" + score; }

    }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //�ʱ�ȭ
        SCORE = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //������ ��������. 
    //�׿� ���� Ī���ϱ�.
    public string commnet;
    public string GameOver() {
        string comment = "";
        if (score  < 10) {
            comment += "��� ���ҳ�����! �Ͼ�� �и����Ÿ� �ٳ���� ����?";
        }
        if (score > 10 && score < 20) {
            comment += "���ݸ� �� ����غ�����. �ٽ� �ѹ� �ϸ鼭 �˾ƺ��ô�!";
        
        }
        if (score > 20 && score < 50)
        {
            comment += "������ ������ ��Ÿ���׿�. ȭ�����Դϴ�.";

        }
        if(score > 50  && score < 100){
            comment += "���ֽ��ϴ�! ����� �и����� ����Դϴ�.";
        }
        if(score > 100)
        {

            comment += "���! ����� �и����ŷ� �η��� ������ ���Դϴ�.";
        }
        return comment;

    }

}
