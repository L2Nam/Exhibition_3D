using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class OrgPuzzle : MonoBehaviour
{
    [SerializeField] GameObject startTime;

    public float Timer = 5;
    public static bool checkMovable = false;

    private void Start()
    {
        int timeStart = 5;
        startTime.transform.GetComponentInChildren<TextMeshProUGUI>().text = timeStart.ToString();
        DOTween.Sequence().AppendInterval(1.0f).AppendCallback(() =>
        {
            timeStart--;
            startTime.transform.GetComponentInChildren<TextMeshProUGUI>().text = timeStart + "";
        }).SetLoops(timeStart).OnComplete(() =>
        {
            startTime.SetActive(false);
        });
    }

    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if (Timer < 0)
        {
            gameObject.SetActive(false);
            checkMovable = true;
        }
    }
}
