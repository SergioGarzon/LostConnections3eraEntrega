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

    public PanelUIBattle panelUIBattle;

    private BattleState currentState;
    private Side currentSide;

    private int characterIndexCount;

    private void Awake()
    {
        playerList = new List<PlayerBattleSystem>();

        panelUIBattle = GameObject.Find("Canvas/PnlBattleUI").GetComponent<PanelUIBattle>();

        currentState = BattleState.None;
        currentSide = Side.Players;

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

    public void AttackPlayerEnd(float dmg)
    {
        enemy.SetDamage(dmg);
        CleanAttackOptions();

        panelUIBattle.SetEnergyEnemy(enemy.GetHP());
    }

    public void AttackEnemyEnd(float dmg, PlayerBattleSystem player)
    {
        player.SetDamage(dmg);
        CleanAttackOptions();

        Debug.Log("Attack Enemy -->");
    }

    public void AttackFXEnd()
    {
        NextTurn();
    }

    public void BattleEnd()
    {
        currentState = BattleState.End;

        CleanBattleComponents();
    }

    private void NextTurn()
    {
        if (currentSide == Side.Players)
        {
            characterIndexCount++;

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
            panelUIBattle.SetTextInformation("Attack Player: " + playerList[characterCount].name);
            DisplayAttackOptions(playerList[characterCount], true);
        }
        else
        {
            panelUIBattle.SetTextInformation("Attack Enemy: " + enemy.name);
            enemy.Attack(playerList[Random.Range(0, playerList.Count)].transform);
        }

        currentState = BattleState.InProgress;
    }

    private void DisplayAttackOptions(PlayerBattleSystem player, bool display)
    {
        panelUIBattle.Unactivate();
        panelUIBattle.UnenableImage();
        panelUIBattle.gameObject.SetActive(display);

        if (player != null)
        {
            panelUIBattle.ShowAttackButtons(player, enemy.transform);
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
        //enemy.EnemyEndBattle();  //Descomentar esto nuevamente
        enemy = null;

        //TODO - Cerrar UI Battle
        CleanAttackOptions();
        DisplayAttackOptions(null, false);

        //PLAYERS
        //player[n].PlayerEndBattle();
        AllowPlayersMovement(true);

        //Aqui puse esto
        panelUIBattle.EnabledImage();

        characterIndexCount = 0;
        currentState = BattleState.None;
    }

}
