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
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            if (Time.timeScale != 0f)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = rotation;

                if (Input.touchCount == 1)
                {
                    if (Time.time >= shotTime)
                    {

                        AudioSource.PlayClipAtPoint(playerShot, Camera.main.transform.position, shootVolume);
                        Instantiate(bullet, shotPoint.position, shotPoint.transform.rotation);

                        shotTime = Time.time + timeBetweenShots;
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{

       
    

    //}
}
