using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene() {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Start Screen");
        Time.timeScale = 1;
    }

    public void LoadOptionsScreen() {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLooseScreen() {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
