using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating an abstract spell class inorder to make the spells modular that way we can add more spells easily in the future
public abstract class spellsAbstract : MonoBehaviour
{
    public GameObject aimArrow;
    public GameObject arrowPuckPrefab;
    playerScript pScript;
    gameControllerScriptNew gcScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
