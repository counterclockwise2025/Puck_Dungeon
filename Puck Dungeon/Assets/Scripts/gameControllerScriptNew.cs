using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControllerScriptNew : MonoBehaviour
{
    public bool playerTurn;
    // public playerScript pScript;
    public GameObject[] playerPucks;
    public GameObject[] enemyPucks;
    public Text buttonTxt;
    int enemyActions;
    int actionsEnded;
    int enemyPuckIndex;
    public bool noEnemy;

    void Start()
    {
        playerTurn = true;
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");
        enemyPuckIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyPucks.Length < 1){
            noEnemy = true;
        }else{
            noEnemy = false;
        }
    }

    public void endEnemyAction()
    {
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");
        int enemyActions = enemyPucks.Length;
        actionsEnded++;
        enemyPuckIndex++;
        if(enemyPuckIndex < enemyPucks.Length){
            enemyStart();
        }
        Debug.Log(enemyPuckIndex);

        if(actionsEnded >= enemyActions){
            changeTurn();
            actionsEnded = 0;
            enemyPuckIndex = 0;
        }
    }

    public void changeTurn()
    {
        //get all the enemy and player pucks into seperate arrays
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");

        //change the turn
        playerTurn = !playerTurn;

        if(enemyPucks.Length == 0)
        {
            Debug.Log("Player Wins");
            SceneManager.LoadScene("level1");
        }

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
            enemyPuckIndex = 0;
            enemyPucks[0].SendMessage("beforeTurn", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void enemyStart()
    {
        if(actionsEnded >= enemyActions){
            enemyPucks[enemyPuckIndex].SendMessage("beforeTurn", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void newLevel()
    {
        if(noEnemy == true)
        {
            Debug.Log("nextLevel");
        }
    }
}