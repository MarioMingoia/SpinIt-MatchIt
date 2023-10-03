using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour
{
    [SerializeField]
    float rotateX;
    [SerializeField]
    float rotateY;
    bool enterPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!enterPressed)
            transform.Rotate(rotateX, rotateY, 0);

        if (enterPressed)
        {
            var vec = transform.eulerAngles;
            vec.x = Mathf.Round(vec.x / 90) * 90;
            vec.y = Mathf.Round(vec.y / 90) * 90;
            vec.z = 0;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, vec, Time.deltaTime);

            if (Vector3.Angle(transform.eulerAngles, vec) == 0)
                StartCoroutine(waitfortime());
        }

    }

    public void setTrue()
    {
        enterPressed = true;
    }

    IEnumerator waitfortime()
    {
        yield return new WaitForSeconds(5);
        GetComponent<SpinningScript>().enabled = false;
    }
}
