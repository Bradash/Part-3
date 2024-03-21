using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{
    Color color;
    public SpriteRenderer sprite;
    public TMP_Dropdown dropdown;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(float change)
    {
        color = Color.Lerp(Color.white, Color.red, change / 60);
        sprite.color = color;
    }
    public void SetPlayerImage(int index)
    {
        sprite.sprite = dropdown.options[index].image;
    }
}
