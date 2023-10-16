using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SpinningScript : MonoBehaviour
{
    public delegate void oncubestop();
    public oncubestop onstop;
    public float rotateX;
    public float rotateY;

    bool enterPressed;

    public bool stoppedSpinning = false;
    
    [SerializeField] List<face> possibleRotations = new();

    public int ran;

    float timer = 0;

    [SerializeField]
    List<hazards> faces = new List<hazards>();

    public hazards frontFaceHzd;

    [SerializeField]
    positionStopper ps;

    public hazards item;

    public bool HazardDetect = false;

    bool changeAngle;

    public face thisFace;
    // Start is called before the first frame update
    void Start()
    {
        rotateX /= 2; 
        rotateY /= 2;


        for (int i = 0; i < transform.childCount; i++)
        {
            faces.Add(transform.GetChild(i).gameObject.GetComponent<hazards>());
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (!enterPressed)
        {
            transform.Rotate(rotateX, 0, rotateY);
        }

        //if (enterPressed && !stoppedSpinning)
        //{

        //}

    }

    face getFrontFace()
    {
        foreach (hazards item in faces)
        {
            face faceInstance = item.GetComponent<face>();
            if (faceInstance.getName() == possibleRotations[ran].name)
            {
                frontFaceHzd = item;
                return faceInstance;

            }
        }
        print("null");
        return null;
    }
    public void setTrue()
    {
        enterPressed = true;
        changeAngle = true;
        var originalvalue = transform.localEulerAngles;

        var roundedangle = new Vector3(Mathf.Abs(Mathf.Round(originalvalue.x / 90) * 90), 0, Mathf.Abs(Mathf.Round(originalvalue.z / 90) * 90));
        float x = 0;
        float z = 0;

        x = Mathf.Abs(roundedangle.x - originalvalue.x);
       z = Mathf.Abs(roundedangle.z - originalvalue.z);

        if (originalvalue.x < 45 && originalvalue.z < 45 && changeAngle)
        {
            ran = 4;
            changeAngle = false;
        } 
        
        else if (originalvalue.x >= 315 && originalvalue.z >= 315 && changeAngle)
        {
            ran = 4;
            changeAngle = false;
        }     
        else
        {
            if (changeAngle)
            {

                if (x < z)
                {
                    roundedangle.z = 0;
                }
                else if (x > z)
                {
                    roundedangle.x = 0;
                }
                if (Mathf.Approximately(roundedangle.x, 90))
                {
                    ran = 1;
                    changeAngle = false;

                }
                else if (Mathf.Approximately(roundedangle.x, 180) || Mathf.Approximately(roundedangle.z, 180))
                {
                    ran = 5;
                    changeAngle = false;

                }
                else if (Mathf.Approximately(roundedangle.x, 270))
                {
                    ran = 2;
                    changeAngle = false;

                }
                else if (Mathf.Approximately(roundedangle.z, 90))
                {
                    ran = 0;
                    changeAngle = false;

                }
                else if (Mathf.Approximately(roundedangle.z, 270))
                {
                    ran = 3;
                    changeAngle = false;

                }
                else
                {
                    ran = Random.Range(0, possibleRotations.Count);
                    changeAngle = false;
                }
            }
        }

        timer = 0;

        StartCoroutine(StopPiece(possibleRotations[ran].rotation));
    }

    IEnumerator StopPiece(Vector3 rotation)
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime * 2;
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, rotation, timer);
        if (timer >= 1)
        {
            transform.localEulerAngles = rotation;

            getFrontFace();
            thisFace = possibleRotations[ran];
            onstop();
            stoppedSpinning = true;

            yield break;
        }
        yield return StopPiece(rotation);

    }

    public void findSafestFace(string pose)
    {
        HazardDetect = true;
        foreach (hazards face in faces)
        {
            if (face.poses.ToString() == pose)
            {
                item = face;
            }
        }
        setTrue(item.GetComponent<face>().rotation);
    }
    public void setTrue(Vector3 newRot)
    {
        enterPressed = true;

        timer = 0;

        transform.localEulerAngles = newRot;

        item = null;
        //StartCoroutine(StopPiece(newRot));
    }
}
