using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject win;
    public TextMeshProUGUI textComplete;
    public GameObject btnManager;
    public TextMeshProUGUI gameScore;
    public Canvas startcv;
    public Canvas endcv;



    public System.Random ran = new System.Random();
    public static int test;
    void Start()
    {
        Questions Questions = player.GetComponent<Questions>();
    }

    public void OnClickExit()
    {
        //popup_confirm.SetActive(false);
        SceneManager.LoadScene("exhibition");
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            startcv.enabled = false;
            endcv.enabled = true;
            gameScore.text = "Score: " + ScoreScript.scoreValue.ToString();
            GameControl.playerScore += ScoreScript.scoreValue;
            win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
            {
                win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
                {
                    win.SetActive(false);
                    Color originalColor = textComplete.color;
                    textComplete.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
                    textComplete.gameObject.SetActive(true);
                    textComplete.DOFade(1, 1.5f).OnComplete(() =>
                    {
                        btnManager.SetActive(true);
                    });
                });
            });
        }
    }

    public void EndGame()
    {
        startcv.enabled = false;
        endcv.enabled = true;
        gameScore.text = "Score: " + ScoreScript.scoreValue.ToString();
        GameControl.playerScore += ScoreScript.scoreValue;
        win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
        {
            win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
            {
                win.SetActive(false);
                Color originalColor = textComplete.color;
                textComplete.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
                textComplete.gameObject.SetActive(true);
                textComplete.DOFade(1, 1.5f).OnComplete(() =>
                {
                    btnManager.SetActive(true);
                });
            });
        });
    }
}
