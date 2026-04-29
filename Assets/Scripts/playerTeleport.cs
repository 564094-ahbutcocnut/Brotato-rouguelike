using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private int teleportcooldown = 0;

    // Update is called once per frame
    void Update()
    {
        if (teleportcooldown == 90)
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

            }
            teleportcooldown = 0;

        }
        teleportcooldown += 1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
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
