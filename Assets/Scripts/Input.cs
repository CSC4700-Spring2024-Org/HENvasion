using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public InputField inputField;
    public string userInput;

    public void SaveInput()
    {
    userInput = inputField.text;
    PlayerPrefs.SetString("UserInput", userInput);
    }
    
    public string getUsername() {
        return userInput;
    }
}