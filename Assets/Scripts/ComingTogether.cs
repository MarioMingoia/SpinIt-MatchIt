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
            //this is where we want to call the code to take a screenshot
            //if we want the screenshot to be taken, i think it would be a good idea to ask the player before it being taken
            //i.e. "do you want a photo taken?"
            gm.GetComponent<takeSS>().changeBool();
        }
    }

}
