using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class uiStuff : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    [SerializeField]
    Slider progressSlider;

    float value;

    // Start is called before the first frame update
    void Start()
    {
        progressSlider.maxValue = 11;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            canvas.SetActive(true);

            progressSlider.value = value;

            if (progressSlider.value == progressSlider.maxValue)
                canvas.SetActive(false);
        }
    }

    public void onValueChange(float x)
    {
        value = x;
    }
}
