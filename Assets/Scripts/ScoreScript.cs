using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMeshProUGUI score;

    void Start()
    {
        scoreValue = 0;
        score = GetComponent<TextMeshProUGUI>();
    }


    public void UpdateScore()
    {
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreValue;
    }
}
