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

    public Vector3 direction;

    [SerializeField]
    float speedofRotation;

    public bool stoppedSpinning = false;
    // Start is called before the first frame update
    void Start()
    {

        speedofRotation = Random.Range(50, 200);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(rotateX, rotateY, 0);

        if (!enterPressed)
        {
            transform.RotateAround(transform.position, direction, speedofRotation * Time.deltaTime);
        }

        if (enterPressed && !stoppedSpinning)
        {
            var vec = transform.eulerAngles;
            vec.x = Mathf.Round(vec.x / 90) * 90;
            vec.y = Mathf.Round(vec.y / 90) * 90;
            vec.z = Mathf.Round(vec.z / 90) * 90;

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
        stoppedSpinning = true; 
    }
}
