using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reRollandStop : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spinningCube;

    [SerializeField]
    GameObject chosenObj;

    [SerializeField]
    takeSS tss;

    [SerializeField]
    bool pickRandom = true;

    [SerializeField]
    bool stopSpinning;

    [SerializeField]
    float reRollX;
    [SerializeField]
    float reRollY;

    [SerializeField]
    int photoCount;

    readonly Vector3 frontFace = new Vector3(0, 0, 0);
    readonly Vector3 bottomFace = new Vector3(90, 0, 0);
    readonly Vector3 backFace = new Vector3(180, 0, 0);
    readonly Vector3 topFace = new Vector3(270, 0, 0);
    readonly Vector3 rightFace = new Vector3(0, 0, 90);
    readonly Vector3 leftFace = new Vector3(0, 0, 270);
    List<Vector3> possibleRotations = new();

    int ran;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        possibleRotations.Add(frontFace);
        possibleRotations.Add(bottomFace);
        possibleRotations.Add(backFace);
        possibleRotations.Add(topFace);
        possibleRotations.Add(rightFace);
        possibleRotations.Add(leftFace);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0 && tss.takenPhoto)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!spinningCube.Contains(transform.GetChild(i).gameObject))
                {
                    spinningCube.Add(transform.GetChild(i).gameObject);
                }
            }

            if(spinningCube.Count > 8 && pickRandom)
            {
                chosenObj = spinningCube[Random.Range(0, spinningCube.Count)];

                pickRandom = false;
            }
        }

        if (chosenObj != null && stopSpinning)
        {
            reRollX = chosenObj.GetComponent<SpinningScript>().rotateX;
            reRollY = chosenObj.GetComponent<SpinningScript>().rotateY;
            chosenObj.transform.Rotate(reRollX, 0, reRollY);
            if (Input.GetKey(KeyCode.Return) && stopSpinning)
            {
                ran = Random.Range(0, possibleRotations.Count);
                stopSpinning = false;
                timer = 0;
            }
        }


        if (!stopSpinning && chosenObj != null)
        {
            StartCoroutine(StopPiece(ran));
        }
    }

    IEnumerator StopPiece(int i)
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime * 2;
        chosenObj.transform.eulerAngles = Vector3.Lerp(chosenObj.transform.eulerAngles, possibleRotations[i], timer);
        if (timer >= 1)
        {
            chosenObj.transform.eulerAngles = possibleRotations[i];
            if (photoCount == 0)
            {
                tss.ssPhoto();
                photoCount++;

            }
            yield break;
        }
        yield return StopPiece(i);

    }

}
