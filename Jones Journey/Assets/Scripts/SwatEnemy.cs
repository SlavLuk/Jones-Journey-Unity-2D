using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public Transform shotPoint;
    public GameObject enemyBullet;
    [SerializeField]
    private AudioClip enemyShot;
    [SerializeField]
    [Range(0, 1)]
    private float shootVolume = 0.75f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            if (Time.time >= attackTime)
            {

                attackTime = Time.time + timeBetweenAttack;
                anim.SetTrigger("attack");
            }
        }

    }
    public void SwatAttack()
    {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shotPoint.rotation = rotation;

        AudioSource.PlayClipAtPoint(enemyShot, Camera.main.transform.position, shootVolume);
        Instantiate(enemyBullet, shotPoint.position, shotPoint.transform.rotation);

    }
    }
