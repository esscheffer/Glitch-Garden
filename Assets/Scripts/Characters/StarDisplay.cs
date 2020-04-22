﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour {

    [SerializeField] int stars = 100;
    TextMeshProUGUI starText;

    void Start() {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount) {
        return stars >= amount;
    }

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }
}
