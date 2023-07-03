using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Poderes : MonoBehaviour
{
    public Button AumentarDano;
    public Button AumentarVelocidade;
    public Button pararButton;
    public Button tirarDano;
    public Image AumentarDanoImage;
    public Image AumentarVelocidadeImage;
    public Image pararImage;
    public Image tirarDanoImage;
    private bool aumDanopressed = false;
    private bool aumVelocidadepressed = false;

    private float tempoTotaldano = 30f;
    private float tempoAtualdano = 0f;
    private float tempohabilidadedano = 5f;
    private float tempoTotal = 30f;
    private float tempoAtual = 0f;
    private float tempohabilidade = 10f;
    private float tempoTotalparar = 30f;
    private float tempoAtualparar = 0f;
    private float tempohabilidadeparar = 10f;
    private float tempoTotaltirar = 30f;
    private float tempoAtualtirar = 0f;
    private bool parar = false;
    private int velocidade;
    private bool danoreset = false;
    private bool velocidadereset = false;
    private bool pararreset = false;
    private bool tirarDanoPressed = false;
    private void Start() {
        AumentarDano = GetComponent<Button>();
        AumentarVelocidade = GetComponent<Button>();
        pararButton = GetComponent<Button>();
        tirarDano = GetComponent<Button>();



        //load player prefs speed

        velocidade = PlayerPrefs.GetInt("speed");
    }
    private void Update() {
        if(aumDanopressed){
            AumentarDano.enabled = false;
            tempoAtualdano += Time.deltaTime;
            
            AumentarDanoImage.fillAmount = tempoAtualdano / tempoTotaldano;

            if(tempoAtualdano >= tempohabilidadedano){
                if(!danoreset){
                    if((GlobalPath.damage /2) % 10 != 0){
                        GlobalPath.damage = GlobalPath.damage / 2;
                    }
                    else{
                        GlobalPath.damage = (GlobalPath.damage / 2 ) + 5;
                    }

                    
                    danoreset = true;
                }

            }
            if(tempoAtualdano >= tempoTotaldano){
                aumDanopressed = false;
                tempoAtualdano = 0f;
                danoreset = false;
                AumentarDano.enabled = true;

            }
            
        }



        if(aumVelocidadepressed){
            AumentarVelocidade.enabled = false;
            tempoAtual += Time.deltaTime;
            
            AumentarVelocidadeImage.fillAmount = tempoAtual / tempoTotal;
            if(tempoAtual >= tempohabilidade){
                if(!velocidadereset){

                    GlobalPath.speed = GlobalPath.speed -30;
                    velocidadereset = true;
                }

            }
            if(tempoAtual >= tempoTotal){
                aumVelocidadepressed = false;
                tempoAtual = 0f;
                velocidadereset = false;
                AumentarVelocidade.enabled = true;

            }
            
        }


        if(parar){
            pararButton.enabled = false;
            tempoAtualparar += Time.deltaTime;
            
            pararImage.fillAmount = tempoAtualparar / tempoTotalparar;
            if(tempoAtualparar >= tempohabilidadeparar){
                if(!pararreset){
                    GlobalPath.speed_enemy = 10f;
                    pararreset = true;
                }

            }
            if(tempoAtualparar >= tempoTotalparar){
                parar = false;
                tempoAtualparar = 0f;
                pararreset = false;
                pararButton.enabled = true;

            }
            
        }

    
    if(tirarDanoPressed){
            tirarDano.enabled = false;
            tempoAtualtirar += Time.deltaTime;
            
            tirarDanoImage.fillAmount = tempoAtualtirar / tempoTotaltirar;
            if(tempoAtualtirar >= tempoTotaltirar){
                tirarDanoPressed = false;
                tempoAtualtirar = 0f;
                tirarDano.enabled = true;

            }
            
        }



    }
    public void AumentarDanoPressed(){
        if(!aumDanopressed){
            aumDanopressed = true;

            GlobalPath.damage = GlobalPath.damage * 2;
            System.Random random = new System.Random();
            
                if(GlobalPath.towers.Count>0)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
        }



    }
    public void AumentarVelocidadePressed(){
        if(!aumVelocidadepressed){
            aumVelocidadepressed = true;
            GlobalPath.speed = GlobalPath.speed + 30;
            System.Random random = new System.Random();
                if(GlobalPath.towers.Count>0)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
        }
    }
    public void pararPressed(){
        if(!parar){
            parar = true;
            GlobalPath.speed_enemy = 0f;
            System.Random random = new System.Random();
            
                if(GlobalPath.towers.Count>0)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
            
                if(GlobalPath.towers.Count>0)
                {
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }



            
        }
    }
    public void on_tirarDanoPressed(){
        if(!tirarDanoPressed){
            tirarDanoPressed = true;
            System.Random random = new System.Random();
            
                if(GlobalPath.towers.Count>0)
                {   
                    int aux = random.Next(0,GlobalPath.towers.Count);
                    Destroy(GlobalPath.towers[aux]);
                    GlobalPath.towers.RemoveAt(aux);
                }
            foreach(GameObject enemy in GlobalPath.enemies){
                if(enemy.GetComponent<EnemyMov>() != null){
                    enemy.GetComponent<EnemyMov>().life = enemy.GetComponent<EnemyMov>().life/2;
                }

            }
            foreach(GameObject enemy in GlobalPath.enemies){
                if(enemy.GetComponent<BossMov>() != null){
                    enemy.GetComponent<BossMov>().life = 3*(enemy.GetComponent<BossMov>().life/4);
                }
                
            }
        }
    }

}