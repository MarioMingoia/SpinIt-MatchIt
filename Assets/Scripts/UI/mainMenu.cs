using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject panel;

    public GameObject gameNameCube;

    bool stopRotate = false;

    public bool nextLevelBool = false;
    public bool exitGameBool = false;

    [SerializeField]
    float rotSpeed;

    [SerializeField]
    float timer;

    Ray ray;
    RaycastHit hit;

    [SerializeField]
    bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        panel.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        yield return new WaitForFixedUpdate();
        panel.GetComponent<CanvasGroup>().alpha -= 0.001f;

        if (panel.GetComponent<CanvasGroup>().alpha == 0)
        {
            panel.SetActive(false);

            yield break;

        }
        yield return fadeOut();

    }

    // Update is called once per frame
    void Update()
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
                gameNameCube.transform.Rotate(Vector3.up, .5f);
            }

        }
        if (!stopRotate)
        {

            if (Input.GetMouseButton(0))
            {
                moving = true;
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                gameNameCube.transform.Rotate(Vector3.up, -rotX);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void nextLevel()
    {
        panel.SetActive(true);
        timer = 0;
        StartCoroutine(fadeIn());
        nextLevelBool = true;
        exitGameBool = false;
    }

    public void exitGame()
    {
        panel.SetActive(true);
        timer = 0;
        StartCoroutine(fadeIn());
        nextLevelBool = false;
        exitGameBool = true;
    }

    public void gallery()
    {
        panel.SetActive(true);
        timer = 0;
        StartCoroutine(fadeIn());
        nextLevelBool = false;
        exitGameBool = false;
    }
    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        stopRotate = true;
        panel.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
        gameNameCube.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, new Vector3(0, 0, 0), 0.01f * Time.fixedDeltaTime);
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            if (nextLevelBool && !exitGameBool)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else if (!nextLevelBool && exitGameBool)
            {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
                Application.Quit();
            }
            else if (!nextLevelBool && !exitGameBool)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }

            yield break;
        }
        yield return fadeIn();

    }
}
