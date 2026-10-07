using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        DroneHealth droneHealth = other.GetComponent<DroneHealth>();

        if (droneHealth != null)
        {
            droneHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
