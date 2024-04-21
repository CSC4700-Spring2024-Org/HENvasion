using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewWeaponScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject equipWeaponText;
    public GameObject swapWeaponText;
    public static bool weaponHeld;
    private static GameObject firstWeapon;
    public Transform weaponHolder;
    public bool inTrigger;
    public static int x = 0;
    public GameObject interactWeapon;

    public void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E) && !weaponHeld)
        {
            AttachWeapon();
        }
        else if(inTrigger && Input.GetKeyDown(KeyCode.E) && weaponHeld)
        {
            DropWeapon();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !weaponHeld)
        {
            equipWeaponText.SetActive(true);
            inTrigger = true;
            interactWeapon = other.transform.gameObject;
        }
        else if (other.CompareTag("Weapon") && weaponHeld)
        {
            swapWeaponText.SetActive(true);
            inTrigger = true;
            interactWeapon = other.transform.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        equipWeaponText.SetActive(false);
        swapWeaponText.SetActive(false);
        inTrigger = false;
    }
    public void AttachWeapon()
    {
        //if (this.transform.parent != null)
           // firstWeapon = this.transform.parent.gameObject;
       // else
          //  firstWeapon = this.transform.gameObject;
          
        equipWeaponText.SetActive(false);
        interactWeapon.transform.SetParent(weaponHolder);
        interactWeapon.transform.localPosition = Vector3.zero;
        interactWeapon.transform.localRotation = Quaternion.identity;
        interactWeapon.GetComponent<Collider>().enabled = false;
        firstWeapon = interactWeapon;
        weaponHeld = true;
    }
    public void DropWeapon()
    {
        swapWeaponText.SetActive(false);
        firstWeapon.transform.SetParent(null);
        firstWeapon.transform.position = this.transform.position;
        firstWeapon.GetComponent<Collider>().enabled = true;
        AttachWeapon();
    }
}
