using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffEventTrigger : MonoBehaviour
{
    public GameObject useTxt;
    public bool areUhere = false;
    public GameObject filmevent;
    public GameObject pointLight;
    public AudioSource audioSource;
    public GameObject dolll;

    private void Start()
    {
        filmevent.SetActive(false);
        useTxt.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (areUhere && gameObject.name == "FilmProjector")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Play();
                useTxt.SetActive(false);
                filmevent.SetActive(true);
                dolll.SetActive(true);
                gameObject.GetComponent<stuffEventTrigger>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
               
            }

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            areUhere = true;
            if (areUhere)
            {
                useTxt.SetActive(true);

            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        useTxt.SetActive(false);
        areUhere = false;
    }
}
