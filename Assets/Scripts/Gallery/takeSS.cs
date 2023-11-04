using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO ;
using System;
using System.Reflection;

public class takeSS : MonoBehaviour
{
    [SerializeField] bool pointReached;

    public bool takenPhoto;

    public Texture2D photo;

    int i;
    // Start is called before the first frame update
    void Start()
    {
        photo = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointReached)
        {
            ssPhoto();
        }

    }

    public void changeBool()
    {
        if (pointReached == false && takenPhoto == false)
            pointReached = true;
    }

    public void ssPhoto()
    {
        if (photo == null && takenPhoto == false)
        {
            //string currentTime = System.DateTime.Now.ToString("MM_dd_yy_HH_mm_ss");
            //string url = "screenshot" + i + currentTime + ".png";
            //ScreenCapture.CaptureScreenshot(url);
            //print("photo Taken");
            //Byte[] file = File.ReadAllBytes(url);

            //photo = new Texture2D(4, 4);

            //photo.LoadImage(file);
            //takenPhoto = true;

            //i ++;

            StartCoroutine(takeScreenshot());


        }
    }

    IEnumerator takeScreenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D ss = ScreenCapture.CaptureScreenshotAsTexture();
        photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        photo.SetPixels(ss.GetPixels());
        photo.Apply();
        takenPhoto = true;
    }
}
