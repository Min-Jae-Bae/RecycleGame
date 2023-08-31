using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Ÿ�̸� UI�� �ؽ�Ʈ�� �������� ���� ����
    [SerializeField] private Image timer;

    [SerializeField] private TextMeshProUGUI timeSecond;

    //���� �ð�
    public int startTime;

    //���� ���� �ð�
    private int remainTime;

    private void Start()
    {
        //�ʱ� �ð��� ����
        Being(startTime);
    }

    private void Being(int startTime)
    {
        //���½ð��� �����Ѵ�.
        remainTime = startTime;
        //�ڷ�ƾ�� Ȱ���Ͽ� Ÿ�̾ Ȱ��ȭ��Ų��.
        StartCoroutine(IEUpdateTimer());
    }

    private IEnumerator IEUpdateTimer()
    {
        //���� �ð��� 0�� �ɶ����� �ݺ��Ѵ�.
        while (remainTime >= 0)
        {
            //���� �ð��� �ؽ�Ʈ�� ǥ���Ѵ�.
            timeSecond.text = $"{remainTime / 60:00} : {remainTime % 60:00}";
            //���� �ð��� UI�� ǥ���Ѵ�.
            timer.fillAmount = Mathf.InverseLerp(0, startTime, remainTime);
            remainTime--;
            //1�ʰ� ����Ѵ�.
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        print("���� ����");
    }
}