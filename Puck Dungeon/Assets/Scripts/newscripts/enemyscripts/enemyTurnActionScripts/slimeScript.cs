using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimeScript : MonoBehaviour
{
    Rigidbody2D rgbody2D;
    gameControllerScriptNew gcScript;

    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
    }

    void Update()
    {
        
    }

    void beforeTurn()
    {
        onTurn();
    }

    public void onTurn()
    {
        rgbody2D.velocity = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));

        afterTurn();
    }

    public void afterTurn()
    {
        
    }
}