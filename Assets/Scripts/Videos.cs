using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Video;

public class Videos : MonoBehaviour
{
    private bool hitFPS = false;
    public Rigidbody plyer;

    public double time;
    public double currentTime;

    public RawImage rawImage;

    public int num = -1;
    public VideoPlayer videoPlayer;

    public int t;

    private void Start()
    {
        rawImage.enabled = false;
        t = 60;
    }

    private void Update()
    {
        if (t < 61)
            t++;
        if (hitFPS && t > 60)
        {
            rawImage.enabled = true;
            currentTime = videoPlayer.time;
            if (currentTime >= time - 1)
            {
                videoPlayer.enabled = false;
                rawImage.enabled = false;
                //Destroy(videoPlayer, 0);
                //Destroy(rawImage, 0);

                plyer.GetComponent<FirstPersonController>().enabled = true;
                hitFPS = false;
                t = 0;
            }
        }
        if (hitFPS && Input.GetKeyDown(KeyCode.Space))
        {
            if (videoPlayer != null)
                videoPlayer.enabled = false;
            rawImage.enabled = false;
            videoPlayer.Pause();
            plyer.GetComponent<FirstPersonController>().enabled = true;
            hitFPS = false;
            t = 0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player" && t > 60)
        {
            if (num == -1)
                num = Hit.VideosNumber++;
            videoPlayer = UiControler.videoPlayerT[num];
            time = videoPlayer.clip.length;
            rawImage.enabled = true;
            videoPlayer.enabled = true;
            StartCoroutine(PlayVideo());
            plyer.GetComponent<FirstPersonController>().enabled = false;
            hitFPS = true;
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hitFPS = false;
        }
    }

    public bool OnHit()
    {
        return hitFPS;
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        //audioSource.Play();
    }
}
