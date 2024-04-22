using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flag : MonoBehaviour
{
    // Update is called once per frame
    private bool playerEntered = false;
    private bool takenFlag = false;
    private float timeEntered;
    public Transform flagHolder;
    //private AudioSource audioSource;
    public TMP_Text flagText;
    public bool textWorking;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flagText.gameObject.SetActive(true);
            timeEntered = Time.time;
            playerEntered = true;
            textWorking = true;
            //StartCoroutine(WaitForFlag(5));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            timeEntered = -1;
            flagText.gameObject.SetActive(false);
            textWorking = false;
        }
    }

    public void Update()
    {
        if(textWorking)
            flagText.text = "Picking up egg in " + Mathf.CeilToInt(5 - (Time.time - timeEntered)) + " seconds";
        if (!takenFlag && timeEntered >= 0 && playerEntered && (Time.time - timeEntered >= 5))
        {
            takenFlag = true;
            PickUpFlag();
            flagText.gameObject.SetActive(false);
        }
    }
    private void PickUpFlag()
    {
        transform.SetParent(flagHolder);
        transform.localPosition = Vector3.zero; // Adjust as necessary //Vector3.zero
        transform.localRotation = Quaternion.identity;// Adjust as necessary //Quaternion.identity
       // audioSource.Play();
    }
    /*IEnumerator WaitForFlag(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Waited 5 seconds");

    }*/
}
