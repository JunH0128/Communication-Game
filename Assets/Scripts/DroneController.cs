using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    // Start is called before the first frame update
    /* [SerializeField] private float moveDistance = 2f; */
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnAmount = 90f;

    private bool isMovingForward = false;

    //Drone movement methods

    private void Update()
    {
        if (isMovingForward)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;  
        }
    }
    public void MoveForward()
    {
        /* transform.position += transform.forward * moveDistance;
        Debug.Log("Drone moved forward"); */

        isMovingForward = true; //Start true 
        Debug.Log("Drone started moving forward");

    }

    public void turnLeft()
    {
        transform.Rotate(Vector3.up, -turnAmount); // Rotate left negative y
        Debug.Log("Drone turned left");
    }

    public void turnRight()
    {
        transform.Rotate(Vector3.up, turnAmount);
        Debug.Log("Drone turned right");
    }

    public void Stop()
    {
        isMovingForward = false; //Make isMovingForward false
        Debug.Log("Drone stopped");
    }
}
