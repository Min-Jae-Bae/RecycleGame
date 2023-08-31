using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //타이머 UI와 텍스트를 가져오는 변수 지정
    [SerializeField] private Image timer;

    [SerializeField] private TextMeshProUGUI timeSecond;

    //유지 시간
    public int startTime;

    //남는 유지 시간
    private int remainTime;

    private void Start()
    {
        //초기 시간을 지정
        Being(startTime);
    }

    private void Being(int startTime)
    {
        //남는시간을 지정한다.
        remainTime = startTime;
        //코루틴을 활용하여 타미어를 활성화시킨다.
        StartCoroutine(IEUpdateTimer());
    }

    private IEnumerator IEUpdateTimer()
    {
        //남는 시간이 0이 될때까지 반복한다.
        while (remainTime >= 0)
        {
            //남는 시간을 텍스트에 표시한다.
            timeSecond.text = $"{remainTime / 60:00} : {remainTime % 60:00}";
            //남는 시간을 UI에 표시한다.
            timer.fillAmount = Mathf.InverseLerp(0, startTime, remainTime);
            remainTime--;
            //1초간 대기한다.
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        print("게임 종료");
    }
}