using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{ 
    public static int currentRound = 1;
    public static int Health = 5;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] points;
    public TextMeshProUGUI HealthUI;
    public TextMeshProUGUI RoundUI;
    public TextMeshProUGUI WinUI;
    public TextMeshProUGUI LoseUI;
    public float RoundTime;
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
            StartCoroutine(RoundTimer());
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = Health.ToString();
        RoundUI.text = currentRound.ToString();

        if (Health == 0)
        {
            LoseUI.enabled = true;
        }
        if (currentRound == 100)
        {
                WinUI.enabled = true;
        }

    }
    public static void healthDamage()
    {
        Health--;

    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform);
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.points = points;
            yield return new WaitForSeconds(2 - currentRound/60);
            yield return spawnEnemy();
        }

    }
    IEnumerator RoundTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(RoundTime);
            currentRound++;
            yield return RoundTimer();
        }

    }
}
