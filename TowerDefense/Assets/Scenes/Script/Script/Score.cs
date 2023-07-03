using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI points;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI end;
    public TextMeshProUGUI Tutorial;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Bosslife;
    public TextMeshProUGUI Enemylife;
    public GameObject button;
    public GameObject resume;
    public static int ispaused = 0;
    public Image coracao1;
    public Image coracao2;
    public Image coracao3;
    public bool tirartorre = false;
    public bool tirartorre2 = false;
    
    

    private void Start() {
        if(Tutorial != null){
            Tutorial.text = "Press X to place a Tower\nA tower costs 10 so be careful\nYou win 20 every time you kill an enemy\nGood Luck!|Have Fun!";
            
        }
        if(button!=null && resume!=null){
            button.gameObject.SetActive(false);
            resume.gameObject.SetActive(false);
        }
    }
    private void Update()
    {

        if(Tutorial!= null && Input.GetKey(KeyCode.X)){
            Tutorial.text = "";
        }
        if (damage!=null)
        {
            damage.text = "Damage : " + GlobalPath.damage.ToString();
        }
        if (Speed!=null)
        {
            Speed.text = "Speed : " + (40f+GlobalPath.speed).ToString();
        }
        if (Bosslife!=null)
        {
            Bosslife.text = "Boss Life : " + (GlobalPath.enemylife * 3).ToString();
        }
        if (Enemylife!=null)
        {
            Enemylife.text = "Enemy Life : " + GlobalPath.enemylife.ToString();
        }

        
        if (coracao1!=null && coracao2 != null && coracao3 != null){
            if(GlobalPath.lifes == 3){
                coracao1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
                coracao2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
                coracao3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
            }
            if(GlobalPath.lifes == 2){
                coracao1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
                coracao2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
                coracao3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");

                System.Random random = new System.Random();
                if(GlobalPath.towers.Count>0 && !tirartorre)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
                if(GlobalPath.towers.Count>0 && !tirartorre)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
                tirartorre = true;
            }
            if(GlobalPath.lifes == 1){
                coracao1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração");
                coracao2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");
                coracao3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");
                System.Random random = new System.Random();
                
                if(GlobalPath.towers.Count>0 && !tirartorre2)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
                if(GlobalPath.towers.Count>0 && !tirartorre2)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);

                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
                tirartorre2 = true;
            }
            if(GlobalPath.lifes == 0){
                coracao1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");
                coracao2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");
                coracao3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Coração-vazio");
            }
            
        }
        if (points!=null)
        {
            points.text = "Score : " + GlobalPath.enemycount.ToString();
        }
        if (Money!=null)
        {
            Money.text = "Money : " + GlobalPath.money.ToString();
        }
        if(GlobalPath.lifes == 0 && end != null){
            //game over
            
           
                if(SceneManager.GetActiveScene().name == "SampleScene"){
                    end.text = "Try Again?\n Press R";
                    Time.timeScale = 0f;
                    GlobalPath.win = true;

                    if(Input.GetKey(KeyCode.R)){
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        GlobalPath.Resetgame();
                        Time.timeScale = 1f;
                        
                    }
                }
                else{
                    end.text = "Game Over\n Press Space to Complete the Game";
                    Time.timeScale = 0f;
                    GlobalPath.win = true;
                    if(Input.GetKey(KeyCode.Space)){
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold")+GlobalPath.enemycount);
                        if(PlayerPrefs.GetInt("Score") < GlobalPath.enemycount){
                            PlayerPrefs.SetInt("Score", GlobalPath.enemycount);
                        }
                        GlobalPath.Resetgame();
                        SceneManager.LoadScene("Main_Menu");
                        Time.timeScale = 1f;
                    }
                }

            

        }
        
        if(GlobalPath.HasKilledfst == false && end != null && GlobalPath.lifes < 3 && Tutorial != null){
            //game over
            Tutorial.text = "";
            end.text = "Try Again?\n Press R";
            if(Input.GetKey(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GlobalPath.Resetgame();
                
            }
        }
        if(GlobalPath.nenemys == 5 && end != null && GlobalPath.lifes > 0 ){
            //win
            if(GlobalPath.enemies.Count == 0){
                if(SceneManager.GetActiveScene().name == "SampleScene")
                {
                    end.text = "You Win !\n Press Space to Complete the Game";
                }

            }
        }
        if(end != null){
                    if(end.text == "You Win !\n Press Space to Complete the Game" && Input.GetKey(KeyCode.Space)){
                        GlobalPath.Resetgame();
                        SceneManager.LoadScene("Main_Menu");
        }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                if(GlobalPath.pause==false && button!=null && resume!=null){
                    GlobalPath.pause = true;
                    Time.timeScale = 0f;
                    button.gameObject.SetActive(true);
                    resume.gameObject.SetActive(true);

                    
                }
                else{
                    GlobalPath.pause = false;
                    Time.timeScale = 1f;
                    button.gameObject.SetActive(false);
                    resume.gameObject.SetActive(false);
                }
        }
        if(GlobalPath.pause == false && Time.timeScale == 1f && GlobalPath.win == false){
            Time.timeScale = 1f;
            button.gameObject.SetActive(false);
            resume.gameObject.SetActive(false);
        }


    }
}