using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInventory : MonoBehaviour
{
    [SerializeField] private int maxScrap = 3;

    private int carriedScrap = 0;

    public int CarriedScrap => carriedScrap;
    public int MaxScrap => maxScrap;

    public bool AddScrap(int amount)
    {
        if (carriedScrap >= maxScrap)
        {
            return false;
        }

        carriedScrap += amount;
        
        if (carriedScrap > maxScrap)
        {
            carriedScrap = maxScrap;
        }

        return true;
    }

    public int RemoveAllScrap()
    {
        int amount = carriedScrap;
        carriedScrap = 0;
        return amount;
    }

    
}
