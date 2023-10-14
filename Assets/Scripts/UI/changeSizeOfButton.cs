using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class changeSizeOfButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Vector3 originalScale;
    public Vector3 multipledScale;

    public float multiplyer;

    [SerializeField]
    bool scaleUp;

    [SerializeField]
    bool scaleDown;

    float timer;

    private void Start()
    {
        originalScale = this.transform.localScale;
        multipledScale = originalScale * multiplyer;

        scaleDown = false;
        scaleUp = false;
    }

    private void Update()
    {

        if (scaleUp)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, multipledScale, Time.deltaTime * 10);
            if (timer >= 1)
            {
                scaleUp = false;
            }
        }
        if (scaleDown)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 10);
            if (timer >= 1)
            {
                scaleDown = false;
            }
        }

    }

    public void OnPointerEnter(PointerEventData data)
    {
        //this.transform.localScale = new Vector2(originalScale.x * multiplyer, originalScale.y * multiplyer);
        scaleUp = true;
        timer = 0;
    }

    public void OnPointerExit(PointerEventData data)
    {
        //this.transform.localScale = originalScale;
        scaleDown = true;
        timer = 0;
    }
}
