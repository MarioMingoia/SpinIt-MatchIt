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
    List<Light> originalLights;

    [SerializeField]
    List<Light> togetherLights;

    [SerializeField]
    GameObject particleSparks;
    //I think in this script is where we want to handle hazards
    public void bringEverythingTogether(Vector3 target)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        amountdone += Time.deltaTime;

        for (int i = 0; i < originalLights.Count; i++)
        {
            originalLights[i].intensity -= Time.deltaTime;

            if (originalLights[i].intensity <= 0)
                originalLights[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < togetherLights.Count; i++)
        {

            if (togetherLights[i].intensity <= 6.1f)
                togetherLights[i].intensity += Time.deltaTime;
        }
        if (amountdone >= 13f)
            particleSparks.SetActive(true);

        if (amountdone >= 15f)
        {
            gm.GetComponent<reRollandStop>().startReRoll = true;
            StartCoroutine(sparklesHide());
        }
    }

    IEnumerator sparklesHide()
    {
        yield return new WaitForSeconds(2f);
        particleSparks.SetActive(false);
        yield break;
    }

}
