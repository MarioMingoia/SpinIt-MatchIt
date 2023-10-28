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

    public enum Character { None,Treeman, Rockman, Witch, Fairy, Drummer, Barbarian}
    public Character character;

    [System.Flags]
    public enum nameFace { None = 0, Treeman = 1, Rockman = 2, Witch = 4, Fairy = 8, Drummer = 16, Barbarian = 32}
    public nameFace hazardFace;
    public nameFace safeFace;

    [System.Flags]
    public enum Positions { None = 0, TopLeft = 1, TopMid = 2, TopRight = 4, MidLeft = 8, Mid = 16, MidRight =32, BotLeft = 64, BotMid = 128, BotRight = 256}
    public Positions positionshzd;

    [SerializeField]
    List<SpinningScript> neighbours = new List<SpinningScript>();


    private void Start()
    {
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
            if(position== Position.BotLeft)
            {
                if(ss.frontFaceHzd.position == Position.MidLeft)
                {
                    if(ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {

                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.positionshzd.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.TopLeft)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            if (position == Position.BotRight)
            {
                if (ss.frontFaceHzd.position == Position.MidRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.TopRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            if (position == Position.MidLeft)
            {
                if (ss.frontFaceHzd.position == Position.BotLeft)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.TopLeft)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            if (position == Position.MidRight)
            {
                if (ss.frontFaceHzd.position == Position.BotRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.TopRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            if (position == Position.TopLeft)
            {
                if (ss.frontFaceHzd.position == Position.MidLeft)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotLeft)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            if (position == Position.TopRight)
            {
                if (ss.frontFaceHzd.position == Position.MidRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotRight)
                {
                    if (ss.frontFaceHzd.poses != poses)
                    {
                        if (ss.frontFaceHzd.character != character)
                        {
                            if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                            {
                                parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                            }
                            else
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }



            if (position == Position.TopMid)
            {
                if (ss.frontFaceHzd.position == Position.Mid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
            }  
            if (position == Position.Mid)
            {
                if (ss.frontFaceHzd.position == Position.TopMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
            }
            if (position == Position.BotMid)
            {
                if (ss.frontFaceHzd.position == Position.TopMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.Mid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (ss.frontFaceHzd.character.ToString() == hazardFace.ToString() && ss.frontFaceHzd.position.ToString() == positionshzd.ToString())
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.safeFace.ToString());
                        }
                        else
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                    }
                }
            }
        }

    }
}
