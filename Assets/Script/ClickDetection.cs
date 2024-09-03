using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject dot;
    public GameObject info;
    static public bool checkPuzzle = false;
    public bool checkPopup = true;
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
                switch (obj.tag) {
                    case "forest":
                        setActivePopup("forest");
                        break;
                    case "house":
                        setActivePopup("house");
                        break;
                    case "blue":
                        setActivePopup("blue");
                        break;
                    case "sunset":
                        setActivePopup("sunset");
                        break;
                    case "redleaves":
                        setActivePopup("redleaves");
                        break;
                    case "sheep":
                        setActivePopup("sheep");
                        break;
                    case "elephant":
                        setActivePopup("elephant");
                        break;
                    case "bear":
                        setActivePopup("bear");
                        break;
                    case "human":
                        setActivePopup("human");
                        break;
                    case "hourse":
                        setActivePopup("hourse");
                        break;
                    case "lion":
                        setActivePopup("lion");
                        break;
                    case "dog":
                        setActivePopup("dog");
                        break;
                    case "cat":
                        setActivePopup("cat");
                        break;
                    case "vangogh1":
                        setActivePopup("vangogh1");
                        break;
                    case "vangogh2":
                        setActivePopup("vangogh2");
                        break;
                    case "cafenight":
                        setActivePopup("cafenight");
                        break;
                    case "starrynight":
                        setActivePopup("starrynight");
                        break;
                    case "rohne":
                        setActivePopup("rohne");
                        break;
                    case "irises":
                        setActivePopup("irises");
                        break;
                    case "etten":
                        setActivePopup("etten");
                        break;
                    case "mama":
                        setActivePopup("mama");
                        break;
                    case "sunflower":
                        setActivePopup("sunflower");
                        break;
                    case "olive":
                        setActivePopup("olive");
                        break;
                    case "oldman":
                        setActivePopup("oldman");
                        break;
                    case "doctor":
                        setActivePopup("doctor");
                        break;
                    case "tranhdongho":
                        setActivePopup("tranhdongho");
                        break;
                    case "redvineyard":
                        setActivePopup("RedVineyard");
                        break;
                    case "floweringgarden":
                        setActivePopup("floweringgarden");
                        break;
                    case "almond":
                        setActivePopup("Almond");
                        break;
                    case "skull":
                        setActivePopup("Skull");
                        break;
                    case "VangoghStatue":
                        setActivePopup("VanGoghStatue");
                        break;
                    //
                    case "playgame":
                        puzzle.SetActive(true);
                        checkPuzzle = true;
                        break;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
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

    void setActivePopup(string name) {
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