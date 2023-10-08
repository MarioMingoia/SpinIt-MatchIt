using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeSS : MonoBehaviour
{
    [SerializeField] bool pointReached;

    public bool takenPhoto;
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
                print("photo Taken");

                //string currentTime = System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)");
                //ScreenCapture.CaptureScreenshot("screenshot " + currentTime + ".png");
                takenPhoto = true;
            }
        }
    }

    public void changeBool()
    {
        if (pointReached == false)
            pointReached = true;
    }
}
