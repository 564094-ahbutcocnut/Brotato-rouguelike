using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;

    [Header("GunType")]
    [SerializeField] GameObject BasicGunPrefab;
    [SerializeField] GameObject RocketLauncherPrefab;

    Transform player;
    List<Vector2> gunPositions = new List<Vector2>();

    int spawnedGuns = 0;

    private void Start()
    {
        player = GameObject.Find("Player").transform;

        gunPositions.Add(new Vector2(1.4f, 0.2f));
        gunPositions.Add(new Vector2(-1.4f, 0.2f));        

        gunPositions.Add(new Vector2(-1.2f, 1f));
        gunPositions.Add(new Vector2(1.2f, 1f));

        gunPositions.Add(new Vector2(-1f, -0.5f));
        gunPositions.Add(new Vector2(1f, -0.5f));

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
        
        var roll = Random.Range(0, 100);
        var WeaponType = roll < 90 ? BasicGunPrefab : RocketLauncherPrefab;      

        var newGun = Instantiate(gunPrefab, pos, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;


    }
}
