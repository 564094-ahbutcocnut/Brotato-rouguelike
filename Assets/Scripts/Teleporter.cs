using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination1;
    [SerializeField] private Transform destination2;
    [SerializeField] private Transform destination3;
    [SerializeField] private Transform destination4;
    [SerializeField] private Transform destination5;
    [SerializeField] private Transform destination6;
    [SerializeField] private Transform destination7;




    public Transform GetDestination()
    {
        var roll = Random.Range(8, 1);

        
        if(roll == 1)
        {
            return destination1;
        }
        else if (roll == 2)
        {
            return destination2;
        }
        else if (roll == 3)
        {
            return destination3;
        }
        else if (roll == 4)
        {
            return destination4;
        }
        else if (roll == 5)
        {
            return destination5;
        }
        else if (roll == 6)
        {
            return destination6;
        }
        else
        {
            return destination7;
        }      




    }
}