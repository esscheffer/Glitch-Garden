using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    const String DEFENDER_PARENT_NAME = "Defenders";

    Defender defender;
    GameObject defenderParent;

    private void Start() {
        CreateDefenderParent();
    }

    private void CreateDefenderParent() {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPosition);
    }

    private void AttemptToPlaceDefender(Vector2 gridPosition) {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(gridPosition);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition) {
        return new Vector2(Mathf.RoundToInt(rawWorldPosition.x), Mathf.RoundToInt(rawWorldPosition.y));
    }

    private void SpawnDefender(Vector2 spawnPosition) {
        if (!defender) { return; }
        Defender newDefender = Instantiate(defender, spawnPosition, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetDefender(Defender defender) {
        this.defender = defender;
    }
}
