using UnityEngine;
using System.Collections;

public class RadarPulse : MonoBehaviour
{
    [SerializeField] private GameObject pulseGraphic;
    [SerializeField] private float pulseDuration = 0.5f;
    [SerializeField] private float startSize = 0.05f;
    [SerializeField] private float maxSize = 3f;

    [SerializeField] private int pulseCount = 3;
    [SerializeField] private float delayBetweenPulses = 0.15f;

    private Vector3 originalScale;
    private bool isPulsing;

    private void Start()
    {
        originalScale = pulseGraphic.transform.localScale;
        pulseGraphic.SetActive(false);
    }

    public void Pulse()
    {
        if (!isPulsing)
        {
            StartCoroutine(PulseRoutine());
        }
    }

    private IEnumerator PulseRoutine()
    {
        isPulsing = true;

        for (int i = 0; i < pulseCount; i++)
        {
            pulseGraphic.SetActive(true);

            Vector3 smallScale = originalScale * startSize;
            Vector3 largeScale = originalScale * maxSize;

            pulseGraphic.transform.localScale = smallScale;

            float timer = 0f;

            while (timer < pulseDuration)
            {
                timer += Time.deltaTime;

                float progress = timer / pulseDuration;

                pulseGraphic.transform.localScale =
                    Vector3.Lerp(smallScale, largeScale, progress);

                yield return null;
            }

            pulseGraphic.SetActive(false);
            pulseGraphic.transform.localScale = originalScale;

            yield return new WaitForSeconds(delayBetweenPulses);
        }

        isPulsing = false;
    }
}