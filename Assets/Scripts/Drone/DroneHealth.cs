using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroneHealth : MonoBehaviour
{
    [SerializeField] private int maxIntegrity = 3;

    [Header("UI Elements")]
     [SerializeField] private TMP_Text signalLostText;
     [SerializeField] private TMP_Text integrityText;

    private int currentIntegrity;

    private void Start()
    {
        currentIntegrity = maxIntegrity;
        UpdateIntegrityUI();

        if (signalLostText != null)
        {
            signalLostText.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentIntegrity -= damage;

        Debug.Log("Drone took damage. Current integrity: " + currentIntegrity + "/" + maxIntegrity);

        UpdateIntegrityUI();

        if (currentIntegrity <= 0)
        {
            DroneDestroyed();
        }
    }

    private void UpdateIntegrityUI()
    {
        if (integrityText != null)
        {
            integrityText.text = currentIntegrity + "/" + maxIntegrity;
        }
    }

    private void DroneDestroyed()
    {
        if (signalLostText != null)
        {
            signalLostText.gameObject.SetActive(true);
            signalLostText.text = "SIGNAL LOST";
        }
        gameObject.SetActive(false);
    }
}
