using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float sens = 500f;
    public float rotX;
    public float rotY;
    public Slider sensSlider;
    public GameObject optionUI;
    private void Start()
    {
        if (PlayerPrefs.HasKey("sensSave"))
        {
            sens = PlayerPrefs.GetFloat("sensSave");
            sensSlider.value = sens;
        }
    }

    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotY += mouseMoveValueX * sens * Time.deltaTime;
        rotX += mouseMoveValueY * sens * Time.deltaTime;


        if (rotX > 90f)
        {
            rotX = 90f;
        }
        if (rotX < -90f)
        {
            rotX = -90f;
        }

        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
    }


    public void ChangeSens()
    {
        sens = sensSlider.value;
        sensSlider.value = sens;
        PlayerPrefs.SetFloat("sensSave", sens);
        PlayerPrefs.Save();
        optionUI.SetActive(false);
    }
}
