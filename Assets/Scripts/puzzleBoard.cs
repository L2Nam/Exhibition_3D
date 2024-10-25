using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class puzzleBoard : MonoBehaviour
{
    [SerializeField] List<Texture> imgsVG;
    [SerializeField] List<Texture> imgsPi;
    [SerializeField] List<Texture> imgsLeo;

    [SerializeField] Material mat;

    public int PiecesInPlace = 0;

    private void Start()
    {
        if (PuzzleControl.artist == 0)
        {
            if (PuzzleControl.paiting == -1)
            {
                mat.mainTexture = imgsVG[Random.Range(0, imgsVG.Count)];
            }
            else
            {
                mat.mainTexture = imgsVG[PuzzleControl.paiting];
            }
        }
        else if (PuzzleControl.artist == 1)
        {
            if (PuzzleControl.paiting == -1)
            {
                mat.mainTexture = imgsPi[Random.Range(0, imgsPi.Count)];
            }
            else
            {
                mat.mainTexture = imgsPi[PuzzleControl.paiting];
            }
        }
        else if (PuzzleControl.artist == 2)
        {
            if (PuzzleControl.paiting == -1)
            {
                mat.mainTexture = imgsLeo[Random.Range(0, imgsLeo.Count)];
            }
            else
            {
                mat.mainTexture = imgsLeo[PuzzleControl.paiting];
            }
        }
    }
}
