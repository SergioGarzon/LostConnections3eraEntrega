﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public void CloseCards()
    {
        this.gameObject.SetActive(false);
    }
}
