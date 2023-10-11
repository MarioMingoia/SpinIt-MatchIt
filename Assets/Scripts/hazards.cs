using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hazards : MonoBehaviour
{
    [SerializeField]
    SpinningScript parent;
    public enum Poses { APose, LeftHandUp, RightHandUp }
    public Poses poses;
    public enum Position { TopLeft, TopMid, TopRight, MidLeft, Mid, MidRight, BotLeft, BotMid, BotRight }
    public Position position;

    [SerializeField]
    List<SpinningScript> neighbours = new List<SpinningScript>();
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
                            print("Hazard Detected!");
                        }
                    }
                    if(position == Position.TopLeft)
                    {
                        if (poses == Poses.LeftHandUp)
                        {
                            print("Hazard Detected!");
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
                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.TopRight)
                    {
                        if (poses == Poses.RightHandUp)
                        {
                            print("Hazard Detected!");
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
                            print("Hazard Detected!");
                        }
                    }
                    if(position == Position.BotLeft)
                    {
                        if (poses != Poses.LeftHandUp)
                        {
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
                            print("Hazard Detected!");
                        }
                    }
                    if (position == Position.BotRight)
                    {
                        if (poses != Poses.RightHandUp)
                        {
                            print("Hazard Detected!");
                        }
                    }
                }
            }
            //IF MidLeft is RightHandUp pose, then the Top/BotLeft should also be RightHandUp pose or Apose

            //IF MidRight is LeftHandUp pose, then the Top/BotRight should also be LeftHandUp pose or Apose

            //IF TopRight

        }

    }
}
