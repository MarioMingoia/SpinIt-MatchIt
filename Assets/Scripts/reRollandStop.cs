using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reRollandStop : MonoBehaviour
{
    [SerializeField]
    List<SpinningScript> spinningCube;

    public SpinningScript chosenObj;

    public    takeSS tss;

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

    public bool startReRoll;

    public face selectedFace;
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
        if (transform.childCount > 0 && startReRoll)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!spinningCube.Contains(transform.GetChild(i).GetComponent<SpinningScript>()))
                {
                    spinningCube.Add(transform.GetChild(i).GetComponent<SpinningScript>());
                    
                }
            }

            if(spinningCube.Count > 8 && pickRandom)
            {
                ran = Random.Range(0, spinningCube.Count);

                chosenObj = spinningCube[ran];
                if (selectedFace == null)
                    selectedFace = chosenObj.thisFace;
                pickRandom = false;
            }

            if (chosenObj != null && stopSpinning)
            {
                reRollX = chosenObj.rotateX;
                reRollY = chosenObj.rotateY;

                chosenObj.gameObject.transform.Rotate(reRollX, reRollY, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.Return) && stopSpinning)
            {
                chosenObj.setTrue();
                stopSpinning = false;
                timer = 0;
                StartCoroutine(StopPiece());

            }

        }
    }

    IEnumerator StopPiece()
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime * 2;
        if (timer >= 1)
        {
            tss.changeBool();
            yield break;
        }
        yield return StopPiece();

    }

}
