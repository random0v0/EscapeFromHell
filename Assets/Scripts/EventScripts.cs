using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScripts : MonoBehaviour
{
    public startEventSound eventSfx;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            eventSfx.StartSound();
            gameObject.SetActive(false);
        }

    }

}
