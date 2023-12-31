using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class achievementManager : MonoBehaviour
{
    [SerializeField]
    List<SpinningScript> ss = new List<SpinningScript>();

    [SerializeField]
    List<face> faces = new List<face>();

    [SerializeField]
    int hasThereBeenHazard;

    [SerializeField]
    List<face> countofFrontFace;
    [SerializeField]
    List<face> countofBackFace;    
    [SerializeField]
    List<face> countofLeftFace;    
    [SerializeField]
    List<face> countofRightFace;    
    [SerializeField]
    List<face> countofTopFace;
    [SerializeField]
    List<face> countofBottomFace;


    [SerializeField]
    GameObject origin;

    [SerializeField]
    GameObject newFace;

    [SerializeField]
    GameObject achievementNoHazard;
    
    [SerializeField]
    GameObject achievement5050;
    
    [SerializeField]
    GameObject achievementPerfect;
    
    [SerializeField]
    GameObject achievementTwiceInARow;

    public List<GameObject> achievementCounter;

    [SerializeField]
    showReturnButton srb;

    [SerializeField]
    float speed;

    [SerializeField]
    SpinningScript reRolledSS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpinningScript spin in ss)
        {
            if (spin.stoppedSpinning)
            {
                if (spin.HazardDetect)
                {
                    hasThereBeenHazard++;
                    spin.HazardDetect = false;
                }



                if (spin.item != null)
                {
                    for (int i = 0; i < faces.Count; i++)
                    {
                        if (faces[i] == spin.item.GetComponent<face>())
                        {
                            faces[i] = null;
                            faces[i] = spin.item.GetComponent<face>();
                            spin.item = null;
                        }
                    }

                }

                if (!faces.Contains(spin.frontFaceHzd.GetComponent<face>()))
                {
                    faces.Add(spin.frontFaceHzd.GetComponent<face>());
                }
            }
        }



        if (faces.Count > 0)
        {
            foreach (face face in faces)
            {
                if (face.getName() == "rightFace")
                {
                    if (!countofRightFace.Contains(face))
                        countofRightFace.Add(face);
                }
                if (face.getName() == "bottomFace")
                {
                    if (!countofBottomFace.Contains(face))
                        countofBottomFace.Add(face);
                }
                if (face.getName() == "frontFace")
                {
                    if (!countofFrontFace.Contains(face))
                        countofFrontFace.Add(face);
                }
                if (face.getName() == "leftFace")
                {
                    if (!countofLeftFace.Contains(face))
                        countofLeftFace.Add(face);
                }
                if (face.getName() == "bottomFace")
                {
                    if (!countofBackFace.Contains(face))
                        countofBackFace.Add(face);
                }
                if (face.getName() == "topFace")
                {
                    if (!countofTopFace.Contains(face))
                        countofTopFace.Add(face);
                }
            }
        }
        

        if (GetComponent<reRollandStop>().tss.takenPhoto)
        {
            if (faces.Count >= 9)
            {
                //not having any hazards in the image
                if (hasThereBeenHazard == 0)
                {
                    if (!achievementCounter.Contains(achievementNoHazard))
                    {
                        achievementNoHazard.SetActive(true);

                        achievementCounter.Add(achievementNoHazard);
                        achievementNoHazard.GetComponent<moveAchievementsUp>().speed = speed;
                    }
                }
                //having a perfect image
                if (countofBackFace.Count == 9 || countofBottomFace.Count == 9 || countofFrontFace.Count == 9 || countofTopFace.Count == 9 || countofLeftFace.Count == 9 || countofRightFace.Count == 9)
                {
                    if (!achievementCounter.Contains(achievementPerfect))
                    {
                        achievementPerfect.SetActive(true);

                        achievementCounter.Add(achievementPerfect);
                        achievementPerfect.GetComponent<moveAchievementsUp>().speed = speed;
                    }
                }
                //having an image with max 50% of same type
                if (countofBackFace.Count <= 5 && countofBottomFace.Count <= 5 && countofFrontFace.Count <= 5 && countofTopFace.Count <= 5 && countofLeftFace.Count <= 5 && countofRightFace.Count <= 5)
                {
                    if (!achievementCounter.Contains(achievement5050))
                    {
                        achievement5050.SetActive(true);

                        achievementCounter.Add(achievement5050);
                        achievement5050.GetComponent<moveAchievementsUp>().speed = speed;
                    }
                }
            }

            //re-roll to the same image on that tile
            if (GetComponent<reRollandStop>().startReRoll)
            {
                reRolledSS = GetComponent<reRollandStop>().chosenObj;

                if (reRolledSS.stoppedSpinning)
                {
                    if (origin == null)
                        origin = GetComponent<reRollandStop>().selectedFace.gameObject;
                    print(origin);
                    if (newFace == null)
                     newFace = reRolledSS.thisFace.gameObject;
                    print(newFace);
                    if (ReferenceEquals(origin, newFace))
                    {
                        if (!achievementCounter.Contains(achievementTwiceInARow))
                        {
                            achievementTwiceInARow.SetActive(true);

                            achievementCounter.Add(achievementTwiceInARow);
                            achievementTwiceInARow.GetComponent<moveAchievementsUp>().speed = speed;
                        }
                    }
                }
            }
            srb.enabled = true;
        }
    }
}
