using UnityEngine;
using TMPro;

public class DroneHealth : MonoBehaviour
{
    [SerializeField] private int maxIntegrity = 3;

    [Header("UI")]
    [SerializeField] private TMP_Text integrityText;
    [SerializeField] private TMP_Text signalLostText;

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

        if (currentIntegrity < 0)
        {
            currentIntegrity = 0;
        }


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
            integrityText.text =
                currentIntegrity + "/" + maxIntegrity;
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