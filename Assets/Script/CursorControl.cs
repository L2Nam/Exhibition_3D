using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private void Start()
    {
        // Ẩn con trỏ chuột khi chạy game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (ClickDetection.checkPuzzle)
            ToggleCursorVisibility();
    }

    private void Update()
    {
        // Kiểm tra sự kiện để hiển thị hoặc ẩn con trỏ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorVisibility();
        }
    }

    private void ToggleCursorVisibility()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
        if (ClickDetection.checkPuzzle)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
