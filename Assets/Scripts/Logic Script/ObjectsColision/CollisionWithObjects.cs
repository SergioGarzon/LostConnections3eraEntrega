using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithObjects : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Tree": break;
            case "NoTree": break;
            case "Arcade": break;
            case "CollisionShop": break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "": break;
        }
    }

}
