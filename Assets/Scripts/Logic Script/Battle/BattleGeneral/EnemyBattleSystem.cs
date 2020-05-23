using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    public enum EnemyPowers
    {
        Scan,
        Attack,
        Infect,
        ScanBoss,
        AttackBoss,
        InfectBoss
    }

    public enum EnemyClass
    {
        virusNormal,
        virusBoss,
    }

    public List<EnemyPowers> powers;
    public EnemyClass enemyClass;

    public BattleMachine battleSystem;

    public float hp;

    void Start()
    {
        battleSystem = GameObject.Find("GameManager").GetComponent<BattleMachine>();

        hp = 20;

        SetPowers();
    }

    void SetPowers()
    {
        powers = new List<EnemyPowers>();

        switch (enemyClass)
        {
            case EnemyClass.virusNormal:
                {
                    powers.Add(EnemyPowers.Scan);
                    powers.Add(EnemyPowers.Attack);
                    powers.Add(EnemyPowers.Infect);

                    break;
                }
            case EnemyClass.virusBoss:
                {
                    powers.Add(EnemyPowers.ScanBoss);
                    powers.Add(EnemyPowers.AttackBoss);
                    powers.Add(EnemyPowers.InfectBoss);

                    break;
                }
        }
    }


    public List<EnemyPowers> GetPowers()
    {
        return powers;
    }

    public void Attack()
    {
        float powerValue = 0;
        int power = 0;

        switch (enemyClass)
        {
            case EnemyClass.virusNormal:
                {
                    power = UnityEngine.Random.Range(0, 3);
                    break;
                }
            case EnemyClass.virusBoss:
                {
                    power = UnityEngine.Random.Range(3, 6);
                    break;
                }
        }

        switch (power)
        {
            case (int)EnemyPowers.Scan:
                {
                    powerValue = UnityEngine.Random.Range(1f, 3f);
                    break;
                }
            case (int)EnemyPowers.Attack:
                {
                    powerValue = 1;
                    break;
                }
            case (int)EnemyPowers.Infect:
                {
                    powerValue = 3;
                    break;
                }
            case (int)EnemyPowers.ScanBoss:
                {
                    break;
                }
            case (int)EnemyPowers.AttackBoss:
                {
                    break;
                }
            case (int)EnemyPowers.InfectBoss:
                {
                    break;
                }
        }

        battleSystem.AttackEnd(powerValue);
    }

    public void SetDamage(float dmg)
    {
        hp -= dmg;

        Debug.Log("Enemy HP: " + hp);
    }

    public void EnemyEndBattle()
    {
        //TODO -> Reiniciar y cambiar los valores necesarios del enemigo cuando no esta en batalla. Por ej: eliminar el enemigo si hp <= 0
    }
}
