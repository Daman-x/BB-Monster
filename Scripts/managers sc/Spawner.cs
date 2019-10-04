using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerHealth StoneHealth;
    public PlayerHealth DragonHealth;
    public PlayerHealth TronHealth;
    public PlayerHealth BeastHealth;

    public   GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

   
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f && StoneHealth.currentHealth <= 0f && DragonHealth.currentHealth <= 0f && TronHealth.currentHealth <= 0f && BeastHealth.currentHealth <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
