using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Canvas;
    public GameObject EventSystem;
    public Text Progress;

    void Start()
    {
        StartCoroutine(LoadMainScene());
    }
    //void StartMainScene()
    //{
        //Debug.Log("StartMainScene Function Started.");
        //Camera.SetActive(false);
        //Canvas.SetActive(false);
        //EventSystem.SetActive(false);
        //SceneData.Status = 1;
        //SceneData.TransitionRequested = true;
        //UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("MainScene"));
    //}
    IEnumerator LoadMainScene()
    {
        AsyncOperation loadMainScene = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainScene");

        while (!loadMainScene.isDone)
        {
            Progress.text = (loadMainScene.progress * 100) + "%";
            if (loadMainScene.progress >= 0.9f)
            {
                loadMainScene.allowSceneActivation = true;
                //StartMainScene();
            }
            yield return null;
        }
    }
}
