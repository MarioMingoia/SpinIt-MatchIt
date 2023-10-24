using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galleryMenu : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            if (Mathf.Abs(rotX) > Mathf.Abs(rotY))
                transform.Rotate(Vector3.up, -rotX, Space.World);
            if (Mathf.Abs(rotY) > Mathf.Abs(rotX))
                transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }
}
