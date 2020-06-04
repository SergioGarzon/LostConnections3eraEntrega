using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayersCreations : MonoBehaviour
{

    int pjSelected = 0;

    public List<GameObject> characterPrefabsList;

    enum PlayersEnum
    {
        Atif,
        Charlie,
        Dante
    }

    void Awake()
    {
        CreatePlayers();
    }

    void CreatePlayers()
    {
        pjSelected = PlayerPrefs.GetInt("ObjetoElegido", 0);  //0 Atif, 1 Charlie, 2 Dante
        Transform playersParent = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform;

        //Player 1 - PlayerController / MovementPlayerNewWorld
        GameObject userPlayer = GetPlayerPrefab((PlayersEnum)pjSelected);
        CreateUserPlayer(userPlayer, playersParent);

        //Player 2,3,n - NavMeshAgent / FollowPlayerTwo
              /*for(int i = 0; i<characterPrefabsList.Count; i++)
                {
                    GameObject playerSupport = GetPlayerPrefab((PlayersEnum)1);

                    if (playerSupport != userPlayer)
                    {
                        CreateNonControllerPlayer(playerSupport, playersParent);
                    }
                }*/
               

        //TPDO - ELIMINAR ESTE FOR Y DEJAR AL DE ARRIBA CUANDO ESTEN LISTOS LOS PREFABS DE LOS PLAYERS
        /*
        for (int i = 1; i < characterPrefabsList.Count; i++)
        {
            GameObject playerSupport = GetPlayerPrefab((PlayersEnum)1);
            CreateNonControllerPlayer(playerSupport, playersParent);
        }*/
    }

    private GameObject GetPlayerPrefab(PlayersEnum playerNumber)
    {
        return characterPrefabsList[(int)playerNumber];
    }

    private void CreateUserPlayer(GameObject prefab, Transform playersParent)
    {
        Transform player = Instantiate(prefab, playersParent).transform;
        player.parent = playersParent;
        player.gameObject.AddComponent<CharacterController>();
        player.gameObject.AddComponent<MovementPlayerNewWorld>().speed = 70; //Speed=70
        player.GetChild(0).transform.position = player.position - new Vector3(0,4f, 0); //Ajustamos la posicion del hijo (GameObject modelo del pj) por la escala
        player.tag = "Player"; //Solo el Player 1 tiene el tag Player
        player.name = prefab.name;
        CharacterController charController = player.GetComponent<CharacterController>(); //Ajustamos dimensiones del collider por la escala
        charController.height = 20;
        charController.radius = 5;
        charController.slopeLimit = 80;
    }

    private void CreateNonControllerPlayer(GameObject prefab, Transform playersParent)
    {
        Transform player = Instantiate(prefab, playersParent).transform;
        player.parent = playersParent;
        player.name = prefab.name;        
         NavMeshAgent agent = player.gameObject.AddComponent<NavMeshAgent>();
        FollowPlayerTwo followP = player.gameObject.AddComponent<FollowPlayerTwo>();
        followP.jugador = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform.GetChild(0);
        agent.baseOffset = 1;
        agent.speed = 70;
        agent.angularSpeed = 360;
        agent.acceleration = 50;
        agent.stoppingDistance = 40;
        agent.radius = 100;
        agent.height = 2;
    }
}
