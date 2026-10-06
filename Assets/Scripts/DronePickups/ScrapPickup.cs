using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPickup : MonoBehaviour
{

    [SerializeField] private int scrapAmount = 1;

    public void OnTriggerEnter(Collider other)
    {
        DroneInventory droneInventory = other.GetComponent<DroneInventory>();

        if (droneInventory != null)
        {
            bool collected = droneInventory.AddScrap(scrapAmount);

            if (collected)
            {
                Debug.Log("Scrap collected" );

                Destroy(gameObject);
            }
        }
    }
}
