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

    [SerializeField] List<AudioClip> cubeSFX = new();
    public static int cubeStopSFXi = 0;

    [SerializeField] List<AudioClip> charMusic = new();
    public static int charMusici = 0; 

    static int treeman = 0;
    static int rockman = 0;
    static int witch = 0;
    static int fairy = 0;
    static int drummer = 0;
    static int barbarian = 0;

    AudioSource source;
    [SerializeField] AudioSource charMusicSource;
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

        source = GetComponent<AudioSource>();
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
    void AddOnCharacters()
    {
        if(frontFaceHzd.character.ToString() == "Treeman")
        {
            treeman++;
        }
        if (frontFaceHzd.character.ToString() == "Rockman")
        {
            rockman++;
        }
        if (frontFaceHzd.character.ToString() == "Witch")
        {
            witch++;
        }
        if (frontFaceHzd.character.ToString() == "Fairy")
        {
            fairy++;
        }
        if (frontFaceHzd.character.ToString() == "Drummer")
        {
            drummer++;
        }
        if (frontFaceHzd.character.ToString() == "Barbarian")
        {
            barbarian++;
        }
    }
    static int max;
    static string ID ;
    public void CalculateCharacter()
    {
        max = treeman;
        ID = "0";
        if (rockman > max)
        {
            max = rockman;
            ID = "1";
        }
        if (witch > max)
        {
            max = witch;
            ID = "2";
        }
        if (fairy > max)
        {
            max = fairy;
            ID = "3";
        }
        if (drummer > max)
        {
            max = drummer;
            ID = "4";
        }
        if (barbarian > max)
        {
            max = barbarian;
            ID = "5";
        }
        charMusicSource.clip = charMusic[int.Parse(ID)];
        charMusicSource.Play();
    }
    public void setTrue()
    {

        enterPressed = true;
        changeAngle = true;
        reduced = true;
        particleSparks.SetActive(true);

        Vector3 originalvalue = transform.eulerAngles;

        Vector3 roundedangle = new Vector3(Mathf.Abs(Mathf.Round(originalvalue.x / 90) * 90), Mathf.Abs(Mathf.Round(originalvalue.y / 90) * 90), Mathf.Abs(Mathf.Round(originalvalue.y / 90) * 90));

        float x = Mathf.Abs(roundedangle.x - originalvalue.x);
        float y = Mathf.Abs(roundedangle.y - originalvalue.y);

        if (changeAngle)
        {

            if (x < y && reduced)
            {
                roundedangle.y = 0;
                print("x less than y");
                reduced = false;
            }
            else if (x > y && reduced)
            {
                roundedangle.x = 0;
                print("y less than x");
                reduced = false;
            }
            roundedangle.y = Mathf.Clamp(roundedangle.y, 0, 360);
            roundedangle.x = Mathf.Clamp(roundedangle.x, 0, 360);

            roundedangle = new Vector3(roundedangle.x, roundedangle.y, 0);

            if (Vector3.Equals(roundedangle, new Vector3(90,0, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(270, 180, roundedangle.z)))
            {
                //back face
                ran = 5;
                changeAngle = false;

            }
            else if (Vector3.Equals(roundedangle, new Vector3(180, 0, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(0, 180, roundedangle.z)))
            {
                //top face
                ran = 2;
                changeAngle = false;

            }
            else if (Vector3.Equals(roundedangle, new Vector3(270, 0, roundedangle.z)) ||  Vector3.Equals(roundedangle, new Vector3(90, 180, roundedangle.z)))
            {
                //front face
                ran = 4;
                changeAngle = false;

            }
            else if (Vector3.Equals(roundedangle, new Vector3(0, 90, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(180, 90, roundedangle.z)) ||  Vector3.Equals(roundedangle, new Vector3(90, 90, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(270, 90, roundedangle.z)))
            {
                //right face
                ran = 0;
                changeAngle = false;

            }
            else if (Vector3.Equals(roundedangle, new Vector3(0, 270, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(90, 270, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(180, 270, roundedangle.z)))
            {
                //left face
                ran = 3;
                changeAngle = false;

            }
            else if (Vector3.Equals(roundedangle, new Vector3(0, 0, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(360, 0, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(0, 360, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(360, 360, roundedangle.z)) || Vector3.Equals(roundedangle, new Vector3(180, 180, roundedangle.z)))
            {
                //bottom face
                ran = 1;
                changeAngle = false;
            }
            else
            {
                //top face
                ran = 2;
                changeAngle = false;

            }
        }

        timer = 0;
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
            AddOnCharacters();
            thisFace = possibleRotations[ran];
            StartCoroutine(sparklesHide());
            onstop();
            stoppedSpinning = true;

            source.clip = cubeSFX[cubeStopSFXi];
            source.Play();
            cubeStopSFXi++;
            yield break;
        }
        yield return StopPiece(rotation);

    }

    IEnumerator sparklesHide()
    {
        yield return new WaitForSeconds(.1f);
        particleSparks.SetActive(false);
        yield break;
    }
    public void findSafestFace2(string hzdFace)
    {
        HazardDetect = true;
        foreach (hazards face in faces)
        {
            if (face.character.ToString() == hzdFace)
            {
                item = face;
            }
        }
        setTrue(item.GetComponent<face>().rotation);
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
        frontFaceHzd = item;
        thisFace = frontFaceHzd.GetComponent<face>();
        item = null;

        //StartCoroutine(StopPiece(newRot));
    }
}
