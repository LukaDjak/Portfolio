using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text text; 
    public static float score; 

    void Start()
    {
        text = GetComponent<Text>(); 
    }

    void Update()
    {
        text.text = score.ToString(); 
    }
}
