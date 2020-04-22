using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject looseLabel;
    [SerializeField] float waitToLoad = 4f;
    
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start() {
        winLabel.SetActive(false);
        looseLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        numberOfAttackers++;
    }

    public void AttackerKilled() {
        numberOfAttackers--;
        if (numberOfAttackers <= 0) {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLooseCondition() {
        looseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = false;
        StopSpawners();
    }

    private void StopSpawners() {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>()) {
            spawner.StopSpawning();
        }
    }
}
