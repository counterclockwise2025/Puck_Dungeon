using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating an abstract spell class inorder to make the spells modular that way we can add more spells easily in the future
public abstract class spellsAbstract : MonoBehaviour
{
    //initialize varibles for the the definition of a spell
    public class Spell
    {
        int spellShoot;
        int spellCount;

        //create a constructor for the the object/attributes of the class 
        public Spell(int shoot, int count)
        {
            spellShoot = shoot;
            spellCount = count;
        }
    }

    //initialize variables and create a new spell object
    public Spell playerSpell = new Spell(5,5);
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
