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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopRotate)
        {
            gameNameCube.transform.Rotate(1, 0, 1);
        }
    }

    public void nextLevel()
    {
        panel.SetActive(true);
        StartCoroutine(fadeIn());
    }
    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        print("fading in");
        stopRotate = true;
        panel.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        gameNameCube.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, new Vector3(0, 0, 0), 0.00001f * Time.fixedDeltaTime);
        if (panel.GetComponent<CanvasGroup>().alpha >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            yield break;
        }
        yield return fadeIn();

    }
}
