using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    float currentSpeed = 0f;
    private GameObject currentTarget;

    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController != null) { levelController.AttackerKilled(); }
    }

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        GetComponent<Animator>().SetBool("isAttacking", currentTarget);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(other.gameObject.GetComponent<DamageDealer>());
    }

    private void ProcessHit(DamageDealer damageDealer) {
        GetComponent<Health>().DealDamage(damageDealer.GetDamage());
        damageDealer.Hit();
    }

    public void Attack(GameObject target) {
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health) {
            health.DealDamage(damage);
        }
    }

    public void SetMovementSpeed(float newSpeed) {
        currentSpeed = newSpeed;
    }
}
