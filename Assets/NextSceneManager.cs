using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneManager : MonoBehaviour
{
    //전역 변수로 사용한다.
    public static NextSceneManager instance;

    //이미지 오브젝트를 가져온다.
    public Image sceneChanger;

    //초기화 한다.
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //씬의 잉름을 받으면 전환한다.
    public void NextScene(string sceneName)
    {
        //dotween을 활용하여 씬을 전환한다. 전환이 완료되면 fade out을한다.
        sceneChanger.DOFade(1, 1f).OnComplete(() =>
        {
            //씬을 전환한다.
            SceneManager.LoadScene(sceneName);
        });
    }
}