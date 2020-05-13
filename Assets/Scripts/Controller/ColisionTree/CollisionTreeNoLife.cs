using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTreeNoLife : MonoBehaviour
{
    private bool colisionActivate;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.colisionActivate = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        this.colisionActivate = false;
    }

    public bool getReturnCollision()
    {
        return this.colisionActivate;
    }



}
