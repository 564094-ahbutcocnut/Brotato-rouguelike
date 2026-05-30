using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBallSpawner : MonoBehaviour
{
    [SerializeField] BossEnemy bossenemy;
    [SerializeField] GameObject GermanTank;
    // It is the quare root of what i put here
    [SerializeField] float MinDistanceFromPlayer = 4;

    Transform player;
    Transform enemiesParent;

    bool HasOccured = false;
    bool HasOccured2 = false;
    bool HasOccured3 = false;
    bool HasOccured4 = false;

    private void Start()
    {
        player = GameObject.Find("Player-Poland").transform;
        enemiesParent = GameObject.Find("Enemies").transform;
    }

    private void Update()
    {
        if (bossenemy.currentBossHealth == 4000)
        {
            if(HasOccured == false)
            {
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                HasOccured = true;
            }
            
        }
        if (bossenemy.currentBossHealth == 3000)
        {
            if (HasOccured2 == false)
            {
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                HasOccured2 = true;
            }

        }
        if (bossenemy.currentBossHealth == 2000)
        {
            if (HasOccured3 == false)
            {
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                HasOccured3 = true;
            }
        }
        if (bossenemy.currentBossHealth == 1000)
        {
            if (HasOccured4 == false)
            {
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                Instantiate(GermanTank, RandomPosition(), Quaternion.identity).transform.SetParent(enemiesParent);
                HasOccured4 = true;
            }
        }


    }



    Vector2 RandomPosition()
    {
        Vector2 randomposition = new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
        while (Vector3.SqrMagnitude(new Vector2(player.position.x, player.position.y) - randomposition) < MinDistanceFromPlayer)
        {
            randomposition = new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
        }
        return randomposition;
    }
}
