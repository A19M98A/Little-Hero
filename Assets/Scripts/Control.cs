using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Control : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    //public AudioSource audioSource;
    // Use this for initialization

    public double time;
    public double currentTime;


    void Start()
    {
        time = videoPlayer.clip.length;
    }

    private void Update()
    {
        currentTime = videoPlayer.time;
        if (currentTime >= time - 1)
        {
            videoPlayer.enabled = false;
            rawImage.enabled = false;
            Destroy(videoPlayer, 0);
            Destroy(rawImage, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            videoPlayer.enabled = false;
            rawImage.enabled = false;
            Destroy(videoPlayer, 0);
            Destroy(rawImage, 0);
            videoPlayer.Pause();
        }
    }
}
