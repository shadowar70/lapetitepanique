using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperBehavior : MonoBehaviour {

    private int soul = 0;
    private int combo = 1;

	void Start () {
		
	}
	

	void Update () {

        if (Input.GetButtonDown("Fire1")) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.CompareTag("Innocent")){
                    if (hit.transform.GetComponent<InnocentLifetime>().Die()) {
                        soul += (int) (1000 * hit.transform.GetComponent<InnocentLifetime>().GetScore()) * combo;
                        Debug.Log("soul: " + soul);
                        combo += 1;
                    }
                    else {
                        combo = 1;
                    }

                    Destroy(hit.transform.gameObject);
                }

            }
        }

    }



}
