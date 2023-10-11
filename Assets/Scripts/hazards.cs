using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hazards : MonoBehaviour
{
    public  SpinningScript parent;
    public enum Poses { APose, LeftHandUp, RightHandUp }
    public Poses poses;
    public enum Position { TopLeft, TopMid, TopRight, MidLeft, Mid, MidRight, BotLeft, BotMid, BotRight }
    public Position position;

    [SerializeField]
    List<SpinningScript> neighbours = new List<SpinningScript>();

    [SerializeField]
    List<hazards> nextSafestFace = new List<hazards>();

    int ran;

    private void Start()
    {
        ran = Random.Range(0, nextSafestFace.Count);
    }
    private void OnEnable()
    {
        parent = transform.parent.GetComponent<SpinningScript>();
        parent.onstop += findNeighbourCubes;
    }

    private void OnDisable()
    {
        parent.onstop -= findNeighbourCubes;
    }
    void findNeighbourCubes()
    {
        print("FindNeighbours");
        foreach (SpinningScript ss in FindObjectsOfType<SpinningScript>().Where(ss => ss.stoppedSpinning == true))
        {
            neighbours.Add(ss);
        }
        checkHazards();
    }

    void checkHazards()
    {
        foreach (SpinningScript ss in neighbours)
        {
            //IF BotLeft/BotRight faces is APose, Then Mid/TopRight cannot be RightHandUp pose, and Mid/TopLeft cannot be LeftHandUpPose DONE!!
            if (ss.frontFaceHzd.position == Position.BotLeft)
            {
                if (ss.frontFaceHzd.poses == Poses.APose)
                {
                    if(position == Position.MidLeft)
                    {
                        if(poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());
                            print("Hazard Detected!");

                        }
                    }
                    if(position == Position.TopLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }

                }
            }
            else if (ss.frontFaceHzd.position == Position.BotLeft)
            {
                if (ss.frontFaceHzd.poses == Poses.LeftHandUp)
                {
                    if (position == Position.MidLeft)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.LeftHandUp.ToString());
                        }
                    }
                    if (position == Position.TopLeft)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.LeftHandUp.ToString());
                        }
                    }
                }
            }
            if(ss.frontFaceHzd.position == Position.BotRight)
            {
                if (ss.frontFaceHzd.poses == Poses.APose)
                {
                    if (position == Position.MidRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.TopRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
            else if (ss.frontFaceHzd.position == Position.BotRight)
            {
                if (ss.frontFaceHzd.poses == Poses.RightHandUp)
                {
                    if (position == Position.TopRight)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.RightHandUp.ToString());
                        }
                    }
                    if (position == Position.MidRight)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.RightHandUp.ToString());
                        }
                    }
                }
            }
            //IF MidLeft is LeftHandUp pose, then the TopLeft should also be LeftHandUp pose,
            if (ss.frontFaceHzd.position == Position.MidLeft)
            {
                if(ss.frontFaceHzd.poses == Poses.LeftHandUp)
                {
                    if(position == Position.TopLeft)
                    {
                        if(poses != Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.BotLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
            else if (ss.frontFaceHzd.position == Position.MidLeft)
            {
                if (ss.frontFaceHzd.poses == Poses.APose)
                {
                    if (position == Position.TopLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());
                        }
                    }
                    if (position == Position.BotLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }

            //IF MidRight is RightHandUp pose, then the TopRight should also be RightHandUp pose
            if (ss.frontFaceHzd.position == Position.MidRight)
            {
                if (ss.frontFaceHzd.poses == Poses.RightHandUp)
                {
                    if (position == Position.TopRight)
                    {
                        if (poses != Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.BotRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
            else if (ss.frontFaceHzd.position == Position.MidRight)
            {
                if (ss.frontFaceHzd.poses == Poses.RightHandUp)
                {
                    if (position == Position.TopRight)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.RightHandUp.ToString());
                        }
                    }
                    if (position == Position.BotRight)
                    {
                        if (poses == Poses.APose)
                        {
                            parent.findSafestFace(Poses.RightHandUp.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
            //IF TopRight
            if (ss.frontFaceHzd.position == Position.TopLeft)
            {
                if (ss.frontFaceHzd.poses == Poses.LeftHandUp)
                {
                    if (position == Position.MidLeft)
                    {
                        if (poses != Poses.LeftHandUp)
                        {
                            ss.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.BotLeft)
                    {
                        if (poses != Poses.LeftHandUp)
                        {
                            ss.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }

            }
            else if (ss.frontFaceHzd.position == Position.TopLeft)
            {
                if (ss.frontFaceHzd.poses == Poses.APose)
                {
                    if (position == Position.MidLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());
                        }
                    }
                    if (position == Position.BotLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
            //IF TopLeft
            if (ss.frontFaceHzd.position == Position.TopRight)
            {
                if (ss.frontFaceHzd.poses == Poses.RightHandUp)
                {
                    if (position == Position.MidRight)
                    {
                        if (poses != Poses.RightHandUp)
                        {
                            ss.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.BotRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }

            }
            else if (ss.frontFaceHzd.position == Position.TopRight)
            {
                if (ss.frontFaceHzd.poses == Poses.APose)
                {
                    if (position == Position.MidRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());
                        }
                    }
                    if (position == Position.BotRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            parent.findSafestFace(Poses.APose.ToString());

                            print("Hazard Detected!");
                        }
                    }
                }
            }
        }

    }
}
