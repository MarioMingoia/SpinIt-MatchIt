using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeTest : MonoBehaviour
{
    [SerializeField]
    float fadeValue;

    [SerializeField]
    bool changeFade;

    [SerializeField]
    bool deltatime;

    [SerializeField]
    float deltaTimeFade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeFade)
        {
            if (deltatime)
                GetComponent<CanvasGroup>().alpha -= fadeValue * Time.fixedDeltaTime;
            else
            {
                GetComponent<CanvasGroup>().alpha -= deltaTimeFade;
            }
        } 
        if (!changeFade)
        {
            if (deltatime)
                GetComponent<CanvasGroup>().alpha += fadeValue * Time.fixedDeltaTime;
            else
            {
                GetComponent<CanvasGroup>().alpha += deltaTimeFade;
            }
        }
    }
}
