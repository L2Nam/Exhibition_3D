using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameArrow : MonoBehaviour
{
    public float bounceSpeed = 2.0f;
    public float bounceHeight = 0.5f;
    public GameObject arrow;

    private Vector3 startPos;

    void Start()
    {
        startPos = arrow.transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        arrow.transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
