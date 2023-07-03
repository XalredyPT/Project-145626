using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int aux = PlayerPrefs.GetInt("FirstTime", 1);

        if(aux == 1){

            PlayerPrefs.SetInt("FirstTime", 0);
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("ntowers", 0);
            PlayerPrefs.SetInt("damage", 0);
            PlayerPrefs.SetInt("speed", 0);
            SceneManager.LoadScene("Historia_Inicial");


        
        }
        else{

            SceneManager.LoadScene("Main_Menu");
        }




    }


}





