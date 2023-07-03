using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public static class GlobalPath
{
    public static List<int [,]> coord = new List<int[,]>();
    public static int totalenemies = 0;
    public static int nenemys = 0; 
    public static int enemycount = 0;
    public static int lifes = 3;
    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> towers = new List<GameObject>();
    public static GameObject bullet = null;
    public static int enemytokill = 0;
    public static int money = 10;
    public static bool HasKilledfst = false;
    public static ParticleSystem ondestroyparticle;
    public static ParticleSystem shootparticle;
    public static int damage = 5;
    public static int speed = 0;
    public static bool pause = false;
    public static bool win = false;
    public static float enemylife = 20;
    public static Image Barra_vermelha;
    public static Image Barra_verde;
    public static Image Barra_preta;
    public static Image Barra_roxa;
    public static float speed_enemy = 10f;
    public static Image gelo;
    public static void Resetgame() {
        coord = new List<int[,]>();
        totalenemies = 0;
        nenemys = 0; 
        enemycount = 0;
        lifes = 3;
        enemies = new List<GameObject>();
        towers = new List<GameObject>();
        bullet = null;
        enemytokill = 0;
        money = 10;
        HasKilledfst = false;
        ondestroyparticle = null;
        shootparticle = null;
        damage = 5;
        pause = false;
        win = false;
        enemylife = 20;
        Barra_vermelha = null;
        Barra_verde = null;
        Barra_preta = null;
        Barra_roxa = null;
        speed_enemy = 10f;
        gelo = null;
        speed = 0;
        
        
        
    }
}