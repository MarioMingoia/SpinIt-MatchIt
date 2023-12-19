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
    float newRX;

    [SerializeField]
    float newRY;

    [SerializeField]
    float speed;

    [SerializeField] bool enterPressed;

    public bool stoppedSpinning = false;
    
    [SerializeField] List<face> possibleRotations = new();
    [SerializeField] List<face> originalpossibleRotations = new();

    public int ran;

    float timer = 0;

    [SerializeField]
    List<hazards> posfaces = new List<hazards>();
    [SerializeField]
    List<hazards> faces = new List<hazards>();

    public hazards frontFaceHzd;

    [SerializeField]
    positionStopper ps;

    public hazards item;

    public bool HazardDetect = false;

    public face thisFace;

    bool ranX;
    bool ranY;

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

    public    bool changeRotation;
    
    public face selectedFace;

    public    LayerMask ignore;

    public Light hzdlight;

    private void Awake()
    {
        int x = originalpossibleRotations.Count; // will use for "for loop"

        for (int i = 0; i < x; i++)
        {
            int rand = Random.Range(0, originalpossibleRotations.Count);
            possibleRotations.Add(originalpossibleRotations[rand]);
            originalpossibleRotations.RemoveAt(rand);
        }

        hzdlight = transform.parent.transform.GetChild(2).GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<hazards>() != null)
                posfaces.Add(transform.GetChild(i).gameObject.GetComponent<hazards>());
            else
            {
                particleSparks = transform.GetChild(i).gameObject;
            }
        }

        int y = posfaces.Count; // will use for "for loop"

        for (int i = 0; i < y; i++)
        {
            int rand = Random.Range(0, posfaces.Count);
            faces.Add(posfaces[rand]);
            posfaces.RemoveAt(rand);
        }

        ranX = Random.value > .5f;
        ranY = Random.value > .5f;

        source = GetComponent<AudioSource>();

        for (int i = 0; i < particleSparks.transform.childCount; i++)
        {
            ParticleSystem p = particleSparks.transform.GetChild(i).GetComponent<ParticleSystem>();
            p.Stop();
            p.enableEmission = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (enterPressed == false)
        {
            foreach (face item in possibleRotations)
            {
                if (selectedFace != null)
                {
                    if (item.getName() == selectedFace.getName())
                    {
                        selectedFace.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        item.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
            if (changeRotation)
            {
                if (ranX)
                    rotateX = speed * -1;
                else
                {
                    rotateX = speed;
                }
                newRY = 0;
                newRX = rotateX;
            }
            else
            {
                if (ranY)
                    rotateY = speed * -1;
                else
                {
                    rotateY = speed;
                }
                newRX = 0;
                newRY = rotateY;
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Input.mousePosition, Vector3.forward * 1000, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, ~ignore))
            {

                if (Input.GetMouseButtonDown(0))
                {
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }

            transform.Rotate(newRX, newRY, 0, Space.World);
        }



    }

    

    face getFrontFace()
    {
        foreach (hazards item in faces)
        {
            face faceInstance = item.GetComponent<face>();
            if (faceInstance.getName() == selectedFace.name)
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

    public void changeSpinDirection()
    {
        changeRotation = true;

    }
    public void setTrue()
    {
        enterPressed = true;

        for (int i = 0; i < particleSparks.transform.childCount; i++)
        {
            ParticleSystem p = particleSparks.transform.GetChild(i).GetComponent<ParticleSystem>();
            p.Play();
            p.enableEmission = true;
        }


        timer = 0;
        StartCoroutine(StopPiece(selectedFace.rotation));
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
            thisFace = selectedFace;
            StartCoroutine(sparklesHide());
            onstop();
            stoppedSpinning = true;

            if (cubeStopSFXi < cubeSFX.Count)
                source.clip = cubeSFX[cubeStopSFXi];
            source.Play();

            if (cubeStopSFXi < cubeSFX.Count)
                cubeStopSFXi++;
            yield break;
        }
        yield return StopPiece(rotation);

    }

    IEnumerator sparklesHide()
    {
        yield return new WaitForSeconds(.1f);

        for (int i = 0; i < particleSparks.transform.childCount; i++)
        {
            ParticleSystem p = particleSparks.transform.GetChild(i).GetComponent<ParticleSystem>();
            p.Stop();
            p.enableEmission = false;
        }
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

                hzdlight.gameObject.SetActive(true);
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

                hzdlight.gameObject.SetActive(true);

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

        StartCoroutine(disableLight());
    }

    IEnumerator disableLight()
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            hzdlight.gameObject.SetActive(false);
            yield break;
        }
        yield return disableLight();
    }
}
