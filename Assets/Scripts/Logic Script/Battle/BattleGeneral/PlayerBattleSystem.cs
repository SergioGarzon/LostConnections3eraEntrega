using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleSystem : MonoBehaviour
{

    public enum PlayerPowers //Los Prefabs en la carpeta de resources AttackFX tienen que estar en el mismo orden que estos enums
    {
        Bug,
        Steal,
        Pixel,
        Shock,
        Lighting,
        Electricity,
        ControlZ, //Poder exclusivo de charlie, recupera la vida robada por el enemigo
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

    public BattleMachine battleSystem;
    public ParticlesAttack particleSystem;

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

        switch (power)
        {
            case PlayerPowers.Bug:
                {
                    powerValue = UnityEngine.Random.Range(1f, 3f);

                    break;
                }
            case PlayerPowers.Steal:
                {
                    powerValue = 1;
                    break;
                }
            case PlayerPowers.Pixel:
                {
                    powerValue = 3;
                    break;
                }
            case PlayerPowers.Shock:
                {
                    powerValue = 4;
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

        particleSystem.AttackPlayerPower(power, this, enemy);
        battleSystem.AttackPlayerEnd(powerValue);
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

    public void AddNewPower(PlayerPowers power)
    {
        powers.Add(power);
    }

    public void ReplacePower(PlayerPowers power)
    {
        //Método para reemplazar valor en la lista
    }

}
