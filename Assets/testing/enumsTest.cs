using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumsTest : MonoBehaviour
{
    public enum Character { Treeman, Rockman, Witch, Fairy, Drummer, Barbarian }
    public Character character;

    public enumsTest2 et2;
    // Start is called before the first frame update
    void Start()
    {
        if (et2.posCharacter.Contains(character))
            Debug.Log(character.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
