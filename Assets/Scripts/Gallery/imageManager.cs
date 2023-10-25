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
            if (tss == null)
            {
                print("find tss");
                tss = FindObjectOfType<takeSS>();
            }
            else
            {
                if (!pictures.Contains(tss.photo))
                {
                    print("found tss");

                    pictures.Add(tss.photo);
                }
            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (cube == null)
            {
                print("find cube");

                cube = GameObject.Find("mainMenuCube");
            }    
            if (pictures.Count > 0 && cube != null)
            {
                print("found cube");

                for (int i = 0; i < cube.transform.childCount; i++)
                {
                    if (i > pictures.Count)
                        return;
                    if (cube.transform.GetChild(i).GetComponent<MeshRenderer>().material.ToString() == "emptySides")
                    {
                        cube.transform.GetChild(i).GetComponent<MeshRenderer>().material.mainTexture = pictures[i];
                    }
                }
            }
        }
    }
}
