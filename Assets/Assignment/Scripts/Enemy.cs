using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int currentRound;
    public static int Health;
    public Transform[] points;
    public Vector3 destination;
    int point;


    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1;
    }
    private void Update()
    {
        destination = points[point].position;
        Debug.Log(transform.position - destination);
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 5);
        if (transform.position == destination && point != points.Length)
        {
            point++;
        }
        if (transform.position == destination && point == points.Length)
        {
            Health--;
            Destroy(gameObject);
        }
    }

}
