using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
