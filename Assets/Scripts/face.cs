using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class face : MonoBehaviour
{
    public Vector3 rotation;


    public string getName()
    {
        return gameObject.name;
    }
}
