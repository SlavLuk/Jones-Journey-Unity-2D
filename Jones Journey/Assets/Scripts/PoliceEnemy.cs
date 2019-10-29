using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceEnemy : Enemy
{
    [SerializeField]
    private float stopDistance;


    private void FixedUpdate()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
