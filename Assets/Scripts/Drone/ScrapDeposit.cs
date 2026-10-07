using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDeposit : MonoBehaviour
{
    [SerializeField] private TransmitterRepair transmitterRepair;

    private void OnTriggerEnter(Collider other)
    {
        DroneInventory droneInventory = other.GetComponent<DroneInventory>();

        if (droneInventory != null)
        {
            int depositedScrap = droneInventory.RemoveAllScrap();

            if (depositedScrap > 0)
            {
                transmitterRepair.addScrap(depositedScrap);

                Debug.Log("Deposited scrap: " + depositedScrap);
                
            }
        }
    }
}
