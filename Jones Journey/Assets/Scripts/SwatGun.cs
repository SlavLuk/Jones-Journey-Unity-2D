using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatGun : MonoBehaviour
{
  
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
         

    }
}
