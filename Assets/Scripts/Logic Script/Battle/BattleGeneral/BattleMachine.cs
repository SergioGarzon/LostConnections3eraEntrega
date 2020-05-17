using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleMachine : MonoBehaviour
{
    enum BattleState
    {
        Start,
        InProgress,
        End,
        None
    }

    enum Side
    {
        Players,
        Enemies
    }

    public List<PlayerBattleSystem> playerList;
    public EnemyBattleSystem enemy;

    public GameObject panelUICards;
    public GameObject btnMenu;
    public GameObject panelTarjetas;

    public ActivateButtons panelUIBattle;

    private BattleState currentState;
    private Side side;

    private void Awake()
    {
        playerList = new List<PlayerBattleSystem>();
        playerList = GameObject.Find("ObjectsWorldScene/ObjectPlayers").GetComponentsInChildren<PlayerBattleSystem>().ToList<PlayerBattleSystem>();

        panelUICards = GameObject.Find("Canvas/PnlTarjetaGB");
        btnMenu = GameObject.Find("InventoryCanvas/OpenMenu");
        panelTarjetas = GameObject.Find("Canvas/PnlAccesoTarjeta");


        panelUIBattle = GameObject.Find("Canvas/PnlBattleUI").GetComponent<ActivateButtons>();

        currentState = BattleState.None;

        panelTarjetas.gameObject.SetActive(false);

        //DEBUG - ONLY Test
        //Attack(0);
    }


    public void StartBattle(EnemyBattleSystem _enemy)
    {
        if (currentState == BattleState.None)
        {
            currentState = BattleState.Start;

            AllowPlayersMovement(false);

            enemy = _enemy;

            side = Side.Players;

            Attack(0);
        }
        else
        {
            Debug.LogWarning("BattleState != None --> " + currentState);
        }
    }

    public void AttackEnd(float dmg)
    {
        enemy.SetDamage(dmg);
    }

    public void BattleEnd()
    {
        AllowPlayersMovement(true);

        currentState = BattleState.End;

        CleanBattleComponents();
    }

    private void Attack(int playerCount)
    {
        if (side == Side.Players)
        {
            ShowAttackOptions(playerList[playerCount]);
        }

        currentState = BattleState.InProgress;
    }

    private void ShowAttackOptions(PlayerBattleSystem player)
    {
        panelTarjetas.gameObject.SetActive(false);
        btnMenu.gameObject.SetActive(false);
        panelUICards.gameObject.SetActive(false);        
        panelUIBattle.gameObject.SetActive(true);
        panelUIBattle.ShowAttackButtons(player);
    }

    private void AllowPlayersMovement(bool canMove)
    {
        //Freeze Players movement
        MovementPlayerNewWorld player1Movement = playerList[0].GetComponent<MovementPlayerNewWorld>();
        player1Movement.SetMovementPlayer(canMove);

        FollowPlayerTwo player2Movement = playerList[1].GetComponent<FollowPlayerTwo>();
        player2Movement.SetCanFollow(canMove);
    }

  

    private void CleanBattleComponents()
    {

        //ENEMIES
        //TODO - Llamar a Reset en el enemy cuando se termina la batalla = Si el enemigo murio eliminarlo, si no resetear las stats (vida, etc)
        //enemy.Reset();
        enemy = null;

        //TODO - Cerrar UI Battle

        //PLAYERS
        // -

        currentState = BattleState.None;
    }
}
