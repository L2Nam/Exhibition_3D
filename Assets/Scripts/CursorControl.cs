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

    void RestoreCameraPosition()
    {
        if (PlayerPrefs.HasKey("CameraPosX"))
        {
            // Khôi ph?c v? trí
            float posX = PlayerPrefs.GetFloat("CameraPosX");
            float posY = PlayerPrefs.GetFloat("CameraPosY");
            float posZ = PlayerPrefs.GetFloat("CameraPosZ");

            // Khôi ph?c góc quay
            float rotX = PlayerPrefs.GetFloat("CameraRotX");
            float rotY = PlayerPrefs.GetFloat("CameraRotY");
            float rotZ = PlayerPrefs.GetFloat("CameraRotZ");

            // Gán l?i v? trí và góc quay cho camera
            transform.position = new Vector3(posX, posY, posZ);
            transform.eulerAngles = new Vector3(rotX, rotY, rotZ);
        }
    }
}
