using UnityEngine;
using UnityEngine.UI;

public class DisplayUserInput : MonoBehaviour
{
    public Text displayText;
    public GameObject usernameText;
    string userInput;


    void Update() {
        displayText.text = userInput;
        Debug.Log(userInput);
    }
}