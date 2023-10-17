using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class showReturnButton : MonoBehaviour
{
    public GameObject mainMenuFadePanel;

    public GameObject returnPanel;

    public List<GameObject> achievements;

    public GameObject returnButton;

    [SerializeField]
    achievementManager am;

    private void Update()
    {
        if (achievements.Count == am.achievementCounter.Count || am.achievementCounter.Count == 0)
        {
            showReturn();
        }
    }

    public void goToMain()
    {
        mainMenuFadePanel.SetActive(true);
        StartCoroutine(fadeIn());
    }
    IEnumerator fadeIn()
    {
        yield return new WaitForFixedUpdate();
        mainMenuFadePanel.GetComponent<CanvasGroup>().alpha += Time.deltaTime / 2;
        if (mainMenuFadePanel.GetComponent<CanvasGroup>().alpha >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            yield break;
        }
        yield return fadeIn();

    }
    
    public void showReturn()
    {
        returnPanel.SetActive(true);
        returnButton.SetActive(true);
        StartCoroutine(fadeInReturn());
    }
    IEnumerator fadeInReturn()
    {
        yield return new WaitForFixedUpdate();
        returnPanel.GetComponent<CanvasGroup>().alpha += Time.deltaTime / 75;
        if (returnPanel.GetComponent<CanvasGroup>().alpha >= 1)
        {
            yield break;
        }
        yield return fadeInReturn();

    }
}
