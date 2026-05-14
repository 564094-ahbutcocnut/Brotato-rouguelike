using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreeceHealth : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] int maxHealth = 100;


    [SerializeField] GunManager gunManager;
    [SerializeField] ItalyBoss italyboss;

    private int currentHealth;

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
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        ItalyBoss italyboss = collision.gameObject.GetComponent<ItalyBoss>();

        if (italyboss != null)
            Hit(20);

    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        //anim.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);


        }

    }
}
