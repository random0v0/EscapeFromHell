using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Animator doorAnim;
    public bool areUhere = false;
    public bool isOpen = false;
    public GameObject openTxt;
    public GameObject closeTxt;
    public GameObject lockTxt;
    public bool islocked = true;
    public AudioSource doorAudio;


    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
        doorAnim = GetComponent<Animator>();


        openTxt.SetActive(false);
        closeTxt.SetActive(false);
        lockTxt.SetActive(false);


    }


    void Update()
    {

        if (areUhere == true && islocked == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isOpen == false)
                {
                    doorAnim.SetInteger("DoorState", 1);
                    doorAudio.Play();
                    openTxt.SetActive(false);
                    closeTxt.SetActive(true);

                    isOpen = true;
                }
                else
                {
                    doorAnim.SetInteger("DoorState", 0);
                    isOpen = false;
                    closeTxt.SetActive(false);
                    openTxt.SetActive(true);
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (islocked == false)
            {
                lockTxt.SetActive(false);
                if (isOpen == false)
                {
                    closeTxt.SetActive(false);
                    openTxt.SetActive(true);
                }
                else
                {
                    closeTxt.SetActive(true);
                    openTxt.SetActive(false);
                }
            }
            else
            {
                lockTxt.SetActive(true);
            }



            areUhere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        areUhere = false;
        openTxt.SetActive(false);
        closeTxt.SetActive(false);
        lockTxt.SetActive(false);
    }
}
