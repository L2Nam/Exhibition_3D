using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class puzzleBoard : MonoBehaviour
{
    [SerializeField] List<Texture> imgs;

    [SerializeField] Material mat;

    public int PiecesInPlace = 0;

    private void Start()
    {
        if (PuzzleControl.paiting == -1)
        {
            mat.mainTexture = imgs[Random.Range(0, imgs.Count)];
        }
        else
        {
            mat.mainTexture = imgs[PuzzleControl.paiting];
        }
    }
}
