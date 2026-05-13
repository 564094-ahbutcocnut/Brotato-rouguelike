using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI waveText;

    [Header("Managers")]
    [SerializeField] GunManager gunManager;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] HammerManager hammerManager;

    [Header("Prefabs")]
    [SerializeField] BossEnemy bossEnemy;
    [SerializeField] GameObject winningSquare;

    [Header("WhichBoss")]
    [SerializeField] bool IsSoviet;
    [SerializeField] bool IsGerman;

    [Header("TimeStuff")]


    public static WaveManager Instance;
    Transform managerparent;



   

    bool waveRunning = true;
    bool waveNotRunning = false;
    bool bossFight = false;
    public int currentWave = 0;
    public int currentWaveTime;

    int showhealth;

    public void SetBossEnemy(BossEnemy boss)
    {
        this.bossEnemy = boss;
        
    }



    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        managerparent = GameObject.Find("Managers").transform;
        StartNewWave();
        timeText.text = "30";
        waveText.text = "Wave: 1";
    }


    public bool WaveRunning() => waveRunning;

    private void StartNewWave()
    {
        currentWave++;

        if (currentWave <=9 )
        {
            StopAllCoroutines();
            timeText.color = Color.white;            
            waveRunning = true;
            currentWaveTime = 30;
            waveText.text = "Wave: " + currentWave;
            StartCoroutine(WaveTimer());
        }
        if (currentWave == 10)
        {
            StopAllCoroutines();
            timeText.color = Color.red;         
            bossFight = true;
            waveRunning = true;
            waveText.text = "Wave: Boss" ;
            var roll = Random.Range(0, 100);

            if (IsSoviet == true)
            {
                var enemyType = roll < 90 ? bossEnemy : bossEnemy;
                var bossObj = Instantiate(enemyType, RandomPosition(), Quaternion.identity);
                Instance.SetBossEnemy(bossObj.GetComponent<BossEnemy>());
                var needHammerManager = Random.Range(0, 100);
                var managerType = needHammerManager < 90 ? hammerManager : hammerManager;
                var managerObj = Instantiate(managerType, RandomPosition(), Quaternion.identity);
                managerObj.transform.SetParent(managerparent);
                StartCoroutine(BossTimer());
            }
            if (IsGerman == true)
            {
                var enemyType = roll < 90 ? bossEnemy : bossEnemy;
                var bossObj = Instantiate(enemyType, RandomPosition(), Quaternion.identity);
                Instance.SetBossEnemy(bossObj.GetComponent<BossEnemy>());
                var needHammerManager = Random.Range(0, 100);
                var managerType = needHammerManager < 90 ? hammerManager : hammerManager;
                var managerObj = Instantiate(managerType, RandomPosition(), Quaternion.identity);
                managerObj.transform.SetParent(managerparent);
                StartCoroutine(BossTimer());
            }


        }






    }

    IEnumerator WaveTimer()
    {
        while(waveRunning)
        {
            yield return new WaitForSeconds(1f);
            currentWaveTime--;

            timeText.text = currentWaveTime.ToString();

            if (currentWaveTime <= 0)
                WaveComplete();
        }

        yield return null;
    }

    IEnumerator BossTimer()
    {
        while (bossFight)
        {

            timeText.text = ("Boss Health: " + bossEnemy.currentBossHealth);            
            if (bossEnemy.BossDefeated == true)
            {
                
                BossWaveComplete();
            }
            yield return null;
        }
    }

    private void WaveComplete()
    {
        StopAllCoroutines();
        EnemyManager.Instance.DestroyAllEnemies();
        if (currentWave == 3)
        {
            gunManager.AddGun();
        }
        if (currentWave == 5)
        {
            gunManager.AddGun();
        }
        if (currentWave == 7)
        {
            gunManager.AddGun();
        }
        if (currentWave == 7)
        {
            gunManager.AddGun();
        }
        if (currentWave == 8)
        {
            gunManager.AddGun();
        }
        if (currentWave == 9)
        {
            gunManager.AddGun();
        }

        waveRunning = false;
        waveNotRunning = true;
        currentWaveTime = 5;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.green;
        StartCoroutine(TimeTillNextWave());



    }
    private void BossWaveComplete()
    {
        timeText.text = ("Boss Health: Dead");
        StopAllCoroutines();
        EnemyManager.Instance.DestroyAllEnemies();
        waveRunning = false;
        waveNotRunning = true;
        var win = winningSquare;
        Instantiate(win, RandomWinPosition(), Quaternion.identity);


    }

    IEnumerator TimeTillNextWave()
    {
        while (waveNotRunning == true)
        {
            yield return new WaitForSeconds(1f);
            currentWaveTime--;


            timeText.text = currentWaveTime.ToString();

            if (currentWaveTime <= 0)
                StartNewWave();
        }

        yield return null;
    }


    Vector2 RandomPosition()
    {
        Vector2 randomposition = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        return randomposition;
    }


    Vector2 RandomWinPosition()
    {
        Vector2 randomposition = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        return randomposition;
    }

}
