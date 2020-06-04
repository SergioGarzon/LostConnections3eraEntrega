using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCreation : MonoBehaviour
{
    public GameObject virus;
    public List<GameObject> virusList;

    private void Awake()
    {
        CreateEnemyVirus();
    }

    private void CreateEnemyVirus()
    {
        foreach (GameObject vl in virusList)
        {
            Transform virusObjects = Instantiate(virus, vl.transform).transform;
            virusObjects.GetChild(0).transform.position = virusObjects.transform.position;
            virusObjects.parent = vl.transform;
            virusObjects.tag = "EnemiesGroup";
            virusObjects.name = virus.name;
        }
    }


}
