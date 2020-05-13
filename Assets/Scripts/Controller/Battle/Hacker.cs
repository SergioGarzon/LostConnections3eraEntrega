using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Hacker : MonoBehaviour
{
    private States _states = new States();

    public ScoreData scoreData;

    public int copyLimit = 3;

    public int _damage;

    public static Hacker Instance;


    private void Awake()
    {
        Instance = this;
    }


}
