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

    int ran;

    float timer = 0;

    [SerializeField]
    List<hazards> faces = new List<hazards>();

    public hazards frontFaceHzd;

    [SerializeField]
    positionStopper ps;
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
        ran = Random.Range(0, possibleRotations.Count);

        timer = 0;

        StartCoroutine(StopPiece(ran));
    }

    IEnumerator StopPiece(int i)
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime * 2;
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, possibleRotations[i].rotation, timer);
        if (timer >= 1)
        {
            transform.localEulerAngles = possibleRotations[i].rotation;

            getFrontFace();

            onstop();
            stoppedSpinning = true;

            yield break;
        }
        yield return StopPiece(i);

    }

    IEnumerator waitfortime()
    {
        yield return new WaitForSeconds(5);
    }
}
