using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Text_controll : MonoBehaviour
{

    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    void Update()
    {
        if(text!=null){
            text.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
}
