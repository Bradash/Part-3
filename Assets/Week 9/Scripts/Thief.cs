using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    float maxTime = 0.5f;
    public override ChestType CanOpen()
    {
        return ChestType.Theif;
}
    protected override void Attack()
    {
        StartCoroutine(Dash());
        destination = transform.position;


        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    IEnumerator Dash()
    {
        speed = 8;
        yield return new WaitForSeconds(maxTime);
        base.Attack();
        Instantiate(dagger, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(dagger, spawnPoint2.position, spawnPoint2.rotation);
        speed = 3;
    }
    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           speed = 3;
        }
        base.Update();
    }
}
