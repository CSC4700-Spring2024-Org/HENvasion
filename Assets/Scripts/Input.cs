using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public InputField inputField;

    public void SaveInput()
    {
    string userInput = inputField.text;
    PlayerPrefs.SetString("UserInput", userInput);
    }
}