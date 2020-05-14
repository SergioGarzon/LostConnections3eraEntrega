using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatorArcade : MonoBehaviour
{
    private bool validatorArcade;

    void Start()
    {
        this.validatorArcade = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.validatorArcade = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.validatorArcade = false;
        }
    }

    public bool getValidatorArcade()
    {
        return this.validatorArcade;
    }
}
