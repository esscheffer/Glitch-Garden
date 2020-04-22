using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;

    bool spawn = true;

    IEnumerator Start() {
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SapawnAttacker();
        }
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void SapawnAttacker() {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker attacker) {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
