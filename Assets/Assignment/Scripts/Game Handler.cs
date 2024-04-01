using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static int currentRound = 1;
    public static int Health;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] points;
    public static Ally selectedAlly { get; private set; }

    public static void SelectAlly(Ally ally)
    {

        Debug.Log(selectedAlly != null);
        
        if (selectedAlly != null)
        {
            selectedAlly.deselect();
        }
        selectedAlly = ally;
        selectedAlly.select();
    }


    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(spawnEnemy());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform);
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.points = points;
            yield return new WaitForSeconds(10 / currentRound);
            yield return spawnEnemy();
        }

    }
}
