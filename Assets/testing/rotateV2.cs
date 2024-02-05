using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateV2 : MonoBehaviour
{
    [SerializeField]
    face selectedFace;

    [SerializeField]
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

    [SerializeField]
    LayerMask ignore;
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
        Ray ray1 = new Ray(transform.position, transform.forward * 1000);

        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
        
        Ray ray2 = new Ray(transform.position, transform.forward * -1000);

        Debug.DrawRay(transform.position, transform.forward * -1000, Color.blue);
        
        Ray ray3 = new Ray(transform.position, transform.right * 1000);

        Debug.DrawRay(transform.position, transform.right * 1000, Color.green);
        
        Ray ray4 = new Ray(transform.position, transform.right * -1000);

        Debug.DrawRay(transform.position, transform.right * -1000, Color.yellow);  
        
        Ray ray5 = new Ray(transform.position, transform.up * -1000);

        Debug.DrawRay(transform.position, transform.up * -1000, Color.white);
        
        Ray ray6 = new Ray(transform.position, transform.up * 1000);

        Debug.DrawRay(transform.position, transform.up * 1000, Color.black);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray1, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");

                if (Physics.Raycast(ray1, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            else if (Physics.Raycast(ray2, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                if (Physics.Raycast(ray2, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            else if (Physics.Raycast(ray3, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                if (Physics.Raycast(ray3, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            else if (Physics.Raycast(ray4, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                if (Physics.Raycast(ray4, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            else if (Physics.Raycast(ray5, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                if (Physics.Raycast(ray5, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            else if (Physics.Raycast(ray6, out hit, 1000, ~ignore) && hit.collider.transform.name == "check")
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                if (Physics.Raycast(ray6, out hit, 1000) && hit.collider.transform.name.Contains("Face"))
                {
                    Debug.Log(hit.transform.name);
                    selectedFace = hit.transform.GetComponent<face>();
                }
            }
            rotater++;

            if (rotater > 2)
            {
                enterPressed = true;
                transform.eulerAngles = selectedFace.rotation;
            }
        }
    }
}
