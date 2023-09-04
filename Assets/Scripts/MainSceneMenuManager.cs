using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMenuManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Canvas;
    public GameObject EventSystem;
    public bool AllowSceneChanging;
    public GameObject Notice;
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }
    void Update()
    {
        if ((SceneData.Status == 1) & (SceneData.TransitionRequested))
        {
            SceneData.TransitionRequested = false;
            Camera.SetActive(true);
            Canvas.SetActive(true);
            EventSystem.SetActive(true);
        }
    }
    public void ChangeLog()
    {
        if (AllowSceneChanging)
        {
            Camera.SetActive(false);
            Canvas.SetActive(false);
            EventSystem.SetActive(false);
            SceneData.Status = 2;
            SceneData.TransitionRequested = true;
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("Changelog"));
        }
        else
        {
            StartCoroutine(Notify());
        }
    }
    public void VibeList()
    {
        if (AllowSceneChanging)
        {
            Camera.SetActive(false);
            Canvas.SetActive(false);
            EventSystem.SetActive(false);
            SceneData.Status = 3;
            SceneData.TransitionRequested = true;
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("VibeList"));
        }
        else
        {
            StartCoroutine(Notify());
        }
    }
    public void Settings()
    {
        if (AllowSceneChanging)
        {
            Camera.SetActive(false);
            Canvas.SetActive(false);
            EventSystem.SetActive(false);
            SceneData.Status = 4;
            SceneData.TransitionRequested = true;
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("Settings"));
        }
        else
        {
            StartCoroutine(Notify());
        }
    }
    IEnumerator LoadMainScene()
    {
        AsyncOperation loadChangeLog = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Changelog", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        AsyncOperation loadSettings = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Settings", UnityEngine.SceneManagement.LoadSceneMode.Additive);

        while (!loadChangeLog.isDone | !loadSettings.isDone)
        {
            if (loadChangeLog.progress >= 0.9f && loadSettings.progress >= 0.9f)
            {
                AllowSceneChanging = true;
            }
            yield return null;
        }
    }
    IEnumerator Notify()
    {
        Notice.SetActive(true);
        yield return new WaitForSeconds(3);
        Notice.SetActive(false);
    }
}
