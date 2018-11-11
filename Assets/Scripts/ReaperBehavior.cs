using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperBehavior : MonoBehaviour {

    private int soul = 0;
    private int combo = 1;
    [SerializeField] private GameObject scytheHitParticles;

    void Start() {

    }


    void Update() {

        if (Input.GetButtonDown("Fire1")) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.CompareTag("Innocent")) {
                    if (hit.transform.GetComponent<InnocentLifetime>().Die()) {
                        soul += (int)(1000 * hit.transform.GetComponent<InnocentLifetime>().GetScore()) * combo;
                        combo += 1;
                        CheckCombo();
                        GameManager.instance.ImpactTimerScore(2);
                        GameManager.instance.UpdateScoreAndMultiplier(soul, combo);
                    }
                    else {
                        combo = 1;
                        GameManager.instance.UpdateScoreAndMultiplier(soul, combo);
                        GameManager.instance.ImpactTimerScore(-4);
                    }
                    Instantiate(scytheHitParticles, hit.transform.position + Vector3.up, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.CompareTag("Monster")) {
                    if (hit.transform.GetComponent<MonsterBehavior>().TakeDamage()) {
                        soul += 500 * combo;
                        combo += 1;
                        CheckCombo();
                        GameManager.instance.UpdateScoreAndMultiplier(soul, combo);
                        Instantiate(scytheHitParticles, hit.transform.position + Vector3.up, Quaternion.identity);
                    }

                }

            }
        }

    }


    private void CheckCombo() {
        if (combo > 8) {
            combo = 8;
        }
        else if (combo < 1) {
            combo = 1;
        }
    }
}
