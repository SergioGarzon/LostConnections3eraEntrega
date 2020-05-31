﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleSystem : MonoBehaviour
{

    public enum PlayerPowers //Los Prefabs en la carpeta de resources AttackFX tienen que estar en el mismo orden que estos enums
    {
        Bug, //Le saca 50 al virus en el nivel 1 pero le resta 60 de mana a uno
        Steal, //Le saca 10 al enemigo y le suma 30 en mana a uno mismo
        Pixel, //Le saca 20 al virus y le resta 30 de mana 
        Shock, //Le saca 20 al enemigo y resta 25 de mana
        Lighting, //Resta 50 al enemigo y resta 50 de mana
        Electricity, //Resta 50 al enemigo y resta 50 de mana

        ControlZ, //Poder exclusivo de charlie, 
                  //recupera la vida robada por el enemigo 
                  //(Revierte el ataque recibido pero resta 20 de mana)
        Reset, //Poder exclusivo de Charlie, reinicia toda la batalla desde cero, inclusive los estados tanto del equipo como el enemigo
        Delete, //Poder exclusivo de Charlie que suma tanto mana como daño que ocasiona el enemigo
        Heal, //Restaura la vida de todo el equipo incluidad la suya pero dejara inhabilitado para pelear momentaneamente
        Updating, //Restaura el mana de Atif pero no produce daño al enemigo
        Electroshock //Poderoso ataque Atif que daña tanto al enemigo como la energia que quita
    }

    public enum PlayerClass
    {
        hacker,
        mage
    }

    public PlayerClass playerClass;
    public List<PlayerPowers> powers;
    public float hp;
    public float mana;

    public BattleMachine battleSystem;
    public ParticlesAttack particleSystem;

    void Awake()
    {
        mana = 100;
    }

    void Start()
    {
        battleSystem = GameObject.Find("GameManager").GetComponent<BattleMachine>();
        particleSystem = battleSystem.GetComponent<ParticlesAttack>();

        InitializePowers();
    }

    //Cuando el player colisiona con un Enemy inicia la batalla
    void StartBattle(EnemyBattleSystem enemy)
    {
        battleSystem.StartBattle(enemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.CompareTag("EnemiesGroup"))
        {
            Debug.Log("EnemiesGroup Trigger Enter -->");

            StartBattle(other.GetComponent<EnemyBattleSystem>());
        }
    }

    private void InitializePowers()
    {
        powers = new List<PlayerPowers>();

        switch (playerClass)
        {
            case PlayerClass.hacker:
                {
                    powers.Add(PlayerPowers.Bug);
                    powers.Add(PlayerPowers.Steal);
                    powers.Add(PlayerPowers.Pixel);

                    break;
                }
            case PlayerClass.mage:
                {
                    powers.Add(PlayerPowers.Shock);
                    powers.Add(PlayerPowers.Lighting);
                    powers.Add(PlayerPowers.Electricity);

                    break;
                }
        }

        //Load players powers
    }

    public void Attack(PlayerPowers power, Transform enemy)
    {
        float powerValue = 0;
        float mn = 0;  //Acá está lo de mana

        switch (power)
        {
            case PlayerPowers.Bug:
                {
                    //Le saca 50 al virus en el nivel 1 pero le resta 60 de mana a uno
                    powerValue = 50;
                    mn -= 60;
                    break;
                }
            case PlayerPowers.Steal:
                {
                    //Le saca 10 al enemigo y le suma 30 en mana a uno mismo
                    powerValue = 10;
                    mn += 30;
                    break;
                }
            case PlayerPowers.Pixel:
                {
                    //Le saca 20 al virus y le resta 30 de mana 
                    powerValue = 20;
                    mn -= 30;
                    break;
                }
            case PlayerPowers.Shock:
                {
                    //Le saca 20 al enemigo y resta 25 de mana
                    powerValue = 4;
                    mn -= 25;
                    break;
                }
            case PlayerPowers.Lighting:
                {
                    //Resta 50 al enemigo y resta 50 de mana
                    powerValue = 50;
                    mn -= 50;
                    break;
                }
            case PlayerPowers.Electricity:
                {
                    //Resta 10 al enemigo y suma 20 de mana
                    powerValue = 50;
                    mn += 20;
                    break;
                }
            case PlayerPowers.ControlZ:
                {
                    //Revierte el ataque recibido pero resta 20 de mana
                    mn -= 20;
                    break;
                }
            case PlayerPowers.Reset:
                {
                    //Reinicia toda la batalla pero resta todo el mana de Charlie
                    mn = 0;
                    break;
                }
            case PlayerPowers.Delete:
                {
                    //Poder exclusivo de Charlie que suma tanto mana como daño que ocasiona el enemigo
                    //Resta 30 al enemigo y suma 30 de mana
                    powerValue = 30;
                    mn += 30;
                    break;
                }
            case PlayerPowers.Heal:
                {
                    //Restaura la vida de todo el equipo
                    //No resta el mana
                    break;
                }
            case PlayerPowers.Updating:
                {
                    //No daña al enemigo pero recupera, pero suma 50 de mana
                    mn += 50;
                    break;
                }
            case PlayerPowers.Electroshock:
                {
                    powerValue = 70;
                    mn -= 70;
                    break;
                }
        }

        particleSystem.AttackPlayerPower(power, this, enemy);
        battleSystem.AttackPlayerEnd(powerValue);
        SetMana(mn);
    }

    public void AttackEnd()
    {
        battleSystem.AttackFXEnd();
    }


    public List<PlayerPowers> GetPowers()
    {
        return powers;
    }

    public void SetDamage(float dmg)
    {
        hp -= dmg;
    }

    public void SetMana(float mn)
    {
        mana += mn;
    }

    public void AddNewPower(PlayerPowers power)
    {
        powers.Add(power);
    }

    public void ReplacePower(PlayerPowers power)
    {
        //TODO - Lista de poderes comprados de cada player
    }

    public void PlayerEndBattle()
    {
        //TODO -> Reiniciar y cambiar los valores necesarios del player cuando no esta en batalla.
    }

    public float GetHP()
    {
        return hp;
    }
}
