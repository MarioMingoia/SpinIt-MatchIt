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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopRotate)
        {
            gameNameCube.transform.Rotate(.5f, 0, .5f);
        }
    }

    public void nextLevel()
    {
        panel.SetActive(true);
        StartCoroutine(fadeIn());
        nextLevelBool = true;
        exitGameBool = false;
    }

    public void exitGame()
    {
        panel.SetActive(true);
        StartCoroutine(fadeIn());
        nextLevelBool = false;
        exitGameBool = true;
    }
    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        print("fading in");
        stopRotate = true;
        panel.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        gameNameCube.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, new Vector3(0, 0, 0), 0.01f * Time.fixedDeltaTime);
        if (panel.GetComponent<CanvasGroup>().alpha >= 1)
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
        
            yield break;
        }
        yield return fadeIn();

    }
}
