using System.Collections;
using System.Collections.Generic;
using Anima2D;
using UnityEngine;

public class Highlight : MonoBehaviour {

    [SerializeField] private Color highlightColor = Color.yellow;
    private Color startcolor;
    private SpriteRenderer spriteRenderer;
    private SpriteMeshInstance spriteMeshInstance;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteMeshInstance = GetComponent<SpriteMeshInstance>();

        if(spriteRenderer != null)
        {
            startcolor = spriteRenderer.color;
        }

        if(spriteMeshInstance != null)
        {
            startcolor = spriteMeshInstance.color;
        }
    }

    void OnMouseEnter()
    {

        if(spriteRenderer != null)
        {
            spriteRenderer.color = highlightColor;
        }

        if(spriteMeshInstance != null)
        {
            spriteMeshInstance.color = highlightColor;
        }
    }
    void OnMouseExit()
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.color = startcolor;
        }

        if(spriteMeshInstance != null)
        {
            spriteMeshInstance.color = startcolor;
        }
    }
}
