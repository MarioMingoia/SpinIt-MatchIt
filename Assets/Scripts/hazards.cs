using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hazards : MonoBehaviour
{
    [SerializeField]
    SpinningScript parent;
    enum Poses { APose, LeftHandUp, RightHandUp }
    [SerializeField] Poses poses;
    enum Position { TopLeft, TopMid, TopRight, MidLeft, Mid, MidRight, BotLeft, BotMid, BotRight }
    [SerializeField] Position position;

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
           // if(ss.getFrontFace().position == ss.getFrontFace().)
            //IF BotLeft/BotRight faces is APose, Then Mid/TopRight cannot be RightHandUp pose, and Mid/TopLeft cannot be LeftHandUpPose

            //IF MidLeft is LeftHandUp pose, then the TopLeft should also be LeftHandUp pose

            //IF MidRight is RightHandUp pose, then the TopRight should also be RightHandUp pose

            //IF MidLeft is RightHandUp pose, then the Top/BotLeft should also be RightHandUp pose or Apose

            //IF MidRight is LeftHandUp pose, then the Top/BotRight should also be LeftHandUp pose or Apose

            //IF MidRight is LeftHandUp pose, then the Top/BotRight should also be LeftHandUp pose or Apose

        }

    }
}
