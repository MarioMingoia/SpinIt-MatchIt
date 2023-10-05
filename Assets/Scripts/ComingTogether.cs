using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingTogether : MonoBehaviour
{
    [SerializeField]
    GameObject gm;

    [SerializeField]
    float amountdone;

    [SerializeField]
    string hazardName;

    [SerializeField]
    bool hazards;

    //I think in this script is where we want to handle hazards
    public void bringEverythingTogether(Vector3 target, bool detectHazards)
    {
        hazards = detectHazards;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime);
        amountdone += Time.deltaTime;

        //if we do want there to be an input to bring them all together, don't comment the below line out and make sure the uiStuff script is enabled
        transform.parent.GetComponent<uiStuff>().onValueChange(amountdone);

        transform.localEulerAngles = new Vector3(-90, 0, 0);

        if (amountdone >= 11.01f)
        {
            //this is where we want to call the code to take a screenshot
            //if we want the screenshot to be taken, i think it would be a good idea to ask the player before it being taken
            //i.e. "do you want a photo taken?"
            gm.GetComponent<takeSS>().changeBool();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == hazardName && hazards)
            print("Collided with hazard " + hazardName + " " + gameObject.name);
    }
}
