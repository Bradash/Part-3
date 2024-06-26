using System.Collections;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    float maxTime = 0.5f;
    Coroutine dashing;
    public override ChestType CanOpen()
    {
        return ChestType.Theif;
    }

    public override string ToString()
    {
        return "Hi I'm Bob!";
    }

    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());

        StopCoroutine(Dash());
        destination = transform.position;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    IEnumerator Dash()
    {
        speed = 8;
        while (speed > 3)
        {
            yield return null;
        }

        yield return new WaitForSeconds(maxTime);
        base.Attack();
        yield return new WaitForSeconds(0.2f);
        Instantiate(dagger, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(dagger, spawnPoint2.position, spawnPoint2.rotation);
        speed = 3;
    }
}
