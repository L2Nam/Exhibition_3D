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
    [SerializeField] List<PuzzlePaint> listPuzzle = new List<PuzzlePaint>();
    [SerializeField] List<GameObject> listKhung = new List<GameObject>();
    [SerializeField] GameObject win;

    private Color HexToColor(string hex)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.black;
    }

    private void Start()
    {
        for (var i = 0; i < listPuzzle.Count; i++)
        {
            listPuzzle[i].setListenerDragDrop(OnBeginDrag, OnDrag, OnEndDrag);
        }
    }

    void OnBeginDrag(PointerEventData eventData, PuzzlePaint paint)
    {
        Debug.Log("OnBeginDrag" + eventData.position);
        paint.transform.SetAsLastSibling();
    }

    void OnDrag(PointerEventData eventData, PuzzlePaint paint)
    {
        Debug.Log("OnDrag1" + eventData.position);
        Vector2 pos = new Vector2(eventData.position.x - 415, eventData.position.y - 295);
        //Vector2 posTouch = paint.transform.parent.InverseTransformPoint(eventData.pointerCurrentRaycast.worldPosition);
        paint.transform.localPosition = pos;
        for (int i = 0; i < listKhung.Count; i++)
        {
            if (Vector2.Distance(paint.transform.localPosition, listKhung[i].transform.localPosition) < 50)
            {
                listKhung[i].GetComponent<Image>().color = HexToColor("#A7A7A7");
            }
            else
            {
                listKhung[i].GetComponent<Image>().color = HexToColor("#6F7074");
            }
        }
    }

    void OnEndDrag(PointerEventData eventData, PuzzlePaint paint)
    {
        int check = -1;
        for (int j = 0; j < listKhung.Count; j++)
        {
            if (listKhung[j].GetComponent<Image>().color == HexToColor("#A7A7A7"))
                check = j;
        }
        if (check != -1)
        {
            Vector2 pos = listKhung[check].transform.localPosition; 
            paint.transform.localPosition = pos;
            check = -1;
        }
        if (checkWin())
        {
            win.transform.SetAsLastSibling();
            win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
            {
                win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    ClickDetection.checkPuzzle = false;
                });
            });
        }
    }

    bool checkWin()
    {
        for (int i = 0; i < listPuzzle.Count; i++)
        {
            if (listPuzzle[i].transform.localPosition != listKhung[i].transform.localPosition)
                return false;
        }
        return true;
    }
}
