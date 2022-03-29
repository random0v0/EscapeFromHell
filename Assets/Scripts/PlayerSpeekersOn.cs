using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeekersOn : MonoBehaviour
{
    public AudioSource audiosource;
    public bool isActive = true;
    public PlayerController playerController;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.tag == "Player")
            {
                audiosource.Play();
                StartCoroutine(HpMinusSlow());
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

    IEnumerator HpMinusSlow()
    {
        yield return new WaitForSeconds(1f);
        playerController.HpMinus();
    }
}
