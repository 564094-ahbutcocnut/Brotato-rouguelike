using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializedField] GameObject enemyPrefab;
    [SerializedField] float timeBewtweenSpawns = 0.5f
    float currentTimeBetweenSpawns;

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
    }

    private void Update()
    {
        currentTimeBetweenSpawns -= Time.deltatime;

        if( currentTimeBetweenSpawns <= 0 )
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBewtweenSpawns;
        }
    }

    Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }

    void SpawnEnemy()
    {
        var e = Instantiate(enemyPrefab), RandomPosition(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
            Destroy(e.gameObject);
    }

}