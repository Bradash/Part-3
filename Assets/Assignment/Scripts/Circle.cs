using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Ally
{
    public int attackCount;
    public bool isReloading;
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
                if (attackCount < 3)
                {
                    RandomAttack();
                    attackCount++;
                }
                if (isReloading = false || attackCount >= 3)
                {
                    StartCoroutine(Reload());
                }

            }
            transform.Translate(Movement * speed * Time.deltaTime, Space.World);
        }
    }

    void RandomAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        }
        


    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(1);
        isReloading = false;
        attackCount = 0;
        yield return null;
    }



}
