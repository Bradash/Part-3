using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Ally : MonoBehaviour
{
    public bool selected;
    public SpriteRenderer spriteRenderer;
    public Color initialColor;
    public float speed = 10;
    Vector3 Movement;
    Vector3 mousePosition;
    public GameObject MissilePrefab;
    Quaternion lookRotation;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
    }

    public void Update()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        if (selected)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookRotation = Quaternion.LookRotation(Vector3.forward, transform.position - mousePosition);
            transform.rotation = lookRotation;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(MissilePrefab, transform.position, lookRotation);


            }
            //transform.position = Vector3.MoveTowards(transform.position, mouse.position, Time.deltaTime);
            transform.Translate(Movement * speed * Time.deltaTime, Space.World);
        }

    }

    private void OnMouseDown()
    {

        if (!selected)
        {
            GameHandler.SelectAlly(this);
        }
        
    }
    public void select()
    {
        spriteRenderer.color = Color.red;
        selected = true;
    }
    public void deselect()
    {
        selected = false;
        spriteRenderer.color = initialColor;
    }
}
