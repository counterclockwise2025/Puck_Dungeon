using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimeScript : MonoBehaviour
{
    Rigidbody2D rgbody2D;
    gameControllerScriptNew gcScript;
    public bool doingTurn;
    public float awayTime;

    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
    }

    void Update()
    {
        if(gcScript.playerTurn != true){
            if(rgbody2D.velocity.x < Mathf.Abs(.1f) && rgbody2D.velocity.y < Mathf.Abs(.1f)){
                awayTime -= Time.deltaTime;
            }
            Debug.Log(awayTime);
            if(awayTime < 0){
                gcScript.endEnemyAction();
            }
        }
    }

    void beforeTurn()
    {
        awayTime = 1f;
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