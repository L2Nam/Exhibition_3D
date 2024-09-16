using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using DG.Tweening;

public class dragAndDrop : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI clicksCountText;

    [SerializeField] GameObject Board;

    [SerializeField] Canvas gameOver;

    [SerializeField] TextMeshProUGUI Timer;

    [SerializeField] GameObject win;

    [SerializeField] TextMeshProUGUI textComplete;

    [SerializeField] GameObject btnManager;


    Vector3 originalPos;

    bool movable = true;

    int clickCount;

    string pattern = @"\d+";

    Vector3 mousePosistion;
    Vector3 Pos;
    bool inside;
    string posName = "99";
    string objectName;

    private void Start()
    {
        originalPos = transform.position;
        objectName = gameObject.name;
        inside = false;
    }


    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if (OrgPuzzle.checkMovable && movable)
        {
            Timer.GetComponent<Timer>().active = true;
            mousePosistion = Input.mousePosition - GetMousePos();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(inside);
        inside = true;
        
        posName = other.name;
        Pos = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }

    private void OnMouseDrag()
    {
        if (OrgPuzzle.checkMovable && movable)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosistion);
        }
    }

    private void OnMouseUp()
    {
        if (OrgPuzzle.checkMovable && movable)
        {
            Debug.Log(posName);
            Debug.Log(inside);

            Match match = Regex.Match(posName, pattern);
            Debug.Log(match.Value);
            Match match2 = Regex.Match(objectName, pattern);
            Debug.Log(match2.Value);

            clickCount = int.Parse(clicksCountText.text);
            clickCount++;
            clicksCountText.text = clickCount.ToString();
            if (inside && int.Parse(match.Value) == int.Parse(match2.Value))
            {
                transform.position = Pos;
                movable = false;
                Board.GetComponent<puzzleBoard>().PiecesInPlace++;
                Debug.Log("correct pieces" + Board.GetComponent<puzzleBoard>().PiecesInPlace);
                if (Board.GetComponent<puzzleBoard>().PiecesInPlace == 16)
                {
                    Timer.GetComponent<Timer>().active = false;
                    Debug.Log("over");
                    gameOver.enabled = true;
                    WinEffect();
                }
            }
            else
            {
                transform.position = originalPos;
            }
        }
    }

    void WinEffect()
    {
        int score = 16;
        PlayerPrefs.SetInt("scoreJigsaw", score);
        win.transform.SetAsLastSibling();
        win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
        {
            win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
            {
                win.SetActive(false);
                Color originalColor = textComplete.color;
                textComplete.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
                textComplete.gameObject.SetActive(true);
                // Tween alpha t? 0 ??n 1
                textComplete.DOFade(1, 1.5f).OnComplete(() =>
                {
                    btnManager.SetActive(true);
                });
            });
        });
    }

}
