using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class galleryMenu : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;


    [SerializeField]
    float timer;

    public GameObject panel;

    [SerializeField]
    bool stopRotate = false;

    [SerializeField]
    bool moving = false;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartCoroutine(fadeOut());

    }

    IEnumerator fadeOut()
    {
        yield return new WaitForFixedUpdate();
        panel.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 2;

        if (panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            panel.SetActive(false);
            yield break;
        }
        yield return fadeOut();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                stopRotate = false;
            }
            else
            {
                if (moving == false)
                {
                    stopRotate = true;
                    transform.Rotate(Vector3.up, 1f);
                }

            }
            if (!stopRotate)
            {

                if (Input.GetMouseButton(0))
                {
                    moving = true;
                    float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                    transform.Rotate(Vector3.up, -rotX);
                }
                else
                {
                    moving = false;
                }
            }
        }
    }

    public void mainMenu()
    {
        panel.SetActive(true);
        timer = 0;
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        panel.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            yield break;
        }
        yield return fadeIn();

    }
}
