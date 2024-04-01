using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 10);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
