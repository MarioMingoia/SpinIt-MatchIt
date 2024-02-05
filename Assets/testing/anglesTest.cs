using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anglesTest : MonoBehaviour
{
    [SerializeField]
    face selectedFace;

    int rotater = 1;

    public float rotateX;
    public float rotateY;

    [SerializeField]
    float newRX;

    [SerializeField]
    float newRY;

    [SerializeField]
    float speed;

    bool enterPressed = false;


    bool ranX;
    bool ranY;
    // Start is called before the first frame update
    void Start()
    {
        ranX = Random.value > .5f;
        ranY = Random.value > .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enterPressed)
        {
            if (rotater == 1)
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
            else if (rotater == 2)
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


            transform.Rotate(newRX, newRY, 0, Space.World);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Input.mousePosition, transform.forward * 1000, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");

            if (Input.GetMouseButtonDown(0))
            {
                selectedFace = hit.transform.GetComponent<face>();
                rotater++;

                if (rotater > 2)
                {
                    enterPressed = true;
                    transform.eulerAngles = selectedFace.rotation;
                }
            }
        }
    }
}
