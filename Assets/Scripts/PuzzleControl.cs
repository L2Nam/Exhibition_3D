using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PuzzleControl : MonoBehaviour
{
    [SerializeField] GameObject win;
    [SerializeField] GameObject dot;
    [SerializeField] Button btn_jigsaw;
    [SerializeField] Button btn_qa;
    [SerializeField] GameObject logo_jigsaw;
    [SerializeField] GameObject logo_qa;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject choose_game;
    [SerializeField] GameObject choose_mode_jigsaw;
    [SerializeField] GameObject choose_painting;

    public static int mode = 0;

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
        choose_painting.SetActive(false);
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
        choose_painting.SetActive(false);
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        dot.SetActive(true);
    }

    public void OnClickJigsaw()
    {
        choose_game.SetActive(false);
        choose_mode_jigsaw.SetActive(true);
        choose_painting.SetActive(false);
    }

    public void OnClickJigsawMode(int _mode)
    {
        choose_game.SetActive(false);
        choose_mode_jigsaw.SetActive(false);
        choose_painting.SetActive(true);
        mode = _mode;
    }

    public void OnClickPainting()
    {
        Debug.LogError("mode = " + mode);
        SaveCameraPosition();
        if (mode == 3)
        {
            Debug.LogError("puzzle3x3");
            SceneManager.LoadScene("puzzle3x3");
        }
        else if (mode == 5)
        {
            Debug.LogError("puzzle5x5");
            SceneManager.LoadScene("puzzle5x5");
        }
        else
        {
            Debug.LogError("puzzle4x4");
            SceneManager.LoadScene("puzzle4x4");
        }
    }
}
