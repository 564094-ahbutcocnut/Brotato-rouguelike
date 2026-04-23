using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] GunManager gunManager;
    [SerializeField] BossEnemy bossEnemy;

    public static WaveManager Instance;

    bool waveRunning = true;
    bool waveNotRunning = false;
    bool bossFight = false;
    public int currentWave = 0;
    int currentWaveTime;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        StartNewWave();
        timeText.text = "30";
        waveText.text = "Wave: 1";
    }

    private void Update()
    {
        //For testing
        if (Input.GetKeyDown(KeyCode.P))
            StartNewWave();
    }

    public bool WaveRunning() => waveRunning;

    private void StartNewWave()
    {
        
        if (currentWave <=8 )
        {
            StopAllCoroutines();
            timeText.color = Color.white;
            currentWave++;
            waveRunning = true;
            currentWaveTime = 30;
            waveText.text = "Wave: " + currentWave;
            StartCoroutine(WaveTimer());
        }
        if (currentWave == 9)
        {
            StopAllCoroutines();
            timeText.color = Color.red;
            currentWave++;
            bossFight = true;            
            waveText.text = "Wave: Boss" ;
            StartCoroutine(BossTimer());

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

            timeText.text = ("Boss Fight");

            if (bossEnemy.BossDefeated == true)
            {
                BossWaveComplete();
            }
               
        }

        yield return null;
    }

    private void WaveComplete()
    {
        StopAllCoroutines();
        EnemyManager.Instance.DestroyAllEnemies();
        waveRunning = false;
        waveNotRunning = true;
        currentWaveTime = 5;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.green;
        StartCoroutine(TimeTillNextWave());



        var DropWeapon = Random.Range(0, 10);
        if (DropWeapon <= 5)
        {
            gunManager.AddGun();
        }


    }
    private void BossWaveComplete()
    {
        StopAllCoroutines();
        EnemyManager.Instance.DestroyAllEnemies();
        waveRunning = false;
        waveNotRunning = true;
        currentWaveTime = 5;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.green;
        StartCoroutine(TimeTillNextWave());



        var DropWeapon = Random.Range(0, 10);
        if (DropWeapon <= 5)
        {
            gunManager.AddGun();
        }


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


}
