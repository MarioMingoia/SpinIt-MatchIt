using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HazardsManager : MonoBehaviour
{
    public List<SpinningScript> cubes = new();
    public static HazardsManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public hazards ReturnSpecifiedHazard(string position)
    {
        print(position);
        foreach(SpinningScript cube2 in cubes)
        {
            print(cube2);
            if (cube2.frontFaceHzd)
            {
                if (cube2.frontFaceHzd.position.ToString() == position)
                {
                    print(cube2.frontFaceHzd);
                    return cube2.frontFaceHzd;
                }
            }
            

        }
        return null;
    }
}
