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

    [SerializeField]
    float speed;

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

    bool ranX;
    bool ranY;

    bool reduced;

    [SerializeField]
    GameObject particleSparks;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<hazards>() != null)
                faces.Add(transform.GetChild(i).gameObject.GetComponent<hazards>());
            else
            {
                particleSparks = transform.GetChild(i).gameObject;
            }
        }

        ranX = Random.value > .5f;
        ranY = Random.value > .5f;

    }


    // Update is called once per frame
    void Update()
    {

        if (!enterPressed)
        {
            if (ranX)
                rotateX = speed * -1;
            else
            {
                rotateX = speed;
            }
            if (ranY)
                rotateY = speed * -1;
            else
            {
                rotateY = speed;
            }
            transform.Rotate(rotateX, rotateY, 0, Space.World);
        }

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
        reduced = true;
        particleSparks.SetActive(true);

        var originalvalue = transform.eulerAngles;

        var roundedangle = new Vector3(Mathf.Abs(Mathf.Round(originalvalue.x / 90) * 90), Mathf.Abs(Mathf.Round(originalvalue.y / 90) * 90), 0);

        float x = Mathf.Abs(roundedangle.x - originalvalue.x);
        float y = Mathf.Abs(roundedangle.y - originalvalue.y);

        roundedangle.x = Mathf.Clamp(roundedangle.x, 0, 315);
        roundedangle.y = Mathf.Clamp(roundedangle.y, 0, 315);

        if (changeAngle)
        {

            if (x < y && reduced)
            {
                roundedangle.y = 0;
                reduced = false;
            }
            else if (x > y && reduced)
            {
                roundedangle.x = 0;
                reduced = false;
            }
            
            if (Mathf.Approximately(roundedangle.x, 90) )
            {
                //back face
                ran = 5;
                changeAngle = false;

            }
            if (Mathf.Approximately(roundedangle.x, 0) && Mathf.Approximately(roundedangle.y, 0))
            {
                //bottom face
                ran = 1;
                changeAngle = false;
            }
            if (Mathf.Approximately(roundedangle.x, 180) || Mathf.Approximately(roundedangle.y, 180))
            {
                //top face
                ran = 2;
                changeAngle = false;

            }
            if (Mathf.Approximately(roundedangle.x, 270))
            {
                //front face
                ran = 4;
                changeAngle = false;

            }
            if (Mathf.Approximately(roundedangle.y, 90))
            {
                //right face
                ran = 0;
                changeAngle = false;

            }
            if (Mathf.Approximately(roundedangle.y, 270))
            {
                //left face
                ran = 3;
                changeAngle = false;

            }
        }

        timer = 0;
        print(originalvalue);
        print(ran + " " + possibleRotations[ran].rotation);
        StartCoroutine(StopPiece(possibleRotations[ran].rotation));
    }

    IEnumerator StopPiece(Vector3 rotation)
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotation, timer);
        if (timer >= 1)
        {
            transform.eulerAngles = rotation;

            getFrontFace();
            thisFace = possibleRotations[ran];
            StartCoroutine(sparklesHide());
            onstop();
            stoppedSpinning = true;

            yield break;
        }
        yield return StopPiece(rotation);

    }

    IEnumerator sparklesHide()
    {
        yield return new WaitForSeconds(.5f);
        particleSparks.SetActive(false);
        yield break;
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

        transform.eulerAngles = newRot;

        item = null;
        //StartCoroutine(StopPiece(newRot));
    }
}
