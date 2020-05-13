using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMachineStreet : MonoBehaviour
{


//start=comienza la batalla
//player selection= para elegir con cual atacar
//skillselection= para elegir ataque 
//enemyselection= para elegir virus a atacar 
//enemy tur= virus elije ccn cual atacar 
//enemy select= Virus elije ataque 
//enemy select player = elije a que jugador atacar 

    public GameObject mago, hacker, virus1;

    private Player _player;
    public static BattleMachineStreet Instance;

    public static bool OnPlayerTurn = true;

    public BattleStates states;

    private bool _battle = true;

    public ScoreData scoreData;
    public ShopData shopData;

    private Virus1 _virus1System;
    private Hacker _hackerSystem;
    private Mago _magoSystem;

    public Text dialogText;

    private int _scoreBattleEnemy = 100;
    private int _damage;

    public static bool IsPlayerChoosing = false;
    public static bool IsEnemyChoosing = false;

    public GameObject collisionZone2;
    private StartLevel2 _startLevel2;

    private CharacterController1 _characterController1;
    public int lifeBattleVirus1 = 100;

    public bool isEnemySelected;
    public bool virus1Choosed = false;

    private bool lostGame;

    private int activateButtonState;
    private int botonPresionado;


    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreData.mana = 100;
        _characterController1 = GetComponent<CharacterController1>();
        states = BattleStates.Start;
        _startLevel2 = collisionZone2.GetComponent<StartLevel2>();
        StartCoroutine(SetUpBattle());


        this.lostGame = false;
        this.activateButtonState = 0;
        this.botonPresionado = 0;
    }

    void Update()
    {
        switch (states)
        {
            case BattleStates.Start:
                this.setActivateButtonStatePlayerEnemy(1);
                break;


            case BattleStates.PlayerSelection:

                

                this.dialogText.text = "Select Hacker H o E ,  Life energy Hacker: " + this.scoreData.hLife + ", Mago: " + this.scoreData.mLife +
                    "\n Vida del enemigo 1 " + lifeBattleVirus1;

                Debug.Log("H o E");

                if (Input.GetKeyDown(KeyCode.H) || this.botonPresionado == 1)
                {
                    Player.IsHackerPlaying = true;
                    dialogText.text = "You selected hacker";
                    states = BattleStates.EnemySelection;
                    

                }
                else if (Input.GetKeyDown(KeyCode.E) || this.botonPresionado == 2)
                {
                    dialogText.text = "You selected mago";
                    Player.IsMagoPlaying = true;
                    states = BattleStates.EnemySelection;
                }

                break;

            case BattleStates.SkillSelection:

                this.dialogText.text = "Select an action  \n\n ScoreData ShootPoint: " + scoreData.shootingPoints;

                if (Player.IsMagoPlaying)
                {
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        _damage = 5;
                        // _states.Pixeling();
                        Debug.Log("pixel");
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(KeyCode.K) && Mago.Instance._electricityLimit > 0)
                    {
                        _damage = 10;
                        scoreData.xp +=10;
                        //_states.Electricity();
                        Debug.Log("Electricity");
                        Player.IsMagoPlaying = false;
                        Mago.Instance._electricityLimit--;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(KeyCode.L) && scoreData.mana>=25)
                    {
                        //_states.Light();
                        Debug.Log("Light");
                        _damage = 15;
                        scoreData.mana -= 25;
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                        scoreData.xp += 10;
                    }
                    else if (Input.GetKeyDown(KeyCode.M)&& shopData.healSold==true )
                    {
                        scoreData.hLife = 100;
                        scoreData.mLife = 100;
                        scoreData.mana = 0;
                        Debug.Log("heal");
                        _damage = 0;
                        Player.IsMagoPlaying = false;
                        RestScore();
                        scoreData.xp += 5;
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(KeyCode.N)&& shopData.electroshockSold==true)
                    {
                        _damage = 20;
                        Debug.Log("electroshock");
                        Player.IsMagoPlaying = false;
                        scoreData.xp += 5;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if(Input.GetKeyDown(KeyCode.O)&& shopData.updateSold==true)
                    {
                        scoreData.mLife += 50;
                        _damage = 0;
                        Debug.Log("update");
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    if (lifeBattleVirus1 <= 0 )
                    {
                        states = BattleStates.Won;
                    }
                }
                else if (Player.IsHackerPlaying)
                {
                    if (Input.GetKey(KeyCode.H))
                    {
                        _damage = 5;
                        Debug.Log("1");
                        Player.IsHackerPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;

                    }
                    else if (Input.GetKey(KeyCode.K))
                    {
                        _damage = 10;
                        Debug.Log("2");
                        Player.IsHackerPlaying = false;
                        scoreData.xp += 5;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKey(KeyCode.L)&& scoreData.mana>=25)//añadir condicion 
                    {
                        _damage = 15;
                        scoreData.mana -= 25;
                        Debug.Log("3");
                        scoreData.xp += 10;
                        Player.IsHackerPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(KeyCode.M)&& shopData.resettingSold==true)
                    {
                        scoreData.hLife = 100;
                        scoreData.mana += 25;
                        Debug.Log("4 shop");
                        Player.IsHackerPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKeyDown(KeyCode.N) && shopData.controlzSold == true)
                    {
                        scoreData.hLife = +_damage;
                        _damage = 0;
                        Debug.Log("5 shop");
                        Player.IsHackerPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;                   
                    }
                    else if (Input.GetKeyDown(KeyCode.O) && shopData.deleteSold == true)
                    {
                        _damage = 20;
                        scoreData.xp += 5;
                        Debug.Log("6 shop");
                        Player.IsHackerPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                }
                break;
            case BattleStates.EnemySelection:

                this.dialogText.text = "Select an anemy to attack";
                Debug.Log("B o V");

                this.setActivateButtonStatePlayerEnemy(2);

                if (Input.GetKey(KeyCode.V))
                {
                    this.dialogText.text = ("Attack to Virus");
                    virus1Choosed = true;
                    states = BattleStates.SkillSelection;
                }
                
                if (lifeBattleVirus1 <= 0)
                {
                    states = BattleStates.Won;
                    EndBattle();
                }
                break;

            case BattleStates.Enemyturn:
                Debug.Log("Enemy Turn");
                dialogText.text = "Enemy Turn";
                
                this.dialogText.text = ("Virus is playing");
                    Debug.Log("enemy 1");
                    Virus1 virus1Controller = virus1.GetComponent<Virus1>();
                    Enemy.IsVirus1Playing = true;
                    dialogText.text = "Virus 1 Attacking! \n\n" + virus1Controller.ToString();
                    states = BattleStates.EnemySelect;
                    break;
            
            case BattleStates.EnemySelect:

                RandomState.StateLimits = 3;
                RandomState.RandomStateMethod();
                this.dialogText.text = ("Virus is choosing");
                switch (RandomState.StateE)
                {
                    case 1:
                        //_states.Attack();
                        _damage = 5;
                        this.dialogText.text = ("2-Invisibility");
                        Debug.Log("enemy");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 2:
                        //_states.Attack();
                        _damage = 10;
                        this.dialogText.text = ("2-Attack");
                        Debug.Log("enemy");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 3:
                        //_states.Scanner();
                        _damage = 15;
                        this.dialogText.text = ("2-Scanner");
                        Debug.Log("enemy");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    default:
                        this.dialogText.text = ("No anda el virus");
                        Enemy.IsVirus1Playing = false;
                        break;
                }

                //states = BattleStates.EnemySelect;  //Esto lo puse yo para probar
                break;


            case BattleStates.EnemySelectPlayer:


                if (RandomState.StateE % 2 == 0)
                {
                    this.dialogText.text = ("Attack to Hacker");
                    Debug.Log("to hacker");
                    scoreData.hLife = scoreData.hLife - _damage;
                    //states = BattleStates.PlayerSelection;
                }
                else
                {
                    this.dialogText.text = ("Attack to Mago");
                    Debug.Log("to mago");
                    scoreData.mLife = scoreData.mLife - Virus1.Instance._damage;
                    //states = BattleStates.PlayerSelection;
                }


                //Le ponemos un OR exclusivo
                if (scoreData.hLife <= 0 || scoreData.mLife <= 0) //el score es la vida de los players
                {
                    states = BattleStates.Lost;
                    EndBattle();
                }

                //this.dialogText.text = "Vida del personaje " + scoreData.mLife + ", hacker: " + scoreData.hLife;


                //Esto lo puse yo para probar
                states = BattleStates.PlayerSelection;

                break;

            default: break;
        }
        /*  if (OnPlayerTurn)
          {
              states = BattleStates.PlayerTurn;
              StartCoroutine(PlayerTurn());
          }
          else if (!OnPlayerTurn)
          {
              states = BattleStates.Enemyturn;
              StartCoroutine(EnemyTurn());
          }*/
    }

    IEnumerator SetUpBattle()
    {
        dialogText.text = "SetUp Battle";
        yield return new WaitForSeconds(1f);

        dialogText.text = "Battle 1";
        yield return new WaitForSeconds(1f);

        states = BattleStates.PlayerSelection;
    }


    void EndBattle()
    {
        if (states == BattleStates.Won)
        {
            dialogText.text = "You won the battle!";
            scoreData.xp += 50;
            _characterController1.GoBackCity();
            _startLevel2.enabled = true;

        }
        else if (states == BattleStates.Lost)
        {
            scoreData.xp -= 50;
            dialogText.text = "You loose";
            this.lostGame = true;
        }
    }
    void RestScore()
    {

        if (virus1Choosed)
        {
            lifeBattleVirus1 = lifeBattleVirus1 - _damage;
            virus1Choosed = false;
        }
    }
    public float[] getValueBattle()
    {
        float[] vector = new float[4];

        vector[0] = this.scoreData.hLife;
        vector[1] = this.scoreData.mLife;
        vector[2] = this.lifeBattleVirus1;

        return vector;
    }
    public bool getLostGame()
    {
        return lostGame;
    }
    public void setActivateButtonStatePlayerEnemy(int valor)
    {
        this.activateButtonState = valor;
    }


    public int getActivateButtonStatePlayerEnemy()
    {
        return this.activateButtonState;
    }

    public void setBotonPresionado(int valor)
    {
        this.botonPresionado = valor;
    }
}

