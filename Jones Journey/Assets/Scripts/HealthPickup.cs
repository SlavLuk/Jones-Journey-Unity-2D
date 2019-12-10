using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Player playerScript;
    [SerializeField]
    private int healAmount;
    [SerializeField]
    private AudioClip healthPickup;
    [SerializeField]
    [Range(0, 1)]
    private float shootVolume = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.Heal(healAmount);
            AudioSource.PlayClipAtPoint(healthPickup, Camera.main.transform.position, shootVolume);
            Destroy(gameObject);
        }
    }
}
