using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMgr : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        op.allowSceneActivation = false;
        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                //·Îµù
            }
            else
            {
                timer += Time.unscaledDeltaTime;

                if (timer > 5f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

}
