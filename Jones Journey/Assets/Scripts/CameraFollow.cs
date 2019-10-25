using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        //camera and player position at the same position
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //check if a player is still alive
        if (playerTransform != null)
        {
            //camera position restriction
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

            //update position at every frame 
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);

        }
     
        
    }
}
