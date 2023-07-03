using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclick_Exit()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            Application.Quit();
            PlayerPrefs.SetInt("FirstTime", 1);
            

        }
        else
        {

            int aux = PlayerPrefs.GetInt("Gold", 0);
            PlayerPrefs.SetInt("Gold", aux+GlobalPath.enemycount);
            if(PlayerPrefs.GetInt("Score") < GlobalPath.enemycount){

                PlayerPrefs.SetInt("Score", GlobalPath.enemycount);
            }
            GlobalPath.Resetgame();
            Time.timeScale = 1;
            SceneManager.LoadScene("Main_Menu");

        }
        
    }
    public void Onclick_resume()
    {
        Time.timeScale = 1;
        GlobalPath.pause = false;
        

    }
}
