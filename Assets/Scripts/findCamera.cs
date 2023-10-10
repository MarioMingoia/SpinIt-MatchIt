using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findCamera : MonoBehaviour
{
    [SerializeField]
    bool isSeen;

    public positionStopper ps;

    [SerializeField]
    Vector3 targetpos;

    [SerializeField]
    GameObject newParent;

    private void Start()
    {


    }
    public void Update()
    {
        isSeen = ps.seen;

        if (isSeen)
        {
            if (!transform.parent.CompareTag("bringFaceTogether"))
            {
                transform.parent = null;
                transform.parent = newParent.transform;
            }

            else
            {
                GetComponent<ComingTogether>().bringEverythingTogether(targetpos);
            }
        }

        
    }
}
