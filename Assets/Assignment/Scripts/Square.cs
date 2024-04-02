using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Ally  
{
    public override void Update()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        if (selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, 0, 90));
                Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, 0, -90));
                Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, 0, 180));
            }
            transform.Translate(Movement * speed * Time.deltaTime, Space.World);
        }
    }
}
