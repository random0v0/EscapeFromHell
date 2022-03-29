using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject helpUI;
    public GameObject firstUI;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FirstUIend());
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void HelpShow()
    {
        helpUI.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator FirstUIend()
    {
        yield return new WaitForSeconds(10f);
        firstUI.SetActive(false);
    }
}
