using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public GameObject puzzle;
    static public bool checkPuzzle = false;
    void Update()
    {
        // Kiểm tra xem người dùng đã nhấp chuột chưa
        if (Input.GetMouseButtonDown(0))
        {
            // Tạo một ray từ vị trí chuột
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);

            // Tạo một RaycastHit để lưu thông tin về đối tượng được chạm
            RaycastHit hit;

            // Kiểm tra xem ray có chạm vào đối tượng nào không
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj);
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
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            puzzle.SetActive(true);
            checkPuzzle = true;
        }
    }

    void setActivePopup(string name) {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            if (childTransform.name == name) {
                childTransform.gameObject.SetActive(true);
            }
        }
    }
}