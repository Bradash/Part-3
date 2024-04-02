using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    public Vector3 destination;
    int point;
    int enemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        destination = points[point].position;
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime + (Time.deltaTime * GameHandler.currentRound/20));
        if (transform.position == destination && point != points.Length)
        {
            point++;
        }
        if (transform.position == destination && point == points.Length)
        {
            GameHandler.healthDamage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            enemyHealth++;
            
        } 
        if (enemyHealth == 3)
        {
            Destroy(gameObject);
        }
    }

}
