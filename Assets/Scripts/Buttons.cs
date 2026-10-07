using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public enum ButtonType
    {
        Dot,
        Dash,
        Transmit,
        Clear
    }

    [SerializeField] private ButtonType buttonType;
    [SerializeField] private MorsePanelScript console;

    [Header("Button Animation")]
    [SerializeField] private float pressDistance = 0.02f;
    [SerializeField] private float pressTime = 0.08f;

    private Vector3 startingPosition;
    private bool isAnimating;

    private void Start()
    {
        startingPosition = transform.localPosition;
    }

    public void Press() // Button press method called / Player Interaction.cs / Raycast shit
    {
        if (isAnimating)
            return;

        switch (buttonType)
        {
            case ButtonType.Dot:
                console.AddDot();
                break;

            case ButtonType.Dash:
                console.AddDash();
                break;

            case ButtonType.Transmit:
                console.Transmit();
                break;

            case ButtonType.Clear:
                console.Clear();
                break;
        }

        // Start the button press animation
        StartCoroutine(ButtonPressAnimation());
    }

    private IEnumerator ButtonPressAnimation() // Button Press Animation 
    {
        isAnimating = true;

        Vector3 pressedPosition =
            startingPosition + transform.forward * pressDistance; // Make button go backwards

        float timer = 0f;

        // Press timer
        while (timer < pressTime)
        {
            timer += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(
                startingPosition,
                pressedPosition,
                timer / pressTime
            ); // Lerp to moved positions

            yield return null; // Waiting
        }

        timer = 0f;

        // Wait timer

        while (timer < pressTime)
        {
            timer += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(
                pressedPosition,
                startingPosition,
                timer / pressTime
            );

            yield return null;
        }

        // Reset methods

        transform.localPosition = startingPosition;// Reset to starting position
        isAnimating = false; // Reset to false
    }
}