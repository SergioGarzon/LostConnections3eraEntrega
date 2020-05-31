using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ParticlesAttack : MonoBehaviour
{

    public List<ParticleSystem> attackPlayersParticles;
    public List<ParticleSystem> attackEnemiesParticles;
    public ParticleSystem currentSystem;
    public PlayerBattleSystem player;
    public EnemyBattleSystem enemy;

    void Awake()
    {
        attackPlayersParticles = Resources.LoadAll<ParticleSystem>("Prefabs/AttackFX/Players").ToList<ParticleSystem>();
        attackEnemiesParticles = Resources.LoadAll<ParticleSystem>("Prefabs/AttackFX/Enemies").ToList<ParticleSystem>();

        currentSystem = null;
    }

    public void AttackPlayerPower(PlayerBattleSystem.PlayerPowers power, PlayerBattleSystem character, Transform targetPosition)
    {
        Debug.Log("Attack Player Power: " + power);

        for (int i = 0; i < attackPlayersParticles.Count; i++)
        {
            if (attackPlayersParticles[i].name == power.ToString())
            {
                player = character;
                CreateFX(attackPlayersParticles[i].gameObject, character.transform, targetPosition);

                break;
            }
        }
    }
    public void AttackEnemyPower(EnemyBattleSystem.EnemyPowers power, EnemyBattleSystem character, Transform targetPosition)
    {
        Debug.Log("Attack Enemy Power: " + power);

        for (int i = 0; i < attackEnemiesParticles.Count; i++)
        {
            if (attackEnemiesParticles[i].name == power.ToString())
            {
                enemy = character;

                CreateFX(attackEnemiesParticles[i].gameObject, character.transform, targetPosition);

                break;
            }
        }
    }

    private void CreateFX(GameObject prefab, Transform characterPosition, Transform targetPosition)
    {
        if (prefab != null)
        {
            if(prefab.name.Equals("Shock"))
                prefab.transform.localScale = new Vector3(30,30,30); //Aqui le incremente el tamaño a la particula

            if (currentSystem == null)
            {
                //El indice del power respeta el nombre de los enums, los prefabs en la carpeta AttackFX tienen que tener el mismo nombre.
                currentSystem = Instantiate(prefab, characterPosition).GetComponent<ParticleSystem>();
                currentSystem.transform.LookAt(targetPosition);
                currentSystem.Play();

                StartCoroutine(SystemCheck());
            }
            else
            {
                Debug.LogError("currentSystem no es null, otro sistema de particulas esta instanciado");
            }
        }
        else
        {
            Debug.LogError("No se encontro el prefab de particulas en AttackPower()");
        }
    }

    IEnumerator SystemCheck()
    {
        if (currentSystem != null && currentSystem.isStopped)
        {
            Debug.Log("Particle update - DESTROY");

            Destroy(currentSystem.gameObject);
            currentSystem = null;

            if (player != null)
            {
                player.AttackEnd();
                player = null;
            }
            else if (enemy != null)
            {
                enemy.AttackEnd();
                enemy = null;
            }

            StopCoroutine(SystemCheck());
        }
        else
        {
            StopCoroutine(SystemCheck());
            yield return new WaitForSeconds(.1f);
            StartCoroutine(SystemCheck());
        }
    }



}
