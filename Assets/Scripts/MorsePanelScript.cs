using UnityEngine;
using TMPro;

public class MorsePanelScript : MonoBehaviour
{
    [SerializeField] private TMP_Text morseText;
    [SerializeField] private DroneController drone;

    private string morseCode = "";

    public void AddDot()
    {
        if (morseCode.Length >= 3) // Limit to 3 characters
            return;

        morseCode += ".";
        UpdateScreen();
    }

    public void AddDash()
    {
        if (morseCode.Length >= 3) // Limit to 3 characters
            return;

        morseCode += "-";
        UpdateScreen();
    }

    public void Clear()
    {
        morseCode = ""; // Clear text after pressing clear
        UpdateScreen();
    }

    public void Transmit()
    {
        Debug.Log("Transmitting Morse Code: " + morseCode);

        switch (morseCode) //Switch to check code and cal drone methods
        {
            case "..-":
                drone.MoveForward();
                break;
            case ".--":
                drone.turnLeft();
                break;
            case "-..":
                drone.turnRight();
                break;
            case "---":
                drone.Stop();
                break;
            default:
                Debug.Log("Unknown Morse Code: " + morseCode);
                break;
            
        }

        morseCode = ""; // Clear after transmission
        UpdateScreen();
    }

    private void UpdateScreen() 
    {
        if (morseCode.Length == 0) // If length is equal to 0 display "Enter Code" on the screen
        {
            morseText.text = "Juns Mom";
            return;
        }

        string display = ""; // Reset 

        foreach (char symbol in morseCode)

        //Convert input to these 
        {
            if (symbol == '.')
                display += "• ";
            else if (symbol == '-')
                display += "— ";
        }

        morseText.text = display;
    }
}