using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controll : MonoBehaviour
{
    
    public void Onclick_Start()
    {
        GlobalPath.Resetgame();
        SceneManager.LoadScene("Game");
    }
    public void Onclick_Exit()
    {

        Application.Quit();
    }
    public void Onclick_Shop()
    {
        SceneManager.LoadScene("Shop");
    }

}
