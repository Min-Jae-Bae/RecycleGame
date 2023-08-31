using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressedBtn : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    private Button btn;

    private Transform myIcon;

    private void Start()
    {
        btn = GetComponent<Button>();

        if (transform.childCount > 0)
            myIcon = transform.GetChild(0);
    }

    public void OnClick()
    {
        if (myIcon != null)
            myIcon.localScale = Vector3.one;
        //다음씬으로 이동한다.
        NextSceneManager.instance.NextScene("MainScene");
    }

    public void OnPressed()
    {
        if (myIcon != null)
            myIcon.localScale = Vector3.one * 1.2f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressed();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}