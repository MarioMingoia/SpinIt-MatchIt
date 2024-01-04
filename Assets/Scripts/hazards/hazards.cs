using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hazards : MonoBehaviour
{
    public  SpinningScript parent;
    public enum Poses { APose, LeftHandUp, RightHandUp }
    public Poses poses;
    public enum Position { TopLeft, TopMid, TopRight, MidLeft, Mid, MidRight, BotLeft, BotMid, BotRight}
    public Position position; 

    public enum Character {Treeman, Rockman, Witch, Fairy, Drummer, Barbarian}
    public Character character;

    [SerializeField]
    List<SpinningScript> neighbours = new List<SpinningScript>();
    
    [SerializeField]
    List<SpinningScript> myneighbours = new List<SpinningScript>();

    [SerializeField]
    topleft tl;

    [SerializeField]
    topMid tm;

    [SerializeField]
    topRight tr;

    [SerializeField]
    midLeft ml;

    [SerializeField]
    mid m;

    [SerializeField]
    midRight mr;

    [SerializeField]
    botLeft bl;

    [SerializeField]
    botMid bm;

    [SerializeField]
    botRight br;

    //if all lists are empty or if it does not contain the character otherwise check pose hazards
    [SerializeField]
    List<MonoBehaviour> noHazards = new List<MonoBehaviour>();
    private void Start()
    {
        tl = GetComponent<topleft>();   
        tm = GetComponent<topMid>();   
        tr = GetComponent<topRight>();

        ml = GetComponent<midLeft>();   
        m = GetComponent<mid>();
        mr = GetComponent<midRight>();

        bl = GetComponent<botLeft>();   
        bm = GetComponent<botMid>();   
        br = GetComponent<botRight>();   
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
        foreach (SpinningScript ss in myneighbours.Where(ss => ss.stoppedSpinning == true))
        {
            neighbours.Add(ss);

            string hazardName = ss.frontFaceHzd.character.ToString();
            Position pos = ss.frontFaceHzd.position;

            if (pos == Position.BotRight)
            {
                if (!noHazards.Contains(br))
                {
                    if (br.posCharacter.Count <= 0)
                        noHazards.Add(br);
                    else if (!br.posCharacter.Contains(hazardName))
                        noHazards.Add(br);
                }
            }
            if (pos == Position.BotMid)
            {
                if (!noHazards.Contains(bm))
                {
                    if (bm.posCharacter.Count <= 0)
                        noHazards.Add(br);
                    else if (!bm.posCharacter.Contains(hazardName))
                        noHazards.Add(bm);
                }
            }
            if (pos == Position.BotLeft)
            {
                if (!noHazards.Contains(bl))
                {
                    if (bl.posCharacter.Count <= 0)
                        noHazards.Add(bl);
                    else if (!bl.posCharacter.Contains(hazardName))
                        noHazards.Add(bl);
                }
            }
            if (pos == Position.MidLeft)
            {
                if (!noHazards.Contains(ml))
                {
                    if (ml.posCharacter.Count <= 0)
                        noHazards.Add(ml);
                    else if (!ml.posCharacter.Contains(hazardName))
                        noHazards.Add(ml);
                }
            }
            if (pos == Position.Mid)
            {
                if (!noHazards.Contains(m))
                {
                    if (m.posCharacter.Count <= 0)
                        noHazards.Add(m);
                    else if (!bm.posCharacter.Contains(hazardName))
                        noHazards.Add(m);
                }
            }
            if (pos == Position.MidRight)
            {
                if (!noHazards.Contains(mr))
                {
                    if (mr.posCharacter.Count <= 0)
                        noHazards.Add(mr);
                    else if (!mr.posCharacter.Contains(hazardName))
                        noHazards.Add(mr);
                }
            }
            if (pos == Position.TopLeft)
            {
                if (!noHazards.Contains(tl))
                {
                    if (tl.posCharacter.Count <= 0)
                        noHazards.Add(tl);
                    else if (!ml.posCharacter.Contains(hazardName))
                        noHazards.Add(tl);
                }
            }
            if (pos == Position.TopMid)
            {
                if (!noHazards.Contains(tm))
                {
                    if (tm.posCharacter.Count <= 0)
                        noHazards.Add(tm);
                    else if (!bm.posCharacter.Contains(hazardName))
                        noHazards.Add(tm);
                }
            }
            if (pos == Position.TopRight)
            {
                if (!noHazards.Contains(tr))
                {
                    if (tr.posCharacter.Count <= 0)
                        noHazards.Add(tr);
                    else if (!tr.posCharacter.Contains(hazardName))
                        noHazards.Add(tr);
                }
            }
        }

        
        checkHazards();
    }

    void checkHazards()
    {
        foreach (SpinningScript ss in neighbours)
        {
            if (noHazards.Count == 9)
            {
                print("pose hazards");

                if (position == Position.BotLeft)
                {
                    if (ss.frontFaceHzd.position == Position.MidLeft)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopLeft)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
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
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopRight)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
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
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopLeft)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
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
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopRight)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
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
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.BotLeft)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
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
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.BotRight)
                    {
                        if (ss.frontFaceHzd.poses != poses)
                        {
                            if (ss.frontFaceHzd.character != character)
                            {
                                parent.findSafestFace(ss.frontFaceHzd.poses.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                print("Unique Hazards");
                //if there are unique hazards in different positions, add to respective part. I.e. add topMid to the below if statement

                //left
                if (position == Position.TopLeft)
                {
                    if (ss.frontFaceHzd.position == Position.BotLeft)
                    {
                        if (bl.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            //if the script contains this character, rotate to the character
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.MidLeft)
                    {
                        if (ml.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.MidLeft)
                {
                    if (ss.frontFaceHzd.position == Position.BotLeft)
                    {
                        if (bl.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopLeft)
                    {
                        if (tl.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.BotLeft)
                {
                    if (ss.frontFaceHzd.position == Position.MidLeft)
                    {
                        if (ml.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.TopLeft)
                    {
                        if (tl.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }

                //mid
                if (position == Position.TopMid)
                {
                    if (ss.frontFaceHzd.position == Position.BotMid)
                    {
                        if (bm.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.Mid)
                    {
                        if (m.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.BotMid)
                {
                    if (ss.frontFaceHzd.position == Position.TopMid)
                    {
                        if (tm.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.Mid)
                    {
                        if (m.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.Mid)
                {
                    if (ss.frontFaceHzd.position == Position.TopMid)
                    {
                        if (tm.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.BotMid)
                    {
                        if (bm.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }

                //right
                if (position == Position.TopRight)
                {
                    if (ss.frontFaceHzd.position == Position.MidRight)
                    {
                        if (mr.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.BotRight)
                    {
                        if (br.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.MidRight)
                {
                    if (ss.frontFaceHzd.position == Position.TopRight)
                    {
                        if (tr.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.BotRight)
                    {
                        if (br.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
                if (position == Position.BotRight)
                {
                    if (ss.frontFaceHzd.position == Position.TopRight)
                    {
                        if (tr.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                    if (ss.frontFaceHzd.position == Position.MidRight)
                    {
                        if (mr.posCharacter.Contains(ss.frontFaceHzd.character.ToString()))
                        {
                            parent.findSafestFace2(ss.frontFaceHzd.character.ToString());
                        }
                    }
                }
            
            }

        }

    }
}
