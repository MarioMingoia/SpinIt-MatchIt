using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class imageManager : MonoBehaviour
{
    [SerializeField]
    takeSS tss;

    List<Texture2D> pictures = new List<Texture2D>();

    [SerializeField]
    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!pictures.Contains(tss.photo))
            {
                pictures.Add(tss.photo);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 0; i < cube.transform.childCount; i++)
            {
                if (cube.transform.GetChild(i).GetComponent<MeshRenderer>().material.ToString() == "emptySides")
                {
                }
            }
        }
    }
}
