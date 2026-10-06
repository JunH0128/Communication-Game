using UnityEngine;

public class FlickeringLight3D : MonoBehaviour
{
    [SerializeField] private Light lightSource;

    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1.2f;

    [SerializeField] private float flickerChance = 0.08f;
    [SerializeField] private float flickerSmoothness = 10f;

    private float targetIntensity;

    private void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        if (lightSource != null)
        {
            targetIntensity = lightSource.intensity;
        }
    }

    private void Update()
    {
        if (lightSource == null)
            return;

        if (Random.value < flickerChance)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        lightSource.intensity = Mathf.Lerp(
            lightSource.intensity,
            targetIntensity,
            Time.deltaTime * flickerSmoothness
        );
    }
}