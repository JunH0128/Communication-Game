using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] public AudioSource buttonPress;
    [SerializeField] public AudioSource transmitPress;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward); // Camera Position

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance)) // Raycast  Detection
        {
            Buttons button = hit.collider.GetComponent<Buttons>(); // If raycast hits a button get the component

            if (button != null)
            {
                if (button != null)
                {
                    if (button.CompareTag("Transmit"))
                    {
                        if (transmitPress != null)
                            transmitPress.Play();
                    }
                    else
                    {
                        if (buttonPress != null)
                            buttonPress.Play();
                    }

                    Debug.Log("Interacted with button");
                    button.Press();
                }


            }

        }
    }
}
