using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpText : MonoBehaviour
{
    private Text _xpText;
    [SerializeField] private ScoreData scoreData;
    // Start is called before the first frame update
    void Start()
    {
        _xpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _xpText.text="XP: "+ scoreData.xp;
    }
}
