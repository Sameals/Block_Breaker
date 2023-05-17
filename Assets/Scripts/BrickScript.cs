using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitToBreak;
    public Sprite hitSprite;
    
    public void BreakBrick()
    {
        hitToBreak--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
