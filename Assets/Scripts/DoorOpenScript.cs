using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class DoorOpenScript : MonoBehaviour
{
    public Animator doorAnim;
    public bool areUhere = false;
    public bool isOpen = false;
    public GameObject openTxt;
    public GameObject closeTxt;
    public GameObject popupImage;
    public AudioSource popupAudio;
    public PlayerController playerController;
    public bool isMusicActivated = false;
    public AudioClip openDoorSFX;
    public MonsterScripts monsterScripts;
    public RandomSpawn randomSpawn;


    void Start()
    {
        randomSpawn = GameObject.Find("GameManager").GetComponent<RandomSpawn>();
        doorAnim = GetComponent<Animator>();
        popupAudio = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        popupImage.SetActive(false);
        openTxt.SetActive(false);
        closeTxt.SetActive(false);


    }


    void Update()
    {

        if (areUhere)
        {
            if (Input.GetKeyDown(KeyCode.E) && randomSpawn.isPause == false)
            {
                int rnd = Random.Range(0, 100);

                if (rnd < 5)
                {
                    isMusicActivated = true;
                    if (isMusicActivated)
                    {
                        popupImage.SetActive(true);
                        playerController.hp -= 10;
                        StartCoroutine(PopupTime());
                    }

                }
                if (isOpen == false)
                {
                    doorAnim.SetInteger("DoorState", 1);
                    popupAudio.Play();
                    openTxt.SetActive(false);
                    closeTxt.SetActive(true);
                    if (monsterScripts.isEscape == false)
                    {
                        gameObject.GetComponent<NavMeshObstacle>().enabled = false;
                    }

                    isOpen = true;
                }
                else
                {

                    doorAnim.SetInteger("DoorState", 0);
                    isOpen = false;
                    closeTxt.SetActive(false);
                    openTxt.SetActive(true);
                    if (monsterScripts.isEscape == false)
                    {
                        gameObject.GetComponent<NavMeshObstacle>().enabled = true;
                    }
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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

            areUhere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        areUhere = false;
        openTxt.SetActive(false);
        closeTxt.SetActive(false);
    }

    IEnumerator PopupTime()
    {
        yield return new WaitForSeconds(0.1f);
        popupImage.SetActive(false);
        isMusicActivated = false;
    }
}
