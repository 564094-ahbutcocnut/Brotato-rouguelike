using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    [SerializeField] GameObject HammerThowerPrefab;


    int numberofguns = 0;
    public static HammerManager othercode;

    Transform boss;
    Transform HammerThrowerparent;
    List<Vector2> hammerPositions = new List<Vector2>();

    int spawnedGuns = 0;

    public void Start()
    {
        boss = GameObject.Find("StalinBoss(Clone)").transform;
        HammerThrowerparent = GameObject.Find("StalinBoss(Clone)").transform;

        hammerPositions.Add(new Vector2(-2.0f, 0f));
        hammerPositions.Add(new Vector2(2.0f, 0f));

        hammerPositions.Add(new Vector2(0f, 1.5f));
        hammerPositions.Add(new Vector2(0f, -1.5f));

        hammerPositions.Add(new Vector2(-1.1f, 1.1f));
        hammerPositions.Add(new Vector2(1.1f, 1.1f));

        hammerPositions.Add(new Vector2(-1.1f, -1.1f));
        hammerPositions.Add(new Vector2(1.1f, -1.1f));

        AddGun();
        AddGun();


    }


    public void AddGun()
    {
        if (spawnedGuns >= hammerPositions.Count)
        {
            // Max guns reached, cannot add more
            return;
        }

        var pos = hammerPositions[spawnedGuns];

        var roll = Random.Range(0, 100);
        var HammerType = roll < 50 ? HammerThowerPrefab : HammerThowerPrefab;
        numberofguns++;

        var newhammer = Instantiate(HammerType, pos, Quaternion.identity);

        newhammer.GetComponent<HammerThrower>().SetOffset(pos);
        newhammer.transform.SetParent(HammerThrowerparent);
        spawnedGuns++;


    }
}
