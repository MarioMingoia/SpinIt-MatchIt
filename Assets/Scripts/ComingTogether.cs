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
    float speed;

    [SerializeField]
    bool sparklesEnabled;

    [SerializeField]
    GameObject sparkles;

    [SerializeField]
    float timer;

    SpinningScript spinning;
    private void Start()
    {
        spinning = GetComponent<SpinningScript>();
    }
    private void Update()
    {
        
    }
    //I think in this script is where we want to handle hazards
    public void bringEverythingTogether(Vector3 target)
    {

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        amountdone += Time.deltaTime;

        if (amountdone > 5 && sparklesEnabled)
        {
            timer = 0;
            sparkles.SetActive(true);
            sparklesEnabled = false;

            StartCoroutine(timeToDisableSparkles());
        }

        if (amountdone >= 15f)
        {
            gm.GetComponent<reRollandStop>().startReRoll = true;
        }
    }

    IEnumerator timeToDisableSparkles()
    {
        yield return new WaitForFixedUpdate();
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            sparkles.SetActive(false);

            yield break;
        }
        yield return timeToDisableSparkles();
    }

}
