using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioClip RickRoll;
    public AudioClip Disconnect;
    public void PlayRickRoll()
    {
        Music.clip = RickRoll;
        Music.Play();
    }
    public void PlayDisconnect()
    {
        this.gameObject.GetComponent<VibeMaster>().Vibing = false;
        Music.clip = Disconnect;
        Music.Play();
    }
    public void Vibe()
    {
        this.gameObject.GetComponent<VibeMaster>().LetsGetThisVibe();
    }
}
