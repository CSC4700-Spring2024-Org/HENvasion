using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public Transform weaponHolder;
    public Boolean weaponHeld;
    private GameObject currentWeapon = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.E) && !weaponHeld)
        {
            AttachWeapon(other.gameObject);
            weaponHeld = true;
        }
        else if(other.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.F) && weaponHeld)
        {
            DropWeapon(other.gameObject);
        }
    }
    void AttachWeapon(GameObject weapon)
    {
        weapon.transform.SetParent(weaponHolder);
        weapon.transform.localPosition = Vector3.zero; // Adjust as necessary //Vector3.zero
        weapon.transform.localRotation = Quaternion.identity;// Adjust as necessary //Quaternion.identity
        weapon.GetComponent<Collider>().enabled = false; // Optional: Disable the weapon's collider
        currentWeapon = weapon;
    }
    void DropWeapon(GameObject newWeapon)
    {
        currentWeapon.transform.SetParent(null);
        currentWeapon.transform.position = newWeapon.transform.position;
        currentWeapon.GetComponent<Collider>().enabled = true;
        AttachWeapon(newWeapon);
    }
    public Boolean GetWeaponHeld()
    {
        return weaponHeld;
    }
}