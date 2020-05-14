using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusColisionPlayer : MonoBehaviour
{
    private bool colisionWithPlayer;
    private bool lostGame;
    public ScoreData score;
    public Camera player;
    private CameraPlayer camPlayerScript;
    public GameObject objetoPlayer;
    private MovementPlayerNewWorld playerMove;



    void Start()
    {
        this.camPlayerScript = this.player.GetComponent<CameraPlayer>();
        this.playerMove = this.objetoPlayer.GetComponent<MovementPlayerNewWorld>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.score.hLife <= 0 && this.score.mLife <= 0)
            {
                this.lostGame = true;
            }
            else
            {
                this.colisionWithPlayer = true;
                this.camPlayerScript.setCameraMovement(false);
                this.playerMove.setMovementPlayer(false);
            }

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.colisionWithPlayer = false;
        }
    }

    public bool getReturnColisionGame()
    {
        return this.colisionWithPlayer;
    }

    public bool getLostGame()
    {
        return this.lostGame;
    }

}
