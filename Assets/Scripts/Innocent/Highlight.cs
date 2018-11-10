using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

    [SerializeField] private Color highlightColor = Color.yellow;
    private Color startcolor;
    private SpriteRenderer renderBody;

    void OnMouseEnter() {
        renderBody.color = highlightColor;
    }
    void OnMouseExit() {
        renderBody.color = startcolor;
    }

    void Start () {
        renderBody = GetComponent<SpriteRenderer>();
        startcolor = renderBody.color;
    }
	

	void Update () {
		
	}
}
