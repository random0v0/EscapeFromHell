using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject escapeUI;
    public PlayerController playerCon;
    public MouseLook mouseCon;
    public MonsterScripts monScript;
    public GameObject monster;
    public bool isEscape = false;
    


    private void OnTriggerEnter(Collider other)
    {
        if (isEscape)
        {
            monster.SetActive(false);
            escapeUI.SetActive(true);
            playerCon.enabled = false;
            mouseCon.enabled = false;
            monScript.enabled = false;
            StartCoroutine(EscapeDone());
        }
    }


    IEnumerator EscapeDone()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}
