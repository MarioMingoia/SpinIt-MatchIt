using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


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
    face origin;
    
    [SerializeField]
    face rerolled;
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

                    if (spin.item != null)
                    {
                        for (int i = 0; i < faces.Count; i++)
                        {
                            if (faces[i] == spin.item.GetComponent<face>())
                            {
                                faces[i] = null;
                                faces[i] = spin.item.GetComponent<face>();
                                spin.HazardDetect = false;
                                spin.item = null;

                                    if (!countofRightFace.Contains(spin.item.GetComponent<face>()))
                                        countofRightFace.Add(spin.item.GetComponent<face>());
                                    if (!countofBottomFace.Contains(spin.item.GetComponent<face>()))
                                        countofBottomFace.Add(spin.item.GetComponent<face>());
                                    if (!countofFrontFace.Contains(spin.item.GetComponent<face>()))
                                        countofFrontFace.Add(spin.item.GetComponent<face>());
                                    if (!countofLeftFace.Contains(spin.item.GetComponent<face>()))
                                        countofLeftFace.Add(spin.item.GetComponent<face>());
                                    if (!countofBackFace.Contains(spin.item.GetComponent<face>()))
                                        countofBackFace.Add(spin.item.GetComponent<face>());
                                    if (!countofTopFace.Contains(spin.item.GetComponent<face>()))
                                        countofTopFace.Add(spin.item.GetComponent<face>());
                                
                            }
                        }

                    }

                }

                if (!faces.Contains(spin.frontFaceHzd.GetComponent<face>()))
                {
                    faces.Add(spin.frontFaceHzd.GetComponent<face>());
                }
            }
        }


        //re-roll to the same image on that tile
        if (GetComponent<reRollandStop>().startReRoll)
        {
            origin = GetComponent<reRollandStop>().selectedFace;
            foreach (SpinningScript spin in ss)
            {
                if (spin.stoppedSpinning)
                {
                    if (spin.frontFaceHzd.GetComponent<face>() == origin)
                    {
                        print("achievement DOUBLE TROUBE Found");
                    }
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
        if (faces.Count >= 9)
        {
            //not having any hazards in the image
            if (hasThereBeenHazard == 0)
                print("achievement SAFE GAME Found");
            //having a perfect image
            if (countofBackFace.Count == 9 || countofBottomFace.Count == 9 || countofFrontFace.Count == 9 || countofTopFace.Count == 9 || countofLeftFace.Count == 9 || countofRightFace.Count == 9)
                print("achievement PERFECT IMAGE Found");
            //having an image with max 50% of same type
            if (countofBackFace.Count <= 5 || countofBottomFace.Count <= 5 || countofFrontFace.Count <= 5 || countofTopFace.Count <= 5 || countofLeftFace.Count <= 5 || countofRightFace.Count <= 5)
                print("achievement HALF AND HALF Found");
        }
    }
}
