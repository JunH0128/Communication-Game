using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarTracker : MonoBehaviour
{
    [SerializeField] private Transform drone;
    [SerializeField] private Transform home;
    [SerializeField] private RectTransform droneIcon; // RectTransform for the drone icon on the radar

    [SerializeField] private float radarScale = 2f; 
    
    // Update is called once per frame
    void Update()
    {
       Vector3 Offset = drone.position - home.position; // Get the offset of the drone from the home position

        Vector2 radarPosition = new Vector2(
            Offset.x,
            Offset.z
        ) * radarScale;

        
        droneIcon.anchoredPosition = radarPosition; 

        // Euler to get rotation
        droneIcon.localEulerAngles = new Vector3(0, 0, -drone.eulerAngles.y); // Rotate drone icon based on the drone's rotation

    }

   
}
