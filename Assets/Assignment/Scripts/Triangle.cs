using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Ally
{
    public bool isDashing = false;

    public override void Update()
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
                if (isDashing == false)
                {
                    StartCoroutine(DashAttack());
                }
                
                
            }
            transform.Translate(Movement * speed * Time.deltaTime, Space.World);
        }
    }
    IEnumerator DashAttack()
    {
        Instantiate(MissilePrefab, transform.position, lookRotation);
        isDashing = true;
        speed = 8;
        yield return new WaitForSeconds(0.1f);
        
        Instantiate(MissilePrefab, transform.position, lookRotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(MissilePrefab, transform.position, lookRotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(MissilePrefab, transform.position, lookRotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(MissilePrefab, transform.position, lookRotation);
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        speed = 2;
        yield return null;
    }
}
