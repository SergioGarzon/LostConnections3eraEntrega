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
    public ParticlesAttack particleSystem;

    public float hp;

    void Start()
    {
        battleSystem = GameObject.Find("GameManager").GetComponent<BattleMachine>();
        particleSystem = battleSystem.GetComponent<ParticlesAttack>();

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

    public void Attack(Transform player)
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

        particleSystem.AttackEnemyPower((EnemyPowers)power, this, player);
        battleSystem.AttackEnemyEnd(powerValue, player.GetComponent<PlayerBattleSystem>());
    }

    public void AttackEnd()
    {
        battleSystem.AttackFXEnd();
    }

    public void SetDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            EnemyEndBattle();
        }

        Debug.Log("Enemy HP: " + hp);
    }

    public float GetHP()  //Este metodo devuelve la vida del enemigo
    {
        return hp;
    }

    public void EnemyEndBattle()
    {
        //Acá hacemos el IF para comprobar que HP <= 0 para destruir el objeto virus
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            //TODO -> Reiniciar y cambiar los valores necesarios del enemigo cuando no esta en batalla. Esto es si el player abandona la batalla
        }
    }

}
