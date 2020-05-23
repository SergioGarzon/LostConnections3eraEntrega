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

    public GameObject btnMenu;
    public GameObject panelTarjetas;

    public PanelUIBattle panelUIBattle;

    private BattleState currentState;
    private Side currentSide;

    private int characterIndexCount;

    private void Awake()
    {
        playerList = new List<PlayerBattleSystem>();

        btnMenu = GameObject.Find("InventoryCanvas/OpenMenu");
        panelTarjetas = GameObject.Find("Canvas/PnlAccesoTarjeta");

        panelUIBattle = GameObject.Find("Canvas/PnlBattleUI").GetComponent<PanelUIBattle>();

        currentState = BattleState.None;
        currentSide = Side.Players;

        panelTarjetas.gameObject.SetActive(false);

        characterIndexCount = 0;

        //DEBUG - ONLY Test
        //Attack(0);
    }

    private void Start()
    {
        playerList = GameObject.Find("ObjectsWorldScene/ObjectPlayers").GetComponentsInChildren<PlayerBattleSystem>().ToList<PlayerBattleSystem>();
    }

    public void StartBattle(EnemyBattleSystem _enemy)
    {
        if (currentState == BattleState.None)
        {
            currentState = BattleState.Start;

            AllowPlayersMovement(false);

            enemy = _enemy;

            currentSide = Side.Players;

            panelUIBattle.SetScapeButton(this);

            Attack(characterIndexCount);
        }
        else
        {
            Debug.LogWarning("BattleState != None --> " + currentState);
        }
    }

    public void AttackEnd(float dmg)
    {
        enemy.SetDamage(dmg);

        NextTurn();
    }

    public void AttackEnemyEnd(float dmg)
    {
        playerList[Random.Range(0, playerList.Count)].SetDamage(dmg);

        NextTurn();
    }

    public void BattleEnd()
    {
        currentState = BattleState.End;

        CleanBattleComponents();
    }

    private void NextTurn()
    {
        characterIndexCount++;

        if (currentSide == Side.Players)
        {
            if (characterIndexCount >= playerList.Count)
            {
                currentSide = Side.Enemies;

                characterIndexCount = 0;
            }
        }
        else
        {
            currentSide = Side.Players;
        }

        Attack(characterIndexCount);
    }

    private void Attack(int characterCount)
    {
        if (currentSide == Side.Players)
        {
            DisplayAttackOptions(playerList[characterCount], true);
        }
        else
        {
            enemy.Attack();
        }

        currentState = BattleState.InProgress;
    }

    private void DisplayAttackOptions(PlayerBattleSystem player, bool display)
    {
        btnMenu.SetActive(!display);
        panelUIBattle.gameObject.SetActive(display);

        if (player != null)
        {
            panelUIBattle.ShowAttackButtons(player);
        }
    }

    private void AllowPlayersMovement(bool canMove)
    {
        //Freeze Players movement
        MovementPlayerNewWorld player1Movement = playerList[0].GetComponent<MovementPlayerNewWorld>();
        player1Movement.SetMovementPlayer(canMove);

        if (playerList.Count > 1)
        {
            for (int i = 1; i < playerList.Count; i++)
            {
                FollowPlayerTwo playerSecondaryMovement = playerList[i].GetComponent<FollowPlayerTwo>();
                playerSecondaryMovement.SetCanFollow(canMove);
            }
        }
    }

    private void CleanAttackOptions()
    {
        panelUIBattle.CleanAttackButtons();
    }

    private void CleanBattleComponents()
    {
        //ENEMIES
        //enemy.EnemyEndBattle();
        enemy = null;

        //TODO - Cerrar UI Battle
        CleanAttackOptions();
        DisplayAttackOptions(null, false);

        //PLAYERS
        //player[n].PlayerEndBattle();

        AllowPlayersMovement(true);

        characterIndexCount = 0;
        currentState = BattleState.None;
    }
}
