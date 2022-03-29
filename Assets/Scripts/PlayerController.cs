using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int hp = 100;
    public float moveSpd = 2f;
    public float gravity = -20f;
    public float yVelocity = 0;

    public CharacterController characterController;
    public Transform cameraTransform;

    public AudioSource audioSource;
    public AudioClip runSfx;
    public bool isRunning = false;
    public GameObject flashlight;
    public bool flashOnOff = false;
    public GameObject runUI;
    public GameObject flashUI;
    public Slider hpBar;

    public bool mouselocked = true;

    public GameObject inventoryUI;

    public bool isInvenShow = false;

    public GameObject hitUI;
    public AudioClip hitSFX;
    public bool iswalking = false;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        flashlight.SetActive(true);
        runUI.SetActive(false);
        flashUI.SetActive(true);
        
    }


    void Update()
    {

        float h = Input.GetAxis("Horizontal"); // 수평값
        float v = Input.GetAxis("Vertical"); // 수직값

        Vector3 moveDirection = new Vector3(h, 0, v); //움직이는 방향
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpd;



        yVelocity += (gravity * Time.deltaTime); //y에 중력 추가
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime); //움직임

        if (Input.GetKey(KeyCode.W))
        {
            iswalking = true;
        }
        else
        {
            iswalking = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && iswalking == true) //달리기 기능
        {
            moveSpd = 4f;
            isRunning = true;
            runUI.SetActive(true);
        }
        else
        {
            moveSpd = 2f;
            isRunning = false;
            runUI.SetActive(false);

        }

        if (characterController.isGrounded) //만약 바닥일때
        {
            yVelocity = 0;
        }

        if (isRunning) //뛸때 발소리 기능
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = runSfx;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (flashOnOff == false)
            {
                flashlight.SetActive(true);
                flashUI.SetActive(true);
                flashOnOff = true;
            }
            else
            {
                flashlight.SetActive(false);
                flashUI.SetActive(false);
                flashOnOff = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Tab) && isInvenShow == false)
        {
            inventoryUI.GetComponent<Tween>().InvenUIShow();
            isInvenShow = true;
            if (isInvenShow)
            {
                StartCoroutine(InvenONOFF());
            }
        }




    }
    public void HpMinus()
    {
        StartCoroutine(HpMinusCo());
    }

    public void PlayerHpBar()
    {
        hpBar.value = hp / 100f;
    }


    IEnumerator InvenONOFF()
    {
        yield return new WaitForSeconds(2f);
        inventoryUI.GetComponent<Tween>().InvenUIOff();
        isInvenShow = false;

    }

    IEnumerator HpMinusCo()
    {
        hp -= 20;
        hitUI.SetActive(true);
        hitUI.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);
        hitUI.SetActive(false);
        hitUI.GetComponent<AudioSource>().Stop();

    }


    

}
