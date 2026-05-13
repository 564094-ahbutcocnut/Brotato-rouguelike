using UnityEngine;

public class ItalyBoss : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] float speed = 2f;

    [Header("Charger")]
    [SerializeField] bool isCharger;
    [SerializeField] float distanceToCharge = 5f;
    [SerializeField] float chargeSpeed = 12f;
    [SerializeField] float prepareTime = 2f;





    bool isCharging = false;
    bool isPreparingCharge = false;


    [SerializeField] GunManager gunManager;

    private int currentHealth;

    Animator anim;
    Transform target; // Follow target
    Transform Greece;

    private void Awake()
    {
        if (gunManager == null)
        {
            gunManager = GetComponent<GunManager>();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        Greece = GameObject.Find("Greece").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPreparingCharge) return;

        if (Greece != null)
        {
            Vector3 direction = Greece.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            var playerToTheRight = Greece.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);

            if (isCharger && !isCharging && Vector2.Distance(transform.position, Greece.position) < distanceToCharge)
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
        currentHealth -= damage;
        anim.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);


        }

    }


}
