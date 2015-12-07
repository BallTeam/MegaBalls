using UnityEngine;
using System.Collections;

public class DarkenOverTime : MonoBehaviour {

    public Color tint;

    SpriteRenderer spriteRend;
    
    void Awake ()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        spriteRend.color = Color.Lerp(spriteRend.color, tint, 0.01f);
    }
}
