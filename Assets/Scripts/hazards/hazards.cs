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

    [System.Serializable]
    public class Hazards
    {
        public Character listOfCharacter;
        public Position listOfPosition;
        

        public Hazards(Character charter, Position pos)
        {
            listOfCharacter = charter;
            listOfPosition = pos;
        }
    }
    public List<Hazards> characterPos = new List<Hazards>();

    public List<MonoBehaviour> possHazards = new List<MonoBehaviour>();

    //if all secondary lists are empty or if it does not contain the character otherwise check pose hazards
    [SerializeField]
    List<MonoBehaviour> noHazards = new List<MonoBehaviour>();
    private void Start()
    {
        possHazards.Add(GetComponent<topleft>());   
        possHazards.Add(GetComponent<topRight>());   
        possHazards.Add(GetComponent<topMid>());

        possHazards.Add(GetComponent<midLeft>());   
        possHazards.Add(GetComponent<midRight>());
        possHazards.Add(GetComponent<midRight>());

        possHazards.Add(GetComponent<botLeft>());   
        possHazards.Add(GetComponent<botRight>());   
        possHazards.Add(GetComponent<botMid>());   
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
        }
        checkHazards();
    }

    void checkHazards()
    {
        foreach (SpinningScript ss in neighbours)
        {
            if (characterPos.Exists(t => t.listOfCharacter != ss.frontFaceHzd.character) || characterPos.Exists(t => t.listOfPosition != ss.frontFaceHzd.position))
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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

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
                                print("pose hazards found");

                            }
                        }
                    }
                }
            }
            else
            {
                print("unique hazards");

                foreach (Hazards a in characterPos)
                {
                    print(a.ToString());

                    if (ss.frontFaceHzd.character.ToString() == a.listOfCharacter.ToString() && ss.frontFaceHzd.position.ToString() == a.listOfPosition.ToString())
                    {
                        parent.findSafestFace2(a.listOfCharacter.ToString());
                        print("unique hazards found");

                    }
                }
            }

        }

    }
}
