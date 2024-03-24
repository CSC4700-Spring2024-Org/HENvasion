using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    private AudioSource audioSource;
    public GameObject emptyGunGameObject;
    private Boolean canShoot;
    public float reloadSpeed;
    public Boolean isMachineGun;
    public float bulletCount;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canShoot = true;
    }
    void Update()
    {
        //if (Input.GetMouseButton(0) && transform.parent == emptyGunGameObject.transform && canShoot && isMachineGun)
        //shootWeapon();
        if (audioSource.time > .3f)
        {
            audioSource.Stop();
        }
        if (Input.GetMouseButton(0) && isMachineGun && !audioSource.isPlaying && transform.parent == emptyGunGameObject.transform)
            shootWeapon();
        else if (Input.GetMouseButtonDown(0) && transform.parent == emptyGunGameObject.transform && canShoot && !audioSource.isPlaying)
            shootWeapon();

    }
    void shootWeapon()
    {

        audioSource.Play();
        if(!isMachineGun)
            StartCoroutine(DisableAudioSourceAfterDelay(reloadSpeed)); // Wait for 1 second
    }
    IEnumerator DisableAudioSourceAfterDelay(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        canShoot = true; // Then disable the AudioSource
    }
}
