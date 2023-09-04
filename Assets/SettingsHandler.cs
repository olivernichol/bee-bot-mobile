using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public Slider VolumeSlider;
    public InputField Username;
    public InputField Password;
    public InputField IP;
    public Dropdown UpdateServer;
    public Toggle Timeout;
    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.value = AudioListener.volume;
        Username.text = UnityEngine.PlayerPrefs.GetString("UserName");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckAccuracies()
    {
        VolumeSlider.value = AudioListener.volume;
        Username.text = UnityEngine.PlayerPrefs.GetString("UserName");
        if (UnityEngine.PlayerPrefs.GetInt("TimeoutState") == 1)
        {
            Timeout.isOn = true;
        }
        else
        {
            Timeout.isOn = false;
        }
    }
    public void ServerChanged(int State)
    {
        if (State == 0)
        {
            IP.interactable = false;
            UnityEngine.PlayerPrefs.SetString("IP", "BEEBOTSERVERIP");
        }
        else
        {
            IP.interactable = true;
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }
    public void ChangeUserName()
    {
        if (Username.text == "")
        {
            UnityEngine.PlayerPrefs.SetString("Username", "AnAndroidUser");
        }
        UnityEngine.PlayerPrefs.SetString("UserName", Username.text);
    }
    public void CheckPassword()
    {
        if (Password.text == "BYPASS_PASSWORD") Timeout.interactable = true;
    }
    public void TimeOutStateChanged()
    {
        if (Timeout.isOn)
        {
            UnityEngine.PlayerPrefs.SetInt("TimeoutState", 1);
        }
        else if (!Timeout.isOn)
        {
            UnityEngine.PlayerPrefs.SetInt("TimeoutState", 0);
        }
    }
    public void customIPChanged()
    {
        UnityEngine.PlayerPrefs.SetString("IP", IP.text);
    }
}
