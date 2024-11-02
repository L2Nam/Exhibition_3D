using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject dot;
    [SerializeField] GameObject info;
    [SerializeField] GameObject camera;
    [SerializeField] SoundManager soundManager;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] List<Light> listLightVanGogh = new List<Light>();
    [SerializeField] List<Light> listLightPicasso = new List<Light>();
    [SerializeField] List<Light> listLightLeonardo = new List<Light>();

    static public bool checkPuzzle = false;
    public static int playerScore = 0;
    public bool checkPopup = true;
    public bool checkSound = false;
    string namePopup = "";
    private int currentColorIndex = 0;
    private int currentColorIndexPi = 0;
    private Color[] colors = new Color[5];

    private void Start()
    {
        restartAfterPuzzle();
        colors[0] = Color.blue;     
        colors[1] = Color.green;
        colors[2] = Color.red;
        colors[3] = Color.yellow;
        colors[4] = new Color(0.5f, 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj + " ===> " + obj.tag);
                float distance = Vector3.Distance(camera.transform.position, hit.point);
                if (distance > 10 || checkPuzzle)
                    return;
                if (obj.layer == 6) // information
                {
                    Debug.Log("show information");
                    SetActivePopup(obj.tag);
                }
                else
                {
                    switch (obj.tag)
                    {
                        case "forest":
                            SetActivePopup("forest");
                            break;
                        case "house":
                            SetActivePopup("house");
                            break;
                        case "blue":
                            SetActivePopup("blue");
                            break;
                        case "sunset":
                            SetActivePopup("sunset");
                            break;
                        case "redleaves":
                            SetActivePopup("redleaves");
                            break;
                        case "sheep":
                            SetActivePopup("sheep");
                            break;
                        case "elephant":
                            SetActivePopup("elephant");
                            break;
                        case "bear":
                            SetActivePopup("bear");
                            break;
                        case "human":
                            SetActivePopup("human");
                            break;
                        case "hourse":
                            SetActivePopup("hourse");
                            break;
                        case "lion":
                            SetActivePopup("lion");
                            break;
                        case "dog":
                            SetActivePopup("dog");
                            break;
                        case "cat":
                            SetActivePopup("cat");
                            break;
                        case "playgame":
                            puzzle.SetActive(true);
                            checkPuzzle = true;
                            dot.SetActive(false);
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            PuzzleControl.artist = obj.layer - 7;
                            break;
                        case "changelightVG":
                            OnClickChangeLightVG();
                            break;
                        case "changelightPi":
                            OnClickChangeLightPi();
                            break;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (checkPuzzle)
                return;
            checkPopup = false;
            namePopup = "";
            checkSound = false;
            soundManager.stopAllCurrentEffect();
            dot.SetActive(true);
            int childCount = info.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = info.transform.GetChild(i);
                GameObject childObj = childTransform.gameObject;
                if (childObj.activeSelf && childObj.tag == "popup")
                {
                    childObj.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!checkPopup)
                return;
            if (!checkSound)
            {
                PlayAudioDescribe();
                checkSound = true;
            }
            else
            {
                soundManager.stopAllCurrentEffect();
                checkSound = false;
            }
        }
    }

    void PlayAudioDescribe()
    {
        if (namePopup == "")
            return;
        string reff = "Sounds/" + namePopup;
        try
        {
            SoundManager.instance.PlayEffectFromPath(reff);
        }
        catch
        {
            Debug.Log("Khong co audio: " + namePopup);
        }
    }

    void restartAfterPuzzle()
    {
        if (PlayerPrefs.HasKey("CameraPosX"))
        {
            SetActivePopup("");
            checkPuzzle = false;
        }
        textScore.text = "Score: " + playerScore.ToString();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("OnApplicationQuit");
    }

    public void OnClickChangeLightVG()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        for (int i = 0; i < listLightVanGogh.Count; i++)
        {
            listLightVanGogh[i].color = colors[currentColorIndex];
        }
    }

    public void OnClickChangeLightPi()
    {
        currentColorIndexPi = (currentColorIndexPi + 1) % colors.Length;
        for (int i = 0; i < listLightPicasso.Count; i++)
        {
            listLightPicasso[i].color = colors[currentColorIndexPi];
        }
    }

    public void SetActivePopup(string name)
    {
        if (name == "")
        {
            dot.SetActive(true);
            checkPopup = false;
            int childCounts = info.transform.childCount;
            for (int i = 0; i < childCounts; i++)
            {
                Transform childTransform = info.transform.GetChild(i);
                childTransform.gameObject.SetActive(false);
            }
            return;
        }
        dot.SetActive(false);
        int childCount = info.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = info.transform.GetChild(i);
            if (childTransform.name == name && !checkPopup)
            {
                namePopup = name;
                checkPopup = true;
                childTransform.gameObject.SetActive(true);
            }
        }
    }
}
