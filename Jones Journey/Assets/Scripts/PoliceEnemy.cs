using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceEnemy : Enemy
{
    [SerializeField]
    private float stopDistance;
    private float attackTime;
    public float attackSpeed;

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttack;
                }
            }
        }

        IEnumerator Attack()
        {
            player.GetComponent<Player>().TakeDamage(damage);
         

            Vector2 originPosition = transform.position;
            Vector2 targetPosion = player.position;

            float percent = 0;
            while (percent <= 1)
            {
                percent += Time.deltaTime * attackSpeed;
                float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
                transform.position = Vector2.Lerp(originPosition, targetPosion, formula);
                yield return null;
            }
        }
    }
}
