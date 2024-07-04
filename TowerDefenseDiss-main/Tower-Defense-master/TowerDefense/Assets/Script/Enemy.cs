using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float minSpeed = 10f;
    [SerializeField]
    public float maxSpeed = 25f;
    [SerializeField]
    private float speed;

    public int minHealth = 1;
    public int maxHealth = 6;
    private int health;
   

    private bool isDead = false;

    private Transform target;
    private int pathfindingindex = 0;
    [SerializeField]
    public int minWorth = 1;
    [SerializeField]
    public int maxWorth = 5;
    [SerializeField]
    public int worth;



    void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        worth = Random.Range(minWorth, maxWorth);
        health = Random.Range(0, 3);
        Debug.Log("health" + health);

        

        switch (health)
        {
            case 0:
                health = 5;
                break;
            case 1:
                health = 10;
                break;
            case 2:
                health = 15;
                break;
                
        }

    
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawner.aliveEnemies.Add(transform);
        target = path.paths[0];
        

    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0 && !isDead) 
        {
            Die();
        }

        Debug.Log("Enemy health: " + health);
    }
    
    private void OnDestroy()
    {
        Spawner.aliveEnemies.Remove(transform);
        Die();
    }

    void Die ()
    {
        isDead = true;
        PlayerStats.Money += worth;

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        //move towards the direction by the translation
        //direction.normalized the speed is controlled by the variable which is then multiplied
        //time.deltatime means the speed is not dependent on the frame rate
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextPath();
        }
    }

    //finding next waypointing and eventually reaching end of path
    void GetNextPath()
    {
        if (pathfindingindex >= path.paths.Length - 1)
        {

            pathEnded();
            return;
           
        }

        pathfindingindex++;
        target = path.paths[pathfindingindex];
    }

    void pathEnded ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
