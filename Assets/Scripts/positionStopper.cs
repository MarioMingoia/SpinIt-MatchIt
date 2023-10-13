using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positionStopper : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public List<GameObject> realobjects = new List<GameObject>();

    [SerializeField]
    int listPicker = 0;

    [SerializeField] int counter = 0;

    public bool seen;

    public SpinningScript previousCube;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        int x = objects.Count; // will use for "for loop"

        for (int i = 0; i < x; i++)
        {
            int rand = Random.Range(0, objects.Count);
            realobjects.Add(objects[rand]);
            objects.RemoveAt(rand);
        }

        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        yield return new WaitForFixedUpdate();
        panel.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;

        if (panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            yield break;
        }
        yield return fadeOut();

    }

    // Update is called once per frame
    void Update()
    {
        if (listPicker <= realobjects.Count - 1)
        {
            realobjects[listPicker].transform.parent.GetComponent<MeshRenderer>().enabled = true;
            
        }

        if (listPicker < realobjects.Count && Input.GetKeyUp(KeyCode.Return) && panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            if (previousCube)
            {
                if (previousCube.stoppedSpinning && previousCube.item == null)
                {
                    previousCube = realobjects[listPicker].GetComponent<SpinningScript>();

                    realobjects[listPicker].GetComponent<SpinningScript>().setTrue();
                    realobjects[listPicker].transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    listPicker++;

                }
            }
            else
            {
                previousCube = realobjects[listPicker].GetComponent<SpinningScript>();

                realobjects[listPicker].GetComponent<SpinningScript>().setTrue();
                realobjects[listPicker].transform.parent.GetComponent<MeshRenderer>().enabled = false;
                listPicker++;
            }

        }

        if (listPicker == 9 && counter < 9)
        {
            foreach (GameObject item in realobjects)
            {
                if (item.GetComponent<SpinningScript>().stoppedSpinning == true)
                {
                    //realobjects.Remove(item);
                    counter++;
                }
            }
        }

        if (counter >= 9)
            Invoke("SetSeen", 3);
    }
    void SetSeen()
    {
        seen = true;
    }
   
}
