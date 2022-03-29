using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startEventSound : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject uiText;
    bool areUhere = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<Collider>().enabled = false;
        

    }

    private void Update()
    {
        if (areUhere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Stop();
                uiText.SetActive(false);
                gameObject.GetComponent<startEventSound>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        uiText.SetActive(true);
        areUhere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        uiText.SetActive(false);
        areUhere = false;
    }


    public void StartSound()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        audioSource.Play();
    }
}
