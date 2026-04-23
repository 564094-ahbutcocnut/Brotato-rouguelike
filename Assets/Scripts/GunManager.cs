using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [Header("GunType")]
    [SerializeField] GameObject BasicGunPrefab;
    [SerializeField] GameObject RocketLauncherPrefab;

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
        var WeaponType = roll < 1 ? BasicGunPrefab : RocketLauncherPrefab;      
        // 1 = 99% for second item to appear



        var newGun = Instantiate(WeaponType, pos, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;


    }
}
