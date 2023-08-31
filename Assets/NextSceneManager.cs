using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneManager : MonoBehaviour
{
    //���� ������ ����Ѵ�.
    public static NextSceneManager instance;

    //�̹��� ������Ʈ�� �����´�.
    public Image sceneChanger;

    //�ʱ�ȭ �Ѵ�.
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //���� �׸��� ������ ��ȯ�Ѵ�.
    public void NextScene(string sceneName)
    {
        //dotween�� Ȱ���Ͽ� ���� ��ȯ�Ѵ�. ��ȯ�� �Ϸ�Ǹ� fade out���Ѵ�.
        sceneChanger.DOFade(1, 1f).OnComplete(() =>
        {
            //���� ��ȯ�Ѵ�.
            SceneManager.LoadScene(sceneName);
        });
    }
}