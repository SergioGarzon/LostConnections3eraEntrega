using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleSystem : MonoBehaviour
{
    public enum PlayerPowers
    {
        Bug,
        Steal,
        Pixel,
        Shock,
        Lighting,
        Electricity,
        ControlZ,
        Reset,
        Delete,
        Heal,
        Updating,
        Electroshock
    }

    public enum PlayerClass
    {
        hacker,
        mage
    }

    public PlayerClass playerClass;
    public List<PlayerPowers> powers;
    public float hp;

    public BattleMachine battleSystem;

    void Start()
    {
        battleSystem = GameObject.Find("GameManager").GetComponent<BattleMachine>();

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

            StartBattle(other.gameObject.GetComponent<EnemyBattleSystem>());
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

    public void Attack(PlayerPowers power)
    {
        float powerValue = 0;

        switch (power)
        {
            case PlayerPowers.Bug:
                {
                    powerValue = UnityEngine.Random.Range(1f, 3f);

                    break;
                }
            case PlayerPowers.Steal:
                {
                    break;
                }
            case PlayerPowers.Pixel:
                {
                    break;
                }
            case PlayerPowers.Shock:
                {
                    break;
                }
            case PlayerPowers.Lighting:
                {
                    break;
                }
            case PlayerPowers.Electricity:
                {
                    break;
                }
            case PlayerPowers.ControlZ:
                {
                    break;
                }
            case PlayerPowers.Reset:
                {
                    break;
                }
            case PlayerPowers.Delete:
                {
                    break;
                }
            case PlayerPowers.Heal:
                {
                    break;
                }
            case PlayerPowers.Updating:
                {
                    break;
                }
            case PlayerPowers.Electroshock:
                {
                    break;
                }
        }

        battleSystem.AttackEnd(powerValue);
    }

    public List<PlayerPowers> GetPowers()
    {
        return powers;
    }

    public void SetDamage(float dmg)
    {
        hp -= dmg;
    }

    public void AddNewPower(PlayerPowers power)
    {
        powers.Add(power);
    }
}
