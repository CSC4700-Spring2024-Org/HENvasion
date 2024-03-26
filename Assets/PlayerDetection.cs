using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Update is called once per frame
    private bool playerEntered = false;
    private bool takenFlag = false;
    private float timeEntered;
    public Transform flagHolder;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeEntered = Time.time;
            playerEntered = true;
            //StartCoroutine(WaitForFlag(5));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            timeEntered = -1;
        }
    }

    private void Update()
    {
        if (!takenFlag && timeEntered >= 0 && playerEntered && (Time.time - timeEntered >= 5)) {
            takenFlag = true;
            PickUpFlag();
        }
    }
    private void PickUpFlag()
    {
        transform.SetParent(flagHolder);
        transform.localPosition = Vector3.zero; // Adjust as necessary //Vector3.zero
        transform.localRotation = Quaternion.identity;// Adjust as necessary //Quaternion.identity
        audioSource.Play();
    }
    /*IEnumerator WaitForFlag(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Waited 5 seconds");

    }*/
}
