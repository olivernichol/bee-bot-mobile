using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Bee : MonoBehaviour
{
    public int BeeNum;
    public Text NoOfBees;
    public Button BeeButton;
    public Button TomatButton;
    void Start()
    {
        if (!UnityEngine.PlayerPrefs.HasKey("UserName"))
        {
            UnityEngine.PlayerPrefs.SetString("UserName", "AnAndroidUser");
        }
        if (!UnityEngine.PlayerPrefs.HasKey("TimeoutState"))
        {
            UnityEngine.PlayerPrefs.SetInt("TimeoutState", 1);
        }
        if (!UnityEngine.PlayerPrefs.HasKey("IP"))
        {
            UnityEngine.PlayerPrefs.SetString("IP", "BEEBOTSERVERIP");
        }
    }
    public void BeeButtonClick()
    {
        StartCoroutine(BeeRequest());
        BeeNum += 1;
        if (UnityEngine.PlayerPrefs.GetInt("TimeoutState") == 1)
        {
            StartCoroutine(Cooldown3Seconds());
        }
    }
    public void SHOOTTHEBEES()
    {
        StartCoroutine(TomatRequest());
        BeeNum = 0;
        if (UnityEngine.PlayerPrefs.GetInt("TimeoutState") == 1)
        {
            StartCoroutine(Cooldown3Seconds());
        } 
    }
    private void Update()
    {
        NoOfBees.text = "Bees: " + BeeNum;
    }
    IEnumerator Cooldown3Seconds()
    {
        BeeButton.interactable = false;
        TomatButton.interactable = false;
        yield return new WaitForSeconds(3);
        BeeButton.interactable = true;
        TomatButton.interactable = true;
    }
    IEnumerator BeeRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("platform", "android");
        form.AddField("username", UnityEngine.PlayerPrefs.GetString("Username"));
        Debug.Log("Sending Web Request Now.");
        using (UnityWebRequest www = UnityWebRequest.Post(UnityEngine.PlayerPrefs.GetString("IP") + "/bbeadd", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.responseCode);
            }
        }
    }
    IEnumerator TomatRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("platform", "android");
        form.AddField("username", UnityEngine.PlayerPrefs.GetString("Username"));
        Debug.Log("Sending Web Request Now.");
        using (UnityWebRequest www = UnityWebRequest.Post(UnityEngine.PlayerPrefs.GetString("IP") + "/bbekill", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.responseCode);
            }
        }
    }
}
