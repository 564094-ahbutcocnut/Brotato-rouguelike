using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] int maxBossHealth = 100;
    [SerializeField] float speed = 2f;

    [Header("Charger")]
    [SerializeField] bool isCharger;
    [SerializeField] float distanceToCharge = 5f;
    [SerializeField] float chargeSpeed = 12f;
    [SerializeField] float prepareTime = 2f;

    bool isCharging = false;
    bool isPreparingCharge = false;
    public bool BossDefeated = false;

    [SerializeField] GunManager gunManager;

    private int currentBossHealth;

    Animator anim;
    Transform target; // Follow target

    private void Awake()
    {
        if (gunManager == null)
        {
            gunManager = GetComponent<GunManager>();
        }
    }

    private void Start()
    {
        currentBossHealth = maxBossHealth;
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPreparingCharge) return;

        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            var playerToTheRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);

            if (isCharger && !isCharging && Vector2.Distance(transform.position, target.position) < distanceToCharge)
            {
                isPreparingCharge = true;
                Invoke("StartCharging", prepareTime);
            }
        }
    }

    void StartCharging()
    {
        isPreparingCharge = false;
        isCharging = true;
        speed = chargeSpeed;
    }



    public void Hit(int damage)
    {
        currentBossHealth -= damage;
        anim.SetTrigger("Hit");

        if (currentBossHealth <= 0)
        {
            BossDefeated = true;
            Destroy(gameObject);
            


        }

    }


}