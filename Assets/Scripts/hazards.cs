using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazards : MonoBehaviour
{
    //this is to check if the face is in direct view of the camera
    public bool thisFaceSeen = false;

    //has all of the faces that are hazards to this face in a list i.e. face5 on rightarm and face5 on rightaccessory
    [SerializeField]
    List<GameObject> hazardFacesCubes;

    [SerializeField]
    float range = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycastStuff();

        if (thisFaceSeen)
        {
            foreach (GameObject obj in hazardFacesCubes)
            {
                bool hazardFaceSeen = obj.GetComponent<hazards>().thisFaceSeen;

                if (hazardFaceSeen)
                {
                    obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x + 90, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 90);
                }
            }
        }

    }

    public void raycastStuff()
    {
        Ray ray = new Ray(transform.position, transform.up);
        //has the ray go from the front of the player
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.up * range, Color.red);

        if (Physics.Raycast(ray, out hit, range) && hit.transform.CompareTag("bringFaceTogether"))
        {
            thisFaceSeen = true;
        }
        else
        {
            thisFaceSeen = false;
        }
    }
}
