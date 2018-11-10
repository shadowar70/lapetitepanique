using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

    public int hp = 5;
    private bool isDead = false;
    public GameObject bloodPrefab;

    void Start () {
		
	}
	

	void Update () {
		
	}

    public bool TakeDamage() {
        hp--;
        if(hp <= 0) {
            Die();
            return true;
        }
        else {
            return false;
        }
    }

    public void Die() {
        //Instantiate blood particle
        Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
