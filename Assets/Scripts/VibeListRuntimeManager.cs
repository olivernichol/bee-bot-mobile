using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeListRuntimeManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Canvas;
    public GameObject EventSystem;
    void Update()
    {
        if ((SceneData.Status == 3) & (SceneData.TransitionRequested))
        {
            SceneData.TransitionRequested = false;
            Camera.SetActive(true);
            Canvas.SetActive(true);
            EventSystem.SetActive(true);

        }
    }
    public void BackToMain()
    {
        Camera.SetActive(false);
        Canvas.SetActive(false);
        EventSystem.SetActive(false);
        SceneData.Status = 1;
        SceneData.TransitionRequested = true;
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName("MainScene"));
    }
}
