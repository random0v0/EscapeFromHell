using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperScript : MonoBehaviour
{
    public bool areUhere = false;
    public bool paperget = false;
    public RandomSpawn gameMGR;
    private void Start()
    {
        gameMGR = GameObject.Find("GameManager").GetComponent<RandomSpawn>();
    }
    void Update()
    {
        if (paperget && areUhere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameMGR.PaperPicked();
                paperget = false;
                Destroy(gameObject);

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
                paperget = true;

            }
        }

    }

    public void OnTriggerExit(Collider other)
    {

        areUhere = false;
    }
}
