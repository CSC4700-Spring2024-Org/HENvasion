using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public TMP_Text obj_text;
    public TMP_InputField display;

    public void Start()
    {
        obj_text.text = PlayerPrefs.GetString("user_name");
    }


    public void Create()
    {
        obj_text.text = display.text;
        PlayerPrefs.SetString("user_name", obj_text.text);
        PlayerPrefs.Save();
        Debug.Log(obj_text.text);
    }
    
}