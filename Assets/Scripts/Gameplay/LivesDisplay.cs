using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour {

    [SerializeField] float baseLives = 3;

    float lives;
    TextMeshProUGUI livesText;

    void Start() {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void TakeLife(int amount = 1) {
        if (lives >= amount) {
            lives -= amount;
            UpdateDisplay();
        }

        if (lives <= 0) {
            FindObjectOfType<LevelController>().HandleLooseCondition();
        }
    }

    private void UpdateDisplay() {
        livesText.text = lives.ToString();
    }
}
