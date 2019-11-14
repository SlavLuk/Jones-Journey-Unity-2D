﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [HideInInspector]
    public Transform player;
    public float timeBetweenAttack;
    public int damage;
    public int pickupChange;
    public GameObject[] pickups;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void TakeDamage(int damageAmount)
    {

        health -= damageAmount;

        if (health <= 0)
        {
            int randomNum = Random.Range(0, 101);
            if(randomNum < pickupChange)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }

    }
}
