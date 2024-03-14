using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    float timer;
    float maxTime = 0.5f;
    public override ChestType CanOpen()
    {
        return ChestType.Theif;
}
                protected override void Attack()
    {
        destination = transform.position;
        Instantiate(dagger, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(dagger, spawnPoint2.position, spawnPoint2.rotation);

        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 8;
        base.Attack();
    }
    protected override void Update()
    {
        if (speed > 3)
        {
            timer = Time.deltaTime + timer;
            if (timer > maxTime)
            {
                speed = 3;
                maxTime = timer + 0.5f;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
           speed = 3;
        }
        base.Update();
    }
}
