using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherGameObject = other.gameObject;

        if (otherGameObject.GetComponent<Gravestone>()) {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        } else if (otherGameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherGameObject);
        }
    }
}
