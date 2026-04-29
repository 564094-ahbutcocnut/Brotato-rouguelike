using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [Header("GunType")]
    [SerializeField] GameObject BasicGunPrefab;
    [SerializeField] GameObject RocketLauncherPrefab;
    [SerializeField] GameObject SpamtonPrefab;
    [SerializeField] GameObject ShotgunPrefab;

    int numberofguns = 0;

    Transform player;
    List<Vector2> gunPositions = new List<Vector2>();

    int spawnedGuns = 0;

    private void Start()
    {
        player = GameObject.Find("Player").transform;

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

    private void Update()
    {
        // For testing
        if (Input.GetKeyDown(KeyCode.G))
            AddGun();
    }

    public void AddGun()
    {
        var pos = gunPositions[spawnedGuns];
        
        var roll = Random.Range(0, 100);
        var WeaponType = roll < 50 ? BasicGunPrefab : RocketLauncherPrefab;
        numberofguns++;

        // 1 = 99% for second item to appear

        if (roll <= 1)
        {
            WeaponType = SpamtonPrefab;
        }
        if (roll >= 2 && roll <= 5)
        {
            WeaponType = BasicGunPrefab;
        }
        if (roll >= 6 && roll <= 7)
        {
            WeaponType = RocketLauncherPrefab;
        }
        if (roll >= 8 && roll <= 10)
        {
            WeaponType = ShotgunPrefab;
        }




        var newGun = Instantiate(WeaponType, pos, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;


    }
}
