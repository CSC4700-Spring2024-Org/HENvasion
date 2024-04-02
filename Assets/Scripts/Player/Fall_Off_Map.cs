using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fall_Off_Map : MonoBehaviour
{
    // Update is called once per frame.
    public Transform spawn1;
    public CharacterController characterController;
    void Update()
    {
        if (transform.position.y < -50)
        {
            TeleportPlayer();
        }
    }
    void TeleportPlayer()
    {
        characterController.enabled = false; // Disable controller to teleport
        transform.position = spawn1.transform.position; // Teleport
        characterController.enabled = true;
    }
}
