using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using System.Threading.Tasks;
using DG.Tweening;


public class PuzzleControl : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] Button btn_jigsaw;
    [SerializeField] Button btn_qa;
    [SerializeField] GameObject logo_jigsaw;
    [SerializeField] GameObject logo_qa;

    private void Awake()
    {
        float screenWidth = Screen.width;

        RectTransform rectJigsaw = btn_jigsaw.GetComponent<RectTransform>();
        rectJigsaw.anchoredPosition = new Vector2(-screenWidth / 6, rectJigsaw.anchoredPosition.y);
        logo_jigsaw.transform.position = new Vector2(rectJigsaw.transform.position.x, logo_jigsaw.transform.position.y);

        RectTransform rectQa = btn_qa.GetComponent<RectTransform>();
        rectQa.anchoredPosition = new Vector2(screenWidth / 6, rectQa.anchoredPosition.y);
        logo_qa.transform.position = new Vector2(rectQa.transform.position.x, logo_qa.transform.position.y);

    }

    void checkWin()
    {
        //win.transform.SetAsLastSibling();
        //win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
        //{
        //    win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
        //    {
        //        gameObject.SetActive(false);
        //        ClickDetection.checkPuzzle = false;
        //    });
        //});
    }
}
