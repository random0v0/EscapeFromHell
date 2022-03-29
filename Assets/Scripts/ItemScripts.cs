using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    public ItemScripts itemScript;
    public Collider col;
    public bool isPick = false;
    public bool areUhere = false;
    public Inventory inventory;


    private void Start()
    {
        itemScript = GetComponent<ItemScripts>();
        col = GetComponent<Collider>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (areUhere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPick = true;
                if (isPick)
                {
                    Debug.Log("æ∆¿Ã≈€ »πµÊ øœ∑·");
                    //inventory.AddKey();
                    itemScript.enabled = false;
                    col.enabled = false;
                    isPick = false;
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ (E)");
            areUhere = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            areUhere = false;
        }
    }
}
