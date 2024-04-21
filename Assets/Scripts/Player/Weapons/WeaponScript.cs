using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public AudioSource audioSource;
    public AudioSource reloadAudioSource;
    public GameObject emptyGunGameObject;
    private Boolean canShoot;
    public float timeBetweenShots;
    public Boolean isMachineGun;
    public float bulletCount;
    private float bulletsUsed;
    public float reloadSpeed;
    private bool currentlyReloading = false;

    public float spread;
    public float throwForce;
    public float throwUpwardForce;
    public Transform cam;
    public GameObject bullet;
    public float shootForce;
    public Camera fpsCam;
    public Transform attackPoint;

    private void Start()
    {
        canShoot = true;
        bulletsUsed = bulletCount;
    }
    void Update()
    {
        //if (Input.GetMouseButton(0) && transform.parent == emptyGunGameObject.transform && canShoot && isMachineGun)
        //shootWeapon();
        if (transform.parent != null)
        {
            if (audioSource.time > .3f)
            {
                //bulletsUsed -= 1;
                audioSource.Stop();
            }
            if(bulletsUsed < bulletCount && Input.GetKeyDown(KeyCode.R))
            {
                reload();
            }
            else if (Input.GetMouseButton(0) && !currentlyReloading && bulletsUsed > 0 && isMachineGun && !audioSource.isPlaying && transform.parent.name == emptyGunGameObject.transform.name)
                shootWeapon();
            else if (Input.GetMouseButtonDown(0) && !currentlyReloading && bulletsUsed > 0 && transform.parent.name == emptyGunGameObject.transform.name && canShoot && !audioSource.isPlaying) 
                shootWeapon();
          
        }
    }
    void shootWeapon()
    {

        audioSource.Play();
        bulletsUsed -= 1;

        GameObject projectile = Instantiate(bullet, attackPoint.position, cam.rotation);

        SphereCollider sphereCollider = projectile.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        Destroy(projectile, 3f);



        if (!isMachineGun)
            StartCoroutine(DisableAudioSourceAfterDelay(timeBetweenShots)); // Wait for 1 second
    }

    void reload()
    {
        reloadAudioSource.Play();
        currentlyReloading = true;
        StartCoroutine(reloadDelay(reloadSpeed));
    }
    IEnumerator DisableAudioSourceAfterDelay(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        canShoot = true; // Then disable the AudioSource
    }
    IEnumerator reloadDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletsUsed = bulletCount;
        currentlyReloading = false;
    }
}
