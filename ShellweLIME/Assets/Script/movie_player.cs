using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class movie_player : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("shelterScene");
    }
}
