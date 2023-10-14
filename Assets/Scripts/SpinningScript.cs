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
        print("Original " + originalvalue);

        var roundedangle = new Vector3(Mathf.Round(originalvalue.x / 90) * 90, 0, Mathf.Round(originalvalue.z / 90) * 90);

        if (roundedangle.z < 180)
            roundedangle.z = 90;
        if (roundedangle.z >= 180)
            roundedangle.z = 270;

        if (roundedangle.x >= 360)
            roundedangle = new Vector3(0, 0, roundedangle.z);
        if (roundedangle.z >= 360)
            roundedangle = new Vector3(roundedangle.x, 0, 0);

        float x = roundedangle.x - originalvalue.x;
        float z = roundedangle.z - originalvalue.z;

        x = Mathf.Abs(x);
        z = Mathf.Abs(z);

        if (originalvalue.x < 45 && originalvalue.z < 45 && changeAngle)
        {
            print(roundedangle);
            print("Front Face: 0,0,0");
            ran = 4;
            changeAngle = false;
        }
        
        if (x < z && changeAngle)
        {
            print("x less than z");
            z = 0;
            print(roundedangle.x + " " + roundedangle.y + " " + roundedangle.z);
            if (Mathf.Approximately(roundedangle.x,90))
            {
                print("Bottom face: 90,0,0");
                ran = 1;
            }

            if (Mathf.Approximately(roundedangle.x,180))
            {
                print("Back face: 180,0,0");
                ran = 5;
            }
            if (Mathf.Approximately(roundedangle.x,270))
            {
                print("Top face: 270,0,0");
                ran = 2;
            }
            changeAngle = false;
        }
        if (x > z && changeAngle)
        {
            print("z less than x");
            print(roundedangle.x + " " +  roundedangle.y + " " + roundedangle.z);
            x = 0;
            if (Mathf.Approximately(roundedangle.z,90))
            {
                print("Right face: 0,0,90");
                ran = 0;
            }

            if (Mathf.Approximately(roundedangle.z,270))
            {
                print("Left face: 0,0,270");
                ran = 3;
            }    
            changeAngle = false;
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
        print(item.parent);
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
