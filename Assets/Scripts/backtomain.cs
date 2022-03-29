using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomain : MonoBehaviour
{
    public GameObject firstUI;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FirstUIShow());
    }
    public void TitleGO()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator FirstUIShow()
    {
        yield return new WaitForSeconds(5f);
        firstUI.SetActive(false);
    }
}
