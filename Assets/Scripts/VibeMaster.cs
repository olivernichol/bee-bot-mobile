using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeMaster : MonoBehaviour
{
    public AudioClip[] Vibes;
    public AudioSource Music;
    public bool Vibing;
    public int VibeNum;
    public void LetsGetThisVibe()
    {
        Vibing = true;
        VibeNum = Random.Range(0, 36);
        Music.clip = Vibes[VibeNum];
        Music.Play();
    }
    private void Update()
    {
        if ((!Music.isPlaying) && (Vibing))
        {
            VibeNum = Random.Range(0, 36);
            Music.clip = Vibes[VibeNum];
            Music.Play();
        }
    }
}
