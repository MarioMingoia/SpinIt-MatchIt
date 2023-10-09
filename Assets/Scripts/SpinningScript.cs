using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour
{
    public float rotateX;
    public float rotateY;

    bool enterPressed;

    public bool stoppedSpinning = false;
    // Start is called before the first frame update
    void Start()
    {
        rotateX /= 2; 
        rotateY /= 2; 
    }

    // Update is called once per frame
    void Update()
    {

        if (!enterPressed)
        {
            transform.Rotate(rotateX, 0, rotateY);
        }

        if (enterPressed && !stoppedSpinning)
        {
            var vec = transform.localEulerAngles;
            vec.x =  Mathf.Round(vec.x / 90) * 90;
            vec.y = Mathf.Round(vec.y / 90) * 90;
            vec.z = Mathf.Round(vec.z / 90) * 90;

            transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, vec, Time.deltaTime);

            if (Vector3.Angle(transform.localEulerAngles, vec) == 0)
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
        stoppedSpinning = true; 
    }
}
