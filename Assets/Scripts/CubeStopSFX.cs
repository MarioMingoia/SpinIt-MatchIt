using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeStopSFX 
{
    [SerializeField] AudioClip clip;
    [SerializeField] string ID;

    public AudioClip GetClip()
    {
        return clip;
    }
    public string GetID()
    {
        return ID;
    }
}
