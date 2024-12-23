using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class PuzzleControl : MonoBehaviour
{
    [SerializeField] GameObject dot;
    [SerializeField] Button btn_jigsaw;
    [SerializeField] Button btn_qa;
    [SerializeField] GameObject logo_jigsaw;
    [SerializeField] GameObject logo_qa;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject choose_game;
    [SerializeField] GameObject choose_mode_jigsaw;
    [SerializeField] GameObject choose_mode_QA;
    [SerializeField] List<GameObject> List_choose_painting = new List<GameObject>();



    public static int artist = 0;
    public static int mode = 0;
    public static int paiting = -1;
    public static int WallNos;

    private void Awake()
    {
        float screenWidth = Screen.width;

        RectTransform rectJigsaw = btn_jigsaw.GetComponent<RectTransform>();
        rectJigsaw.anchoredPosition = new Vector2(-screenWidth / 6, rectJigsaw.anchoredPosition.y);
        logo_jigsaw.transform.position = new Vector2(rectJigsaw.transform.position.x, logo_jigsaw.transform.position.y);

        RectTransform rectQa = btn_qa.GetComponent<RectTransform>();
        rectQa.anchoredPosition = new Vector2(screenWidth / 6, rectQa.anchoredPosition.y);
        logo_qa.transform.position = new Vector2(rectQa.transform.position.x, logo_qa.transform.position.y);
    }

    public void OnPuzzle()
    {
        choose_game.SetActive(true);
        choose_mode_jigsaw.SetActive(false);
        for (int i = 0; i < List_choose_painting.Count; i++)
        {
            List_choose_painting[i].SetActive(false);
        }
    }

    void SaveCameraPosition()
    {
        Vector3 camPosition = mainCamera.transform.position;
        Vector3 camRotation = mainCamera.transform.eulerAngles;

        PlayerPrefs.SetFloat("CameraPosX", camPosition.x);
        PlayerPrefs.SetFloat("CameraPosY", camPosition.y);
        PlayerPrefs.SetFloat("CameraPosZ", camPosition.z);

        PlayerPrefs.SetFloat("CameraRotX", camRotation.x);
        PlayerPrefs.SetFloat("CameraRotY", camRotation.y);
        PlayerPrefs.SetFloat("CameraRotZ", camRotation.z);

        PlayerPrefs.Save(); 
    }

    public void OnClickClose()
    {
        GameControl.checkPuzzle = false;
        choose_game.SetActive(true);
        choose_mode_jigsaw.SetActive(false);
        choose_mode_QA.SetActive(false);
        for (int i = 0; i < List_choose_painting.Count; i++)
        {
            List_choose_painting[i].SetActive(false);
        }
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        dot.SetActive(true);
    }

    public void OnClickJigsaw()
    {
        choose_game.SetActive(false);
        choose_mode_jigsaw.SetActive(true);
        for (int i = 0; i < List_choose_painting.Count; i++)
        {
            List_choose_painting[i].SetActive(false);
        }
    }

    public void OnClickQA()
    {
        choose_game.SetActive(false);
        choose_mode_QA.SetActive(true);
        for (int i = 0; i < List_choose_painting.Count; i++)
        {
            List_choose_painting[i].SetActive(false);
        }
    }

    public void OnClickJigsawMode(int _mode)
    {
        Debug.Log(artist);
        choose_game.SetActive(false);
        choose_mode_jigsaw.SetActive(false);
        List_choose_painting[artist].SetActive(true);
        mode = _mode;
    }

    public void OnClickPainting(int _painting)
    {
        paiting = _painting;
        SaveCameraPosition();
        if (mode == 3)
        {
            SceneManager.LoadScene("puzzle3x3");
        }
        else if (mode == 5)
        {
            SceneManager.LoadScene("puzzle5x5");
        }
        else
        {
            SceneManager.LoadScene("puzzle4x4");
        }
    }

    public void onClickQAmode(int modeQA)
    {
        SaveCameraPosition();
        WallNos = modeQA;
        SceneManager.LoadScene("QAGame");
    }
}
