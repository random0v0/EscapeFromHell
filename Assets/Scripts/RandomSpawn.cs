using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour
{
    public bool isAnimActive = false;
    public GameObject itemUI;
    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject paper4;
    public GameObject paper5;
    public Transform spawnPos1;
    public Transform[] spawnPos2 = new Transform[5];
    public Transform[] spawnPos3 = new Transform[5];
    public Transform[] spawnPos4 = new Transform[5];
    public Transform[] spawnPos5 = new Transform[5];
    public float curTime;
    public float coolTime = 2f;
    public Inventory inventory;
    public PlayerController playerController;
    public bool mouselocked = true;
    public GameObject optionUI;
    public MouseLook mouseLook;
    public GameObject optionForm;
    public GameObject helpForm;
    public bool isdead = false;
    public GameObject gameOverUI;
    public bool isPause = false;
    public GameObject firstUI;

    void Start()
    {

        gameOverUI.SetActive(false);
        optionUI.SetActive(false);
        optionForm.SetActive(false);
        helpForm.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstUI.SetActive(true);
        //spawnPos = new Transform[5];

        //for (int i = 0; i < 5; i++)
        //{
        //    spawnPos[i] = GameObject.Find("ItemSpawn" + (i + 1)).transform;


        //}

        Instantiate(paper1, spawnPos1.position, spawnPos1.rotation);

        int rnd = Random.Range(0, 5);
        int rnd2 = Random.Range(0, 5);
        int rnd3 = Random.Range(0, 5);
        int rnd4 = Random.Range(0, 5);


        Instantiate(paper2, spawnPos2[rnd].position, spawnPos2[rnd].rotation);




        Instantiate(paper3, spawnPos3[rnd2].position, spawnPos3[rnd2].rotation);





        Instantiate(paper4, spawnPos4[rnd3].position, spawnPos4[rnd3].rotation);





        Instantiate(paper5, spawnPos5[rnd4].position, spawnPos5[rnd4].rotation);




    }
    private void Update()
    {
        if (playerController.hp <= 0)
        {
            isdead = true;
            if (isdead)
            {
                playerController.enabled = false;
                mouseLook.enabled = false;
                mouselocked = false;
                gameOverUI.SetActive(true);
                StartCoroutine(BackToIntro());

            }
        }
        if (mouselocked)
        {
            playerController.enabled = true;
            mouseLook.enabled = true;
            optionUI.SetActive(false);
            optionForm.SetActive(false);
            helpForm.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            playerController.enabled = false;
            mouseLook.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mouselocked)
            {
                isPause = true;
                optionUI.SetActive(true);
                mouselocked = false;
            }
            else
            {
                isPause = false;
                mouselocked = true;
            }
        }

        playerController.PlayerHpBar();

        if (isAnimActive)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                isAnimActive = false;
                curTime = 0;
                itemUI.GetComponent<Animator>().SetInteger("ItemState", 0);
            }
        }
    }

    public void PaperPicked()
    {
        isAnimActive = true;
        inventory.paperCnt++;
        itemUI.GetComponent<Text>().text = "ÆíÁö È¹µæ";
        itemUI.GetComponent<Animator>().SetInteger("ItemState", 1);
        itemUI.GetComponent<AudioSource>().Play();

    }

    public void KeyPicked()
    {
        isAnimActive = true;
        itemUI.GetComponent<Text>().text = "ÁöÇÏ ¿­¼è È¹µæ";
        itemUI.GetComponent<Animator>().SetInteger("ItemState", 1);
        itemUI.GetComponent<AudioSource>().Play();

    }

    IEnumerator BackToIntro()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
