using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameControllerScriptNew : MonoBehaviour
{
    public bool playerTurn;
    // public playerScript pScript;
    public GameObject[] playerPucks;
    public GameObject[] enemyPucks;
    public Text buttonTxt;

    void Start()
    {
        playerTurn = true;
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeTurn()
    {
        //get all the enemy and player pucks into seperate arrays
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");

        //change the turn
        playerTurn = !playerTurn;

        //if it is the players turn
        if(playerTurn == true)
        {
            //change the button to say end turn
            buttonTxt.text = "End Turn";

            //for every player puck in the player puck array
            foreach(GameObject playerPuck in playerPucks)
            {
                //if they are active
                if(playerPuck.activeSelf != false)
                {
                    //set their can select to true
                    playerPuck.GetComponent<playerScript>().canSelect = true;
                }
            }
        }
        if(playerTurn == false)
        {
            buttonTxt.text = "Start Turn";
            foreach(GameObject playerPuck in playerPucks)
            {
                if(playerPuck.activeSelf != false)
                {
                    playerPuck.GetComponent<playerScript>().canSelect = false;
                }
            }
            foreach(GameObject enemyPuck in enemyPucks)
            {
                if(enemyPuck.activeSelf != false)
                {
                    enemyPuck.SendMessage("beforeTurn", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}