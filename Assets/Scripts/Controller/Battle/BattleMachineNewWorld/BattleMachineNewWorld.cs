using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStates2
{
    Start,
    PlayerSelection,
    SkillSelection,
    EnemySelection,
    Enemyturn,
    EnemySelect,
    EnemySelectPlayer,
    Won,
    Lost
}
public class BattleMachineNewWorld : MonoBehaviour
{
    public GameObject mago, hacker, virus1;
    private Player _player;

    public static BattleMachine Instance;

    public static bool OnPlayerTurn = true;

    public BattleStates2 states;


    public ScoreData scoreData;


    private Hacker _hackerSystem;
    private Mago _magoSystem;
    private Virus1 _virus1System;

    public Text dialogText;

    private int _damage;

    public static bool IsPlayerChoosing = false;
    public static bool IsEnemyChoosing = false;

    private int lifeBattleVirus1 = 100;
    public bool isEnemySelected;
    public bool virus1Choosed = false;
    public bool virus2Choosed = false;
    private int contador = 2;

    private int botonesActivados;
    private int veracidad;




    void Start()
    {
        states = BattleStates2.Start;
        StartCoroutine(SetUpBattle());

        this.botonesActivados = 0;
        this.veracidad = 0;


    }

    void Update()
    {
        switch (states)
        {
            case BattleStates2.Start:
                this.veracidad = 0;
                break;

            case BattleStates2.PlayerSelection:
                PlayerSelection();
                break;

            case BattleStates2.EnemySelection:
                EnemySelection();
                break;

            case BattleStates2.EnemySelect:
                SeleccionarEnemigo();
                break;


            case BattleStates2.EnemySelectPlayer:
                EnemySelectPlayer();
                break;



            case BattleStates2.SkillSelection:
                //Acá va a ir Skill Selection
                SkillSelection();
                break;


            case BattleStates2.Enemyturn:
                EnemyTurnMethod();
                break;

            default: break;
        }
    }


    private void PlayerSelection()
    {
        //BattleStates.PlayerSelection:

        if (this.botonesActivados == 1)
        {
            Player.IsHackerPlaying = true;
            Player.IsMagoPlaying = false;
            states = BattleStates2.EnemySelection;
        }

        if (this.botonesActivados == 2)
        {
            Player.IsHackerPlaying = false;
            Player.IsMagoPlaying = true;
            states = BattleStates2.EnemySelection;
        }
    }


    private void SeleccionarEnemigo()
    {
        RandomState.StateLimits = 3;
        RandomState.RandomStateMethod();

        switch (RandomState.StateE)
        {
            case 1:
                _damage = 5;
                Enemy.IsVirus1Playing = false;
                states = BattleStates2.EnemySelectPlayer;
                break;
            case 2:
                _damage = 10;
                Enemy.IsVirus1Playing = false;
                states = BattleStates2.EnemySelectPlayer;
                break;
            case 3:
                _damage = 15;
                Enemy.IsVirus1Playing = false;
                states = BattleStates2.EnemySelectPlayer;
                break;

            default:
                Enemy.IsVirus1Playing = false;
                break;
        }
    }

    private void EnemySelection()
    {
        states = BattleStates2.SkillSelection;


        if (lifeBattleVirus1 <= 0)
        {
            states = BattleStates2.Won;
            EndBattle();
        }
    }

    private void EnemySelectPlayer()
    {
        int valor = Random.Range(1, 10);

        if (valor % 2 == 0)
        {
            scoreData.hLife = scoreData.hLife - _damage;
            states = BattleStates2.PlayerSelection;
        }
        else
        {
            scoreData.mLife = scoreData.mLife - _damage;
            states = BattleStates2.PlayerSelection;
        }

        this.veracidad = 0;

        if (scoreData.hLife <= 0 & scoreData.mLife <= 0) //el score es la vida de los players
        {
            states = BattleStates2.Lost;
            EndBattle();
        }
    }

    private void SkillSelection()
    {
        this.veracidad = 1;

        if (Player.IsMagoPlaying)
        {

            if (this.botonesActivados == 6)
            {
                // _states.Pixeling();
                _damage = 5;
                Player.IsMagoPlaying = false;
                RestScore();
                states = BattleStates2.Enemyturn;
            }
            else if (this.botonesActivados == 7 && Mago.Instance._electricityLimit > 0)
            {
                _damage = 10;
                //_states.Electricity();
                Player.IsMagoPlaying = false;
                Mago.Instance._electricityLimit--;
                RestScore();
                states = BattleStates2.Enemyturn;
            }
            else if (this.botonesActivados == 8 && scoreData.shootingPoints == 100)
            {
                _damage = 15;
                //_states.Light();
                Player.IsMagoPlaying = false;
                RestScore();
                states = BattleStates2.Enemyturn;
                scoreData.shootingPoints = 0;
            }
            if (lifeBattleVirus1 <= 0)
            {
                states = BattleStates2.Won;
            }
        }


        if (Player.IsHackerPlaying)
        {

            if (this.botonesActivados == 3)
            {
                _damage = 5;
                states = BattleStates2.Enemyturn;
                Player.IsHackerPlaying = false;
            }

            if (this.botonesActivados == 4)
            {
                _damage = 10;
                Hacker.Instance._damage = 10;
                states = BattleStates2.Enemyturn;
                Player.IsHackerPlaying = false;
            }

            if (this.botonesActivados == 5)//añadir condicion 
            {
                _damage = 15;
                states = BattleStates2.Enemyturn;
                Player.IsHackerPlaying = false;
            }
        }
    }


    private void EnemyTurnMethod()
    {


        if (contador % 2 == 0)
        {
            Virus1 virus1Controller = virus1.GetComponent<Virus1>();
            Enemy.IsVirus1Playing = true;
            states = BattleStates2.EnemySelect;
        }

        contador++;
    }

    IEnumerator SetUpBattle()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);

        states = BattleStates2.PlayerSelection;
    }

    void EndBattle()
    {
        if (states == BattleStates2.Won)
        {
            dialogText.text = "BATTLE WIN!";

        }
        else if (states == BattleStates2.Lost)
        {
            dialogText.text = "BATTLE LOST";
        }
    }

    void RestScore()
    {

        lifeBattleVirus1 = lifeBattleVirus1 - _damage;
        virus1Choosed = false;
    }

    public int getRetornarVidaEnemigo()
    {
        return lifeBattleVirus1;
    }


    public void setBotonesHabilitados(int valor)
    {
        this.botonesActivados = valor;
    }


    public int getReturnVeracidad()
    {
        return this.veracidad;
    }
}
