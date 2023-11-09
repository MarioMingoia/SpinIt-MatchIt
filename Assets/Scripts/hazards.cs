using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class hazards : MonoBehaviour
{
    public  SpinningScript parent;
    public enum Poses { APose, LeftHandUp, RightHandUp }
    public Poses poses;
    public enum Position { TopLeft, TopMid, TopRight, MidLeft, Mid, MidRight, BotLeft, BotMid, BotRight}
    public Position position; 

    public enum Character {Treeman, Rockman, Witch, Fairy, Drummer, Barbarian}
    public Character character;

    public List<Character> hazardFace = new List<Character>();

    public List<Position> positionshzd = new List<Position>();

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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }                                    
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                            if (hazardFace.Count == 0 || positionshzd.Count == 0)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                            else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                            }
                            else
                            {
                                int i = 0;
                                int x = 0;
                                foreach (Character a in hazardFace)
                                {
                                    if (a != ss.frontFaceHzd.character)
                                    {
                                        i++;
                                        if (i > hazardFace.Count - 1)
                                            i = 0;
                                    }
                                    else
                                    {
                                        foreach (Position b in positionshzd)
                                        {

                                            if (ss.frontFaceHzd.position != b)
                                            {
                                                x++;
                                                if (x > positionshzd.Count - 1)
                                                    x = 0;
                                            }
                                            else
                                            {
                                                if (i == x)
                                                {
                                                    parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
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
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
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
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.BotMid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
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
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (ss.frontFaceHzd.position == Position.Mid)
                {
                    if (ss.frontFaceHzd.character != character)
                    {
                        if (hazardFace.Count == 0 || positionshzd.Count == 0)
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                        }
                        else if (!hazardFace.Contains(ss.frontFaceHzd.character) && !positionshzd.Contains(ss.frontFaceHzd.position))
                        {
                            parent.findSafestFace(ss.frontFaceHzd.poses.ToString());

                        }
                        else
                        {
                            int i = 0;
                            int x = 0;
                            foreach (Character a in hazardFace)
                            {
                                if (a != ss.frontFaceHzd.character)
                                {
                                    i++;
                                    if (i > hazardFace.Count - 1)
                                        i = 0;
                                }
                                else
                                {
                                    foreach (Position b in positionshzd)
                                    {

                                        if (ss.frontFaceHzd.position != b)
                                        {
                                            x++;
                                            if (x > positionshzd.Count - 1)
                                                x = 0;
                                        }
                                        else
                                        {
                                            if (i == x)
                                            {
                                                parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
