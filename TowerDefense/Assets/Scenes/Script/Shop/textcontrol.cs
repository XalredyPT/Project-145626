using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class textcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;

    public GameObject button;
    void Start()
    {
        if(text!=null){
            text.text = "Gold: " + PlayerPrefs.GetInt("Gold");
        }
        if(button!=null){
            if(PlayerPrefs.GetInt("ntowers") == 9){
                button.gameObject.SetActive(false);
            }


            }
    }   
    

    // Update is called once per frame
    void Update()
    {
            if(text!=null){
                text.text = "Gold: " + PlayerPrefs.GetInt("Gold");
        }
        
    }
}
