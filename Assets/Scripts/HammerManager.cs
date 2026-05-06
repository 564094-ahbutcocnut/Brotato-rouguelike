using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    [Header("GunType")]
    [SerializeField] GameObject Hammer;


    int numberofguns = 0;

    Transform Boss;
    List<Vector2> gunPositions = new List<Vector2>();

    int spawnedGuns = 0;

    private void Start()
    {

    }

    private void Update()
    {
        // For testing
        if (Input.GetKeyDown(KeyCode.L)) ;
        {
            Boss = GameObject.Find("BossEnemy").transform;

            gunPositions.Add(new Vector2(-1.5f, 0f));
            gunPositions.Add(new Vector2(1.5f, 0f));

            gunPositions.Add(new Vector2(0f, 1.5f));
            gunPositions.Add(new Vector2(0f, -1.5f));

            gunPositions.Add(new Vector2(-1.1f, 1.1f));
            gunPositions.Add(new Vector2(1.1f, 1.1f));

            gunPositions.Add(new Vector2(-1.1f, -1.1f));
            gunPositions.Add(new Vector2(1.1f, -1.1f));

            AddGun();
            AddGun();
        }
            
    }

    public void AddGun()
    {
        if (spawnedGuns >= gunPositions.Count)
        {
            // Max guns reached, cannot add more
            return;
        }

        var pos = gunPositions[spawnedGuns];

        var roll = Random.Range(0, 100);
        var WeaponType = roll < 50 ? Hammer : Hammer;
        numberofguns++;

        // 1 = 99% for second item to appear






        var newGun = Instantiate(WeaponType, pos, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;


    }
}
