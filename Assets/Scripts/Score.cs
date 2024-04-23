using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text eggCountText;
    public int eggCount;

    void Update()
    {
        eggCount = Flag.eggCount;
        eggCountText.text = "Egg Count: " + eggCount.ToString();
    }
}