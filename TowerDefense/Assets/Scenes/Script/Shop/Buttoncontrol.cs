using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttoncontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclick_Exit(){
        SceneManager.LoadScene("Main_Menu");
    }
    public void Onclick_torres(){
        if(PlayerPrefs.GetInt("Gold")>=100){
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold")-200);
            PlayerPrefs.SetInt("ntowers", PlayerPrefs.GetInt("ntowers")+1);

        }

        
    }
    public void Onclick_dmg(){
        if(PlayerPrefs.GetInt("Gold")>=100){
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold")-100);
            PlayerPrefs.SetInt("damage", PlayerPrefs.GetInt("damage")+10);

        }
    }
    public void Onclick_velocidade(){
        if(PlayerPrefs.GetInt("Gold")>=100){
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold")-100);
            PlayerPrefs.SetInt("speed", PlayerPrefs.GetInt("speed")+2);

        }
    }
}
