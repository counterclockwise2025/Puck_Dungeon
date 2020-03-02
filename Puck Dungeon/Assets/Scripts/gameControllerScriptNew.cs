using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameControllerScriptNew : MonoBehaviour
{
    public bool pOneTurn;
    // public playerScript pScript;
    public GameObject[] playerPucks;
    public GameObject[] enemyPucks;
    public Text buttonTxt;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    void Start()
    {
        pOneTurn = true;
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeTurn()
    {
        playerPucks = GameObject.FindGameObjectsWithTag("Player");
        enemyPucks = GameObject.FindGameObjectsWithTag("enemy");
        pOneTurn = !pOneTurn;
        if(pOneTurn == true)
        {
            buttonTxt.text = "End Turn";
            foreach(GameObject playerPuck in playerPucks)
            {
                if(playerPuck.activeSelf != false)
                {
                    playerPuck.GetComponent<playerScript>().canSelect = true;
                }
            }
        }
        if(pOneTurn == false)
        {
            buttonTxt.text = "Start Turn";
            foreach(GameObject playerPuck in playerPucks)
            {
                if(playerPuck.activeSelf != false)
                {
                    playerPuck.GetComponent<playerScript>().canSelect = false;
                }
            }
            OnClicked();
        }
    }
}