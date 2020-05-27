using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCreations : MonoBehaviour
{
    int pjSelected = 0;

    public GameObject atifPrefab;
    public GameObject charliePrefab;

    enum PlayersEnum
    {
        Atif,
        Charlie
    }

    void Awake()
    {
        CreatePlayers();
    }

    void CreatePlayers()
    {
        pjSelected = PlayerPrefs.GetInt("ObjetoElegido", 0);  //0 Atif, 1 Charlie
        Transform playersParent = GameObject.Find("ObjectsWorldScene/ObjectPlayers").transform;

        //Player 1 - PlayerController / MovementPlayerNewWorld
        GameObject prefab = pjSelected == 0 ? atifPrefab : charliePrefab;
        Transform player = Instantiate(prefab, playersParent).transform;
        player.parent = playersParent;
        player.gameObject.AddComponent<CharacterController>();
        player.gameObject.AddComponent<MovementPlayerNewWorld>().speed = 70; //Speed=70
        player.GetChild(0).transform.position = player.position - new Vector3(0, 10f, 0); //Ajustamos la posicion del hijo (GameObject modelo del pj) por la escala
        player.tag = "Player"; //Solo el Player 1 tiene el tag Player
        player.name = prefab.name;
        CharacterController charController = player.GetComponent<CharacterController>(); //Ajustamos dimensiones del collider por la escala
        charController.height = 20;
        charController.radius = 5;
        charController.slopeLimit = 80;


        //TODO -> Instanciar el player 3
    }

    //Esto despues se va a reemplazar por los ternarios que asignan el prefab. Vamos a necesitar un for que recorra los players e instancie el 2 y 3
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
