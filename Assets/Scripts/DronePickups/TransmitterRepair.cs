using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransmitterRepair : MonoBehaviour
{
    [SerializeField] private int scrapRequired = 10;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text scrapText;

    private int currentScrap = 0;
    
    public void addScrap(int amount)
    {
        currentScrap += amount;

        if (currentScrap > scrapRequired)
        {
            currentScrap = scrapRequired;
        }

        UpdateCounter();

        Debug.Log("Current scrap: " + currentScrap + "/" + scrapRequired);

        if (currentScrap >= scrapRequired)
        {
            RepairComplete();
        }
    }

    private void RepairComplete()
    {
        scrapText.text = "TRANSMITTER ONLINE";
        Debug.Log("Transmitter repaired");
    }

    private void UpdateCounter()
    {
        if (scrapText != null)
        {
            scrapText.text = currentScrap + "/" + scrapRequired;
        }
    }

}
