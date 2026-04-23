using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject chargerPrefab;
    [SerializeField] GameObject BossPrefab;
    [SerializeField] float StartingTimeBewtweenSpawns = 0.5f;

    // It is the quare root of what i put here
    [SerializeField] float MinDistanceFromPlayer = 4;
    float currentTimeBetweenSpawns;
    Transform player;

    Transform enemiesParent;

    public static EnemyManager Instance;

    private void Awake()
    {
        // To  call it from other scripts
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (!WaveManager.Instance.WaveRunning()) return;

        currentTimeBetweenSpawns -= Time.deltaTime;
        if (WaveManager.Instance.currentWave <=3 )
        {
            if( currentTimeBetweenSpawns <= 0 )
            {
                SpawnEnemy();
                currentTimeBetweenSpawns = StartingTimeBewtweenSpawns;
            }
        }
        if (WaveManager.Instance.currentWave == 4)
        {
            if (currentTimeBetweenSpawns <= 0)
            {
                SpawnEnemy();
                currentTimeBetweenSpawns = StartingTimeBewtweenSpawns;
            }
        }
        if (WaveManager.Instance.currentWave > 4 && WaveManager.Instance.currentWave <= 6)
        {
            if (currentTimeBetweenSpawns <= 0)
            {
                SpawnEnemy();
                currentTimeBetweenSpawns = StartingTimeBewtweenSpawns - 0.25f;
            }
        }
        if (WaveManager.Instance.currentWave > 6 && WaveManager.Instance.currentWave <= 9)
        {
            if (currentTimeBetweenSpawns <= 0)
            {
                SpawnEnemy();
                currentTimeBetweenSpawns = StartingTimeBewtweenSpawns - 0.55f;
            }
        }
        if (WaveManager.Instance.currentWave == 10)
        {
            if (currentTimeBetweenSpawns <= 0)
            {
                SpawnEnemy();
                currentTimeBetweenSpawns = 1000;
            }
        }


    }

    Vector2 RandomPosition()
    {
        Vector2 randomposition = new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
        while(Vector3.SqrMagnitude(new Vector2 (player.position.x, player.position.y) - randomposition) < MinDistanceFromPlayer)
        {
            randomposition = new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
        }
        return randomposition;
    }




    void SpawnEnemy()
    {
        if (WaveManager.Instance.currentWave <= 3)
        {
            Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);            
        }
        if (WaveManager.Instance.currentWave == 4 )
        {
            var roll = Random.Range(0, 100);
            var enemyType = roll < 90 ? enemyPrefab : chargerPrefab;

            var e = Instantiate(enemyType, RandomPosition(), Quaternion.identity);
            e.transform.SetParent(enemiesParent);
        }
        if (WaveManager.Instance.currentWave > 4 && WaveManager.Instance.currentWave <= 9)
        {
            var roll = Random.Range(0, 100);
            var enemyType = roll < 90 ? enemyPrefab : chargerPrefab;

            var e = Instantiate(enemyType, RandomPosition(), Quaternion.identity);
            e.transform.SetParent(enemiesParent);
        }
        if (WaveManager.Instance.currentWave == 10)
        {
            Instantiate(BossPrefab, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
        }


    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
            Destroy(e.gameObject);
    }

}