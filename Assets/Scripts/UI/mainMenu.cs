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
    private void OnMouseDrag()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopRotate)
        {

            if (Input.GetMouseButton(0))
            {
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                gameNameCube.transform.Rotate(Vector3.up, -rotX);
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
    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        stopRotate = true;
        panel.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
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
        
            yield break;
        }
        yield return fadeIn();

    }
}
