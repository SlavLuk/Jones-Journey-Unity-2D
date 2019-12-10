using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private float timeBetweenShots;
    [SerializeField]
    private AudioClip playerShot;
    [SerializeField][Range(0,1)]
    private float shootVolume = 0.75f;

    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if(Time.time >= shotTime)
            {

                AudioSource.PlayClipAtPoint(playerShot, Camera.main.transform.position, shootVolume);
                Instantiate(bullet, shotPoint.position, shotPoint.transform.rotation);
                
                shotTime = Time.time + timeBetweenShots;
            }
        }

    }
}
