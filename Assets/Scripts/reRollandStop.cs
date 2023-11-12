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

    bool photoTaken = false;
    public face selectedFace;

    int rotateChange = 1;
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
                if (rotateChange == 1)
                {
                    reRollX = chosenObj.rotateX;
                    reRollY = 0;
                }
                else
                {
                    reRollY = chosenObj.rotateY;
                    reRollX = 0;
                }
                chosenObj.gameObject.transform.Rotate(reRollX, reRollY, 0, Space.World);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(Camera.main.transform.position, Vector3.forward * 1000, Color.green);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, ~chosenObj.ignore))
                {
                    Debug.Log(hit.transform.name);

                    if (Input.GetMouseButtonDown(0))
                    {
                        print("select");
                        chosenObj.selectedFace = hit.transform.GetComponent<face>();
                        print(selectedFace.name);
                    }
                }
            }

            if (Input.GetMouseButtonUp(0) && stopSpinning)
            {
                if (rotateChange < 2)
                {
                    chosenObj.changeSpinDirection();
                    rotateChange++;
                }
                else
                {
                    chosenObj.setTrue();
                    stopSpinning = false;
                    timer = 0;
                    StartCoroutine(StopPiece());
                }


            }

        }
    }

    IEnumerator StopPiece()
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime;
        if (timer >= 2.5f)
        {
            if (!photoTaken)
            {
                tss.changeBool();
                photoTaken = true;
            }
            yield break;
        }
        yield return StopPiece();

    }

}
