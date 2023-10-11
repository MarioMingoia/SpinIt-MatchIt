using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingTogether : MonoBehaviour
{
    [SerializeField]
    GameObject gm;

    [SerializeField]
    float amountdone;


    //I think in this script is where we want to handle hazards
    public void bringEverythingTogether(Vector3 target)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime);
        amountdone += Time.deltaTime;


        //transform.localEulerAngles = new Vector3(-90, 0, 0);

        if (amountdone >= 15f)
        {
            gm.GetComponent<reRollandStop>().startReRoll = true;
        }
    }

}
