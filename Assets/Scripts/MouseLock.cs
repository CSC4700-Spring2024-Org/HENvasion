using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    void Start()
    {
        // Lock cursor and hide it at the start of the scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Unlock cursor when escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}