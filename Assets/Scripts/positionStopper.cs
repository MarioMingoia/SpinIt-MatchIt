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

    [SerializeField] AudioSource source;

    bool invoked = false;

    int rotateChange = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(fadeOut());
    }
    void Start()
    {
        int x = objects.Count; // will use for "for loop"

        for (int i = 0; i < x; i++)
        {
            int rand = Random.Range(0, objects.Count);
            realobjects.Add(objects[rand]);
            objects.RemoveAt(rand);
        }

        source = GetComponent<AudioSource>();

    }

    IEnumerator fadeOut()
    {
        yield return new WaitForFixedUpdate();
        panel.GetComponent<CanvasGroup>().alpha -= 0.01f;

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
            realobjects[listPicker].transform.parent.GetChild(1).gameObject.SetActive(true) ;


        }

        if (listPicker < realobjects.Count && Input.GetMouseButtonUp(0) && panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            if (previousCube)
            {
                if (rotateChange < 2)
                {
                    if (realobjects[listPicker].GetComponent<SpinningScript>().selectedFace != null)
                    {
                        realobjects[listPicker].GetComponent<SpinningScript>().changeSpinDirection();
                        rotateChange++;
                    }
                }
                else
                {
                    if (previousCube.stoppedSpinning && previousCube.item == null)
                    {
                        previousCube = realobjects[listPicker].GetComponent<SpinningScript>();


                        previousCube.GetComponent<SpinningScript>().setTrue();
                        realobjects[listPicker].transform.parent.GetComponent<MeshRenderer>().enabled = false;
                        realobjects[listPicker].transform.parent.GetChild(1).gameObject.SetActive(false);
                        listPicker++;


                        for (int i = 0; i < previousCube.transform.childCount; i++)
                        {
                            if (previousCube.transform.GetChild(i).GetComponent<face>())
                            {
                                previousCube.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                                previousCube.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false ;
                            }
                        }

                        rotateChange = 1;

                    }
                }

            }
            else
            {
                if (rotateChange < 2)
                {
                    if (realobjects[listPicker].GetComponent<SpinningScript>().selectedFace != null)
                    {
                        realobjects[listPicker].GetComponent<SpinningScript>().changeSpinDirection();
                        rotateChange++;
                    }
                }
                else
                {
                    previousCube = realobjects[listPicker].GetComponent<SpinningScript>();

                    previousCube.GetComponent<SpinningScript>().setTrue();
                    realobjects[listPicker].transform.parent.GetComponent<MeshRenderer>().enabled = false;
                    realobjects[listPicker].transform.parent.GetChild(1).gameObject.SetActive(false);
                    listPicker++;

                    for (int i = 0; i < previousCube.transform.childCount; i++)
                    {
                        if (previousCube.transform.GetChild(i).GetComponent<face>())
                        {

                            previousCube.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                            previousCube.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;

                        }
                    }
                    rotateChange = 1;


                }


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
        {
            Invoke("SetSeen", 3);
        }

    }
    void SetSeen()
    {
        if (invoked) { return; }
        bgmManager.instance.StopMusic();

        invoked = true;
        source.Play();
        print("Seen");
        seen = true;
        Invoke("PlayMusic", 5);
    }
    void PlayMusic()
    {
        previousCube.CalculateCharacter();
    }
}
