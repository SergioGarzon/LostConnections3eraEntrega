using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCreations : MonoBehaviour
{
    int pjSelected = 0;

    public GameObject atifPrefab;
    public GameObject charliePrefab;
    public GameObject biowarePrefab;

    enum PlayersEnum
    {
        Atif,
        Charlie,
        BioWare
    }

    void Awake()
    {
        CreatePlayers();
    }

    void CreatePlayers()
    {
        pjSelected = PlayerPrefs.GetInt("ObjetoElegido", 0);  //0 Atif, 1 Charlie

        Transform playersParent = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform;

        Transform player = Instantiate(SelectPlayer(pjSelected), playersParent).transform;
        player.parent = playersParent;
        //Player 1 - PlayerController / MovementPlayerNewWorld
        player.gameObject.AddComponent<CharacterController>();
        player.gameObject.AddComponent<MovementPlayerNewWorld>().speed = 70; //Speed=70
        player.GetChild(0).transform.position = player.position - new Vector3(0, 10f, 0); //Ajustamos la posicion del hijo (GameObject modelo del pj) por la escala
        player.tag = "Player"; //Solo el Player 1 tiene el tag Player
        CharacterController charController = player.GetComponent<CharacterController>(); //Ajustamos dimensiones del collider por la escala
        charController.height = 20;
        charController.radius = 5;

        //TODO -> Instanciar el player 2
        // - Crear Prefab Player2 y Player3
        //Player 2,3,n - NavMesh / FollowPlayerTwo

        //Transform player2 = Instantiate(SelectPlayer(pjSelected), playersParent).transform;
        //player2.parent = playersParent;
        //player2.gameObject.AddComponent<NavMeshAgent>();
        //player2.gameObject.AddComponent<FollowPlayerTwo>();
    }

    GameObject SelectPlayer(int player)
    {
        GameObject playerPrefab = null;

        switch (player)
        {
            case (int)PlayersEnum.Atif:
                {
                    playerPrefab = atifPrefab;
                    break;
                }
            case (int)PlayersEnum.Charlie:
                {
                    playerPrefab = charliePrefab;
                    break;
                }
        }

        return playerPrefab;
    }
}
