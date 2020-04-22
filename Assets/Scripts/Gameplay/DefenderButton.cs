using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;
    

    private void Start() {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText) {
            Debug.LogError(name + " has no cost text, add some!");
        } else {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown() {
        ConfigureButtonColors();
        ConfigureSelectedDefender();
    }

    private void ConfigureSelectedDefender() {
        FindObjectOfType<DefenderSpawner>().SetDefender(defenderPrefab);
    }

    private void ConfigureButtonColors() {
        foreach (DefenderButton defenderButton in FindObjectsOfType<DefenderButton>()) {
            defenderButton.GetComponent<SpriteRenderer>().color = new Color32(21, 21, 21, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
