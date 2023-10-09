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
    // Start is called before the first frame update
    void Start()
    {
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
                stopSpinning = false;
            }
        }


        if (!stopSpinning && chosenObj != null)
        {
            rotator(chosenObj);

        }
    }

    public void rotator(GameObject chosen)
    {
        var vec = chosen.transform.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        chosen.transform.eulerAngles = Vector3.Lerp(chosen.transform.eulerAngles, vec, Time.deltaTime);


        if (Vector3.Angle(transform.eulerAngles, vec) == 0)
            StartCoroutine(waitfortime());
    }

    IEnumerator waitfortime()
    {
        yield return new WaitForSeconds(5);
        if (photoCount == 0)
        {
            tss.ssPhoto();
            photoCount++;
        }
    }
}
