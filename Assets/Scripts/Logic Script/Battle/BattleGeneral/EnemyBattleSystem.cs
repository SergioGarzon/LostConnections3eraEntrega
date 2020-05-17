using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleSystem : MonoBehaviour
{
    public enum EnemyPowers
    {
        scan,
        attack,
        infect,
        scanBoss,
        attackBoss,
        infectBoss
    }

    public enum EnemyClass
    {
        virusNormal,
        virusBoss,
    }

    public List<EnemyPowers> powers;
    public EnemyClass playerClass;

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

        switch (playerClass)
        {
            case EnemyClass.virusNormal:
                {
                    powers.Add(EnemyPowers.scan);
                    powers.Add(EnemyPowers.attack);
                    powers.Add(EnemyPowers.infect);

                    break;
                }
            case EnemyClass.virusBoss:
                {
                    powers.Add(EnemyPowers.scanBoss);
                    powers.Add(EnemyPowers.attackBoss);
                    powers.Add(EnemyPowers.infectBoss);

                    break;
                }
        }
    }

    public void SetDamage(float dmg)
    {
        hp -= dmg;

        Debug.Log("Enemy HP: " + hp);
    }
}
