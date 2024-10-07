using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RestoreCameraPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorVisibility();
        }
    }

    private void ToggleCursorVisibility()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
        if (GameControl.checkPuzzle)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

        void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("OnApplicationQuit");
    }

    void RestoreCameraPosition()
    {
        if (PlayerPrefs.HasKey("CameraPosX"))
        {
            float posX = PlayerPrefs.GetFloat("CameraPosX");
            float posY = PlayerPrefs.GetFloat("CameraPosY");
            float posZ = PlayerPrefs.GetFloat("CameraPosZ");

            float rotX = PlayerPrefs.GetFloat("CameraRotX");
            float rotY = PlayerPrefs.GetFloat("CameraRotY");
            float rotZ = PlayerPrefs.GetFloat("CameraRotZ");

            transform.position = new Vector3(posX, posY, posZ);
            transform.eulerAngles = new Vector3(rotX, rotY, rotZ);
        }
    }
}
