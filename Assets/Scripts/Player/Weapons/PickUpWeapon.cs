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
    public GameObject equipWeaponText;
    public GameObject swapWeaponText;

    public void Start()
    {
        weaponHeld = false;
       // weaponHolder = GetComponent<Transform>();aaadaas
        currentWeapon = null;
    }
    private void OnTriggerStay(Collider other)
    {
        /*( if (other.gameObject.tag == "Weapon" && !weaponHeld)
         {
             equipWeaponText.SetActive(true);
             if (Input.GetKeyDown(KeyCode.E))
             {
                 AttachWeapon(other.gameObject);
                 weaponHeld = true;
                 equipWeaponText.SetActive(false);
                 BoxCollider boxCollider = other.gameObject.GetComponent<BoxCollider>();
                 //MeshCollider meshCollider = GetComponent<MeshCollider>();
                 boxCollider.enabled = false;
             }
         }
         else if (other.gameObject.tag == "Weapon" && weaponHeld) {
             swapWeaponText.SetActive(true);
             if (Input.GetKeyDown(KeyCode.F) && weaponHeld)
             {
                 DropWeapon(other.gameObject);
                 swapWeaponText.SetActive(false);
             }
         }*/
        if (other.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.E) && !weaponHeld)
        {
            AttachWeapon(other.gameObject);
            weaponHeld = true;
        }
        else if (other.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.F) && weaponHeld)
        {
            DropWeapon(other.gameObject);
            Debug.Log("DROPPING WEAPON");
        }
    }
    void AttachWeapon(GameObject weapon)
    {
        if(weapon.transform.parent != null)
            weapon = weapon.transform.parent.gameObject;
        weapon.transform.SetParent(weaponHolder);
        weapon.transform.localPosition = Vector3.zero; // Adjust as necessary //Vector3.zero
        weapon.transform.localRotation = Quaternion.identity;// Adjust as necessary //Quaternion.identity
        weapon.GetComponent<Collider>().enabled = false; // Optional: Disable the weapon's collideraaas
        currentWeapon = weapon;
    }
    void DropWeapon(GameObject newWeapon)
    {
        //aadad
        currentWeapon.transform.SetParent(null);
        currentWeapon.transform.position = newWeapon.transform.position;
        currentWeapon.GetComponent<Collider>().enabled = true;
        AttachWeapon(newWeapon);
    }
    public Boolean GetWeaponHeld()
    {
        return weaponHeld;
    }
    private void OnTriggerExit(Collider other)
    {
        equipWeaponText.SetActive(false);
        swapWeaponText.SetActive(false);
    }
}