using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDemo : MonoBehaviour
{
    Color color;
    public SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(float change)
    {
        float interpolation = Time.deltaTime;

        color = Color.Lerp(Color.white, Color.red, change/60);
        sprite.color = color;
    }
}
