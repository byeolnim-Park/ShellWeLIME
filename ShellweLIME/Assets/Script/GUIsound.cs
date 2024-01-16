using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIsound : MonoBehaviour
{
    public AudioClip GUIclip;
    public AudioClip buyclip;
    AudioSource AudioPlay;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GUI_Audio_standard()
    {
        AudioPlay.clip = GUIclip;
        AudioPlay.Play();
    }

    public void buy_sound()
    {
        AudioPlay.clip = buyclip;
        AudioPlay.Play();
    }
}
