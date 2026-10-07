using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroneInventory : MonoBehaviour
{
    [SerializeField] private int maxScrap = 3;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text scrapText;

    private int carriedScrap = 0;

    public int CarriedScrap => carriedScrap;
    public int MaxScrap => maxScrap;


    private void Start()
    {
        UpdateScrapUI();
    }

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

        UpdateScrapUI();

        return true;
    }

    public int RemoveAllScrap()
    {
        int amount = carriedScrap;
        carriedScrap = 0;
        UpdateScrapUI();
        return amount;
    }

    private void UpdateScrapUI()
    {
        if (scrapText != null)
        {
            scrapText.text = carriedScrap + "/" + maxScrap;
        }
    }

    
}
