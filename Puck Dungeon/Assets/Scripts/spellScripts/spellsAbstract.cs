using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating an abstract spell class inorder to make the spells modular that way we can add more spells easily in the future
public abstract class spellsAbstract : MonoBehaviour
{
    //initialize varibles for the the definition of a spell
    public class Spell
    {
        GameObject Arrow;
        //create a constructor for the the object/attributes of the class 
        public Spell(GameObject arrow, int[] stat)
        {
            Arrow = arrow;
        }
    }

    public GameObject arrowPuckPrefab;
    playerScript pScript;
    gameControllerScriptNew gcScript;

    public void statEffect()
    {
        //apply different effects pretaining to the the character type and class
    }

    public void appStatEff()
    {
        //define how status effect is going to be applied
    }

    public void remStatEff()
    {
        //define how status effect is going to be removed
    }
}
