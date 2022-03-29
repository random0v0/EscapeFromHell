using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool basementKey = false;
    public GameObject lockedDoor1;
    public int paperCnt = 0;
    public Text paperUiText;
    public Text keyUiText;
    public GameObject paperUI;
    public GameObject monster1;
    public GameObject escapelight;
    public GameObject escapeRoom;
    public GameObject escapeUI;
    public AudioSource audioSource;
    public AudioClip switchSound;
    public GameObject bgm1;
    public GameObject bgm2;

    private void Update()
    {
        if (basementKey)
        {
            lockedDoor1.GetComponent<Lock>().islocked = false;
            keyUiText.text = "¿­¼è : 1";
        }

        paperUiText.text = "ÆíÁö : " + paperCnt;

        if (paperCnt == 2)
        {
            monster1.SetActive(true);
        }
        else if (paperCnt == 5)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            else
            {
                audioSource.PlayOneShot(switchSound);
            }
            StartCoroutine(EscapeON());

        }


    }

    IEnumerator EscapeON()
    {

        escapelight.SetActive(true);
        escapeUI.SetActive(true);
        bgm1.SetActive(false);
        bgm2.SetActive(true);
        escapeRoom.GetComponent<Escape>().isEscape = true;
        yield return new WaitForSeconds(0.5f);
        monster1.GetComponent<MonsterScripts>().isEscape = true;
        gameObject.GetComponent<Inventory>().enabled = false;
    }

    






}

