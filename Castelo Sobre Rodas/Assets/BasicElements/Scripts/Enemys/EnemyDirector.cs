using UnityEngine;
using System.Collections.Generic;

public class EnemyDirector : MonoBehaviour
{
    [Header("Referências")]
    public static Enemy enemyPrefab;
    public List<Inimigo_DATA> enemyTypes;

    [Header("Spawn")]
    public int prewarmAmount = 200;
    public int maxEnemies = 100;
    public float spawnInterval = 0.5f;
    public float spawnDistance = 12f;

    [Header("Despawn")]
    public float despawnDistance = 25f;

    Transform player;
    float spawnTimer;

    readonly Queue<Enemy> pool = new();
    readonly List<Enemy> activeEnemies = new();

    // -----------------------------

    void Awake()
    {
        PrewarmPool();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        HandleSpawn();
        HandleDespawn();
    }

    // -----------------------------
    // POOL
    // -----------------------------

    void PrewarmPool()
    {
        for (int i = 0; i < prewarmAmount; i++)
        {
            Enemy e = Instantiate(enemyPrefab, transform);
            e.gameObject.SetActive(false);
            pool.Enqueue(e);
            
        }
    }

    Enemy GetFromPool()
    {
        if (pool.Count > 0)
            return pool.Dequeue();

        Enemy e = Instantiate(enemyPrefab, transform);
        e.gameObject.SetActive(false);
        return e;
    }

    void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
    }

    // -----------------------------
    // SPAWN
    // -----------------------------

    void HandleSpawn()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer < spawnInterval)
            return;

        if (activeEnemies.Count >= maxEnemies)
            return;

        SpawnEnemy();
        spawnTimer = 0f;
    }

    void SpawnEnemy()
    {
        Enemy enemy = GetFromPool();

        enemy.data = ChooseEnemyType();
        enemy.transform.position = GetSpawnPosition();

        enemy.gameObject.SetActive(true);
        activeEnemies.Add(enemy);
    }

    Inimigo_DATA ChooseEnemyType()
    {
        // simples por enquanto (depois evolui por tempo)
        return enemyTypes[Random.Range(0, enemyTypes.Count)];
    }

    Vector3 GetSpawnPosition()
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        return player.position + (Vector3)(dir * spawnDistance);
    }

    // -----------------------------
    // DESPAWN
    // -----------------------------

    void HandleDespawn()
    {
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = activeEnemies[i];

            float dist = Vector3.Distance(player.position, enemy.transform.position);

            if (dist > despawnDistance)
            {
                activeEnemies.RemoveAt(i);
                ReturnToPool(enemy);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (player == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, spawnDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, despawnDistance);
    }
}
