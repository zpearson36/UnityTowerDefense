using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setColor(int _val)
    {
        spriteRenderer.color = new Color(.6f, .6f, .6f, 1.0f);
        if(_val % 2 == 0)
            spriteRenderer.color = new Color(.5f, .5f, .5f, 1.0f);
    }
}
