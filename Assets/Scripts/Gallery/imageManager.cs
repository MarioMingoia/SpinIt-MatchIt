using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class imageManager : MonoBehaviour
{
    [SerializeField]
    takeSS tss;

    [SerializeField]
    List<Texture2D> pictures = new List<Texture2D>();

    [SerializeField]
    GameObject cube;

    [SerializeField]
    int replaceAt = 0;
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
                tss = FindObjectOfType<takeSS>();
            }
            else
            {
                if (!pictures.Contains(tss.photo) && tss.photo != null)
                {

                    if (pictures.Count > 3)
                    {
                        pictures[replaceAt] = null;
                        pictures[replaceAt] = tss.photo;
                        replaceAt++;

                        if (replaceAt >= pictures.Count)
                            replaceAt = 0;
                    }
                    else
                    {
                        pictures.Add(tss.photo);
                    }


                }
            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (cube == null)
            {

                cube = GameObject.Find("mainMenuCube");
            }    
            if (pictures.Count > 0 && cube != null)
            {

                for (int i = 0; i < cube.transform.childCount; i++)
                {
                    if (i > pictures.Count || i > 3)
                        break;
                    
                    if (cube.transform.GetChild(i).GetComponent<MeshRenderer>().material.name.Contains("emptySides"))
                    {
                        Material mat = new Material(cube.transform.GetChild(i).GetComponent<MeshRenderer>().material);
                        mat.mainTexture = pictures[i];
                        mat.color = Color.white;
                        mat.mainTextureOffset = new Vector2(0.37f, 0.24f);
                        mat.mainTextureScale = new Vector2(0.27f, 0.51f);
                        cube.transform.GetChild(i).GetComponent<MeshRenderer>().material = mat;
                    }
                }
            }
        }
    }
}
