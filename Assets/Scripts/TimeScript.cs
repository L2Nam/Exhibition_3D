using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeScript : MonoBehaviour
{
    int WallNos = PuzzleControl.WallNos;
    public static int timeValue = 10;
    

    TextMeshProUGUI time;

    void Start()
    {
        timeValue = 16 * WallNos;
        time = GetComponent<TextMeshProUGUI>();
        StartCoroutine (timefun());
    }
    IEnumerator timefun()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
        timeValue = 16 * WallNos;
        ScoreScript.scoreValue = 0;
    }
    void timeCount()
    {
        timeValue -= 1;
    }

    void Update()
    {
        time.text = "Time: " + timeValue;
        if (timeValue <= 0)
        {
            time.text = "GAME OVER!";
            StartCoroutine(RestartLevel());
        }
    }
}
