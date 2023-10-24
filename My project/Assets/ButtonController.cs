using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Reference to the button UI element
    public Button myButton;

    void Start()
    {
        // Attach the method to the button's click event
        myButton.onClick.AddListener(ButtonClick);
    }

    // Method to be called when the button is clicked
    void ButtonClick()
    {
        Debug.Log("Button Pressed!");
    }
}