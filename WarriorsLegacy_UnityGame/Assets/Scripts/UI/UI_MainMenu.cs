using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] UI_FadeScreen fadeScreen;
    [SerializeField] private string sceneName = "MainScene";

    public void ContinueGame()
    {
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
        SceneManager.LoadScene("MainScene");
    }

   public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }
}
