using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform enemy;

    public Transform spawnpoint;

    public float timetillnextwave = 5f;
    private float timeBetweenEnemySpawns;
    public float Max = 1f;
    public float Min = 0.5f;
    private bool currentlySpawning = false;
    private int roundindex = 0;

    private float graceTimer = 0;

    public static List<Transform> aliveEnemies = new List<Transform>();

    public Text NextWave;
    public Text Timer;


    void Update()
    {
        if (currentlySpawning) return;

        if (aliveEnemies.Count <= 0)
        {
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn ()
    {
        
        PlayerStats.Rounds++;
        currentlySpawning = true;
        graceTimer = timetillnextwave;
        yield return new WaitUntil(() =>
        {
            graceTimer -= Time.deltaTime;
            Timer.text = "Next Wave In: "+((int)graceTimer).ToString();
            return graceTimer <= 0;

        });

        //every time a new wave spawns it adds a number to the index +1
        roundindex++;

        //when the next wave spawns it adds 1 to the text. E.g Wave 1 , Wave 2
        NextWave.text = "Wave "+(roundindex).ToString();


        //Continously spawns rounds . adds 1 enemy per wave
        int numofenemies = (int)Mathf.FloorToInt(Mathf.Log(PlayerStats.Rounds, 2) + 1) * 4;
        if (PlayerStats.Lives >= 45 || PlayerStats.Lives < 50)
        {
            numofenemies += Mathf.FloorToInt(PlayerStats.Lives * 0.4f);
        }
        else if(PlayerStats.Lives >= 30 || PlayerStats.Lives < 44)
        {
            numofenemies += Mathf.FloorToInt(PlayerStats.Lives * 0.4f);
        }
        else if(PlayerStats.Lives >= 0 || PlayerStats.Lives < 29)
        {
            numofenemies += Mathf.FloorToInt(PlayerStats.Lives * 0.4f);
        }
        


        for (int i = 0; i < numofenemies; i++)
        {
            timeBetweenEnemySpawns = Random.Range(Min, Max);
            Debug.Log("timebetweenspawns" + timeBetweenEnemySpawns);
            //calls the the spawn enemy function
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawns);
        }
        currentlySpawning = false;
    }

    void SpawnEnemy ()
    {
        //on new round, spawn enemy at the set position
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
    }

}