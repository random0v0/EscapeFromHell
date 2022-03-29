using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickedKey : MonoBehaviour
{
    public bool areUhere = false;
    public bool grnkeyget = false;
    public GameObject itemUI;
    public Inventory inventory;
    public RandomSpawn gameMGR;
    public GameObject dolll;

    private void Start()
    {
        gameMGR = GameObject.Find("GameManager").GetComponent<RandomSpawn>();
    }




    private void Update()
    {
        if (grnkeyget && areUhere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameMGR.KeyPicked();
                inventory.basementKey = true;
                grnkeyget = false;
                dolll.SetActive(true);
                Destroy(gameObject);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        areUhere = true;
        if (areUhere)
        {
            if (other.gameObject.tag == "Player")
            {
                grnkeyget = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        areUhere = false;
    }
}
