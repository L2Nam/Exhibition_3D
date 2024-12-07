using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class JigsawControl : MonoBehaviour
{
    [SerializeField] GameObject popup_confirm;
    [SerializeField] GameObject win;
    [SerializeField] TextMeshProUGUI textComplete;
    [SerializeField] GameObject btnManager;
    [SerializeField] Timer time;
    [SerializeField] GameObject soundGame;


    public void OnClickBack()
    {
        popup_confirm.SetActive(true);
    }

    public void OnClickExit()
    {
        popup_confirm.SetActive(false);
        SceneManager.LoadScene("exhibition");
    }

    public void OnClickCancle()
    {
        popup_confirm.SetActive(false);
    }

    public void WinEffect(int clickTime)
    {
        int score = (PuzzleControl.mode - 2) * 1000;
        score = score - ((int)time.timer * 2) - (clickTime - PuzzleControl.mode * PuzzleControl.mode)  * 10;
        score = score > 5? score : 5;
        textComplete.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        GameControl.playerScore += score;
        win.transform.SetAsLastSibling();
        win.transform.DOLocalJump(Vector2.zero, 2f, 4, 2f).OnComplete(() =>
        {
            win.transform.DOLocalMove(new Vector2(0, -450), 1.2f).OnComplete(() =>
            {
                win.SetActive(false);
                textComplete.gameObject.SetActive(true);
                textComplete.DOFade(1, 1.5f).OnComplete(() =>
                {
                    btnManager.SetActive(true);
                });
            });
        });
    }

    public void PlayAudio(string sound1)
    {
        Transform sound = soundGame.transform.Find(sound1);
        AudioSource audioSource = sound.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
