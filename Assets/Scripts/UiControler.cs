using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UiControler : MonoBehaviour
{
    public RawImage[] rawImages = new RawImage[100];
    public static RawImage[] rawImagesT;

    public RawImage[] UiImage = new RawImage[100];
    public static RawImage[] UiImageT;

    public VideoPlayer[] videoPlayer = new VideoPlayer[16];
    public static VideoPlayer[] videoPlayerT;

    public RawImage Map, I1, I2, I3;
    public static RawImage MapT, I1T, I2T, I3T;

    public RawImage M, MK, MB;
    public static RawImage MT, MKT, MBT;

    public RawImage vid;

    private void Start()
    {
        rawImagesT = rawImages;
        UiImageT = UiImage;
        videoPlayerT = videoPlayer;
        for (int i = 4; i < 100; i++)
        {
            if (UiImage[i] != null)
                UiImage[i].enabled = false;
        }
        for (int i = 0; i < 100; i++)
        {
            if (rawImages[i] != null)
                rawImages[i].enabled = false;
        }
        MapT = Map;
        I1T = I1;
        I2T = I2;
        I3T = I3;
        Map.enabled = false;
        I1.enabled = false;
        I2.enabled = false;
        I3.enabled = false;

        MT = M;
        MKT = MK;
        MBT = MB;
        MT.enabled = false;
        MK.enabled = false;
        MB.enabled = false;

        vid.enabled = false;
    }
}
