using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findCamera : MonoBehaviour
{
    [SerializeField]
    bool isSeen;

    public positionStopper ps;

    public float range;

    GameObject parent;

    [SerializeField]
    Vector3 targetpos;

    private void Start()
    {
        parent = gameObject.transform.parent.transform.parent.gameObject;

    }
    public void Update()
    {
        isSeen = ps.seen;

        if (isSeen)
        {
            RaycastStuff();
        }

    }

    void RaycastStuff()
    {

        Ray ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * range, Color.red);
        //has the ray go from the front of the player
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range) && hit.transform.gameObject.CompareTag("removeParent"))
        {
            transform.parent = null;
            transform.parent = null;
            parent.SetActive(false);

            transform.parent = hit.transform;

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetpos, Time.deltaTime);
        }
    }
}
