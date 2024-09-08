using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject dot;
    public GameObject info;
    public GameObject camera;
    static public bool checkPuzzle = false;
    public bool checkPopup = true;

    private void Start()
    {
        restartAfterPuzzle();
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
                switch (obj.tag) {
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
                    case "vangogh1":
                        SetActivePopup("vangogh1");
                        break;
                    case "vangogh2":
                        SetActivePopup("vangogh2");
                        break;
                    case "cafenight":
                        SetActivePopup("cafenight");
                        break;
                    case "starrynight":
                        SetActivePopup("starrynight");
                        break;
                    case "rohne":
                        SetActivePopup("rohne");
                        break;
                    case "irises":
                        SetActivePopup("irises");
                        break;
                    case "etten":
                        SetActivePopup("etten");
                        break;
                    case "mama":
                        SetActivePopup("mama");
                        break;
                    case "sunflower":
                        SetActivePopup("sunflower");
                        break;
                    case "olive":
                        SetActivePopup("olive");
                        break;
                    case "oldman":
                        SetActivePopup("oldman");
                        break;
                    case "doctor":
                        SetActivePopup("doctor");
                        break;
                    case "tranhdongho":
                        SetActivePopup("tranhdongho");
                        break;
                    case "redvineyard":
                        SetActivePopup("RedVineyard");
                        break;
                    case "floweringgarden":
                        SetActivePopup("floweringgarden");
                        break;
                    case "almond":
                        SetActivePopup("Almond");
                        break;
                    case "skull":
                        SetActivePopup("Skull");
                        break;
                    case "VangoghStatue":
                        SetActivePopup("VanGoghStatue");
                        break;
                    //
                    case "playgame":
                        puzzle.SetActive(true);
                        checkPuzzle = true;
                        dot.SetActive(false);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        break;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (checkPuzzle)
                return;
            checkPopup = false;
            dot.SetActive(true);
            int childCount = info.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = info.transform.GetChild(i);
                GameObject childObj = childTransform.gameObject;
                if (childObj.activeSelf && childObj.tag == "popup")
                {
                    // Nếu đang hiển thị, đóng popup
                    childObj.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }

    void restartAfterPuzzle()
    {
        if (PlayerPrefs.HasKey("CameraPosX"))
        {
            SetActivePopup("");
            checkPuzzle = false;
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void SetActivePopup(string name) {
        Debug.Log("SetActivePopup =>>> " + name);
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
            if (childTransform.name == name && !checkPopup) {
                checkPopup = true;
                childTransform.gameObject.SetActive(true);
            }
        }
    }
}