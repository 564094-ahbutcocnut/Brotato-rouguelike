using UnityEngine;

public class HammerThrower : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] GameObject projectile;

    [Header("Config")]
    [SerializeField] float fireDistance = 10;
    [SerializeField] float fireRate = 0.5f;

    Transform boss;
    Vector2 offset;

    private float timeSinceLastShot = 0f;
    Transform closestPlayer;


    private void Start()
    {
        
        timeSinceLastShot = fireRate;
        boss = GameObject.Find("StalinBoss(Clone)").transform;
    }


    private void Update()
    {
        transform.position = (Vector2)boss.position + offset;

        FindClosestEnemy();
        AimAtEnemy();
        Shooting();


    }

    void FindClosestEnemy()
    {
        closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        Player[] players = FindObjectsOfType<Player>();

        foreach (Player player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance && distance <= fireDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;

            }
        }
    }


    void AimAtEnemy()
    {
        if (closestPlayer != null)
        {
            Vector3 direction = closestPlayer.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);

            transform.position = (Vector2)boss.position + offset;
        }
    }

    void Shooting()
    {
        if (closestPlayer == null) return;

        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= fireRate)
        {
            Shoot();
            timeSinceLastShot = 0;
        }
    }


    void Shoot()
    {
        //anim.SetTrigger("Shoot");

        var muzzleGo = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);

        var projectileGo = Instantiate(projectile, muzzlePosition.position, transform.rotation);
        Destroy(projectileGo, 3);
    }

    public void SetOffset(Vector2 o)
    {
        offset = o;
    }
}

