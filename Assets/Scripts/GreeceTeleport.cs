using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreeceTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private int teleportcooldown = 240;

    // Update is called once per frame
    void Update()
    {
        if (teleportcooldown == 240)
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

            }
            teleportcooldown = 0;

        }
        teleportcooldown += 1;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }

        }
    }
}

