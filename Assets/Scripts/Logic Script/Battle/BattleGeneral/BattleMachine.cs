using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public string nameScene;

    private BattleState currentState;
    private Side currentSide;

    private int characterIndexCount;
    private bool buttonScape;


    private void Awake()
    {
        playerList = new List<PlayerBattleSystem>();

        panelUIBattle = GameObject.Find("Canvas/PnlBattleUI").GetComponent<PanelUIBattle>();

        currentState = BattleState.None;
        currentSide = Side.Players;

        characterIndexCount = 0;

        buttonScape = false;
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

            if (panelUIBattle != null)
                panelUIBattle.SetEnergyEnemy(enemy.GetHP());

            currentSide = Side.Players;

            if (panelUIBattle != null)
                panelUIBattle.SetScapeButton(this);

            Attack(characterIndexCount);
        }
        /*
        else
        {
            //Despues quitar esto asi puedo poner bien todo
            //Debug.LogWarning("BattleState != None --> " + currentState);
        }*/
    }

    public void AttackPlayerEnd(float dmg)
    {
        enemy.SetDamage(dmg);
        CleanAttackOptions();

        if (panelUIBattle != null)
            panelUIBattle.SetEnergyEnemy(enemy.GetHP());
    }

    public void AttackEnemyEnd(float dmg, PlayerBattleSystem player)
    {
        player.SetDamage(dmg);
        CleanAttackOptions();

        //Debug.Log("Attack Enemy -->");
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
        if (IsEnemyDead() == true)
        {
            //TODO - Agregar panel rewards
            BattleEnd();
            return;
        }
        else if (IsPlayerDead() == true)
        {
            //TODO - Agregar panel perdiste y sacar la llamada al metodo
            BattleEnd();
            return;
        }

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
        if (currentState != BattleState.None)
        {
            if (currentSide == Side.Players)
            {
                if (panelUIBattle != null)
                    panelUIBattle.SetTextInformation("Attack Player: " + playerList[characterCount].name);
                DisplayAttackOptions(playerList[characterCount], true);
            }
            else
            {
                if (panelUIBattle != null)
                    panelUIBattle.SetTextInformation("Attack Enemy: " + enemy.name);
                enemy.Attack(playerList[Random.Range(0, playerList.Count)].transform);
            }

            currentState = BattleState.InProgress;
        }
    }

    private void DisplayAttackOptions(PlayerBattleSystem player, bool display)
    {
        if (panelUIBattle != null)
        {
            panelUIBattle.Unactivate();
            panelUIBattle.UnenableImage();
            panelUIBattle.gameObject.SetActive(display);
        }

        if (panelUIBattle != null)
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
        if (panelUIBattle != null)
            panelUIBattle.CleanAttackButtons();
    }

    private void CleanBattleComponents()
    {
        //ENEMIES
        if (enemy != null)
        {
            enemy.EnemyEndBattle();
            enemy = null;
        }


        //TODO - Cerrar UI Battle
        CleanAttackOptions();
        DisplayAttackOptions(null, false);

        //PLAYERS
        //player[n].PlayerEndBattle();
        if (nameScene.Equals("SampleScene"))
            AllowPlayersMovement(true);

        //Aqui puse esto
        if (panelUIBattle != null)
            panelUIBattle.EnabledImage();

        characterIndexCount = 0;
        currentState = BattleState.None;

        if (nameScene.Equals("BattleScene") && enemy == null && buttonScape)
        {
            buttonScape = false;
            SavePosition.cargarPosicionInicial = 2;           
            SceneManager.LoadScene("SampleScene");
        }
    }

    private bool IsEnemyDead()
    {
        return (enemy == null) || (enemy.GetHP() <= 0);
    }

    private bool IsPlayerDead()
    {
        bool dead = false;

        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].GetHP() > 0)
            {
                dead = false;
                break;
            }

            dead = true;
        }

        return dead;
    }

    public void SetManaPanelBattleUI(float manaBattle)
    {
        if (panelUIBattle != null)
            panelUIBattle.SetSliderMana(manaBattle);
    }

    public void SetEnergyEnemy(float energyEnemy)
    {
        if (panelUIBattle != null)
            panelUIBattle.SetEnergyEnemy(energyEnemy);
    }

    public void SetEnergyPlayer(float energyPlayer)
    {
        if (panelUIBattle != null)
            panelUIBattle.SetSliderEnergyGeneral(energyPlayer);
    }

    public void SetButtonScape()
    {
        buttonScape = true;
    }

}
