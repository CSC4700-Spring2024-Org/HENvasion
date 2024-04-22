using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUserInput : MonoBehaviour
{
    public TMP_Text displayText;
    public string userInput;


    void Update() {
        displayText.text = PlayerPrefs.GetString("user_name");
        Debug.Log(PlayerPrefs.GetString("user_name"));
    }
}