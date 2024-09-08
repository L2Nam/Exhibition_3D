using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JigsawControl : MonoBehaviour
{
    [SerializeField] GameObject popup_confirm;

    public void OnClickBack()
    {
        popup_confirm.SetActive(true);
    }

    public void OnClickExit()
    {
        popup_confirm.SetActive(false);
        SceneManager.LoadScene("exhibition");
    }

    public void OnClickCancle()
    {
        popup_confirm.SetActive(false);
    }
}
