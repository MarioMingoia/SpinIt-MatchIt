using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO ;

public class takeSS : MonoBehaviour
{
    [SerializeField] bool pointReached;

    public bool takenPhoto;

    public Texture2D photo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointReached)
        {

            if (takenPhoto == false)
            {

                ssPhoto();

                takenPhoto = true;
            }
        }
    }

    public void changeBool()
    {
        if (pointReached == false)
            pointReached = true;
    }

    public void ssPhoto()
    {

        string currentTime = System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)");
        string url = "screenshot " + currentTime + ".png";
        ScreenCapture.CaptureScreenshot(url);
        print("photo Taken");
        byte[] file = File.ReadAllBytes(url);
        photo = new Texture2D(4, 4);
        photo.LoadImage(file);
    }
}
