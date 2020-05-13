using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerTwo : MonoBehaviour
{
    public Transform jugador;
    private NavMeshAgent enemigo;
    private bool dentro;

    void Awake()
    {
        this.dentro = false;
    }

    private void Start()
    {
        this.enemigo = this.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.dentro = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
       if(other.tag == "Player")
        {
            this.dentro = false;
        }
    }

    void Update()
    {
        if(!dentro)
        {
            this.enemigo.destination = jugador.position;
        }   
        if(dentro)
        {
            this.enemigo.destination = this.transform.position;
        }
    }

}
