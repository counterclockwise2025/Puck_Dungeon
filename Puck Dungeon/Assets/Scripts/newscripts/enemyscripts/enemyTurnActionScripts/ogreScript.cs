using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ogreScript : MonoBehaviour
{
    Rigidbody2D rgbody2D;
    Transform spawnNode;
    gameControllerScriptNew gcScript;
    public bool doingTurn;
    public float awayTime;
    healthScript hScript;

    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        spawnNode = this.gameObject.transform.Find("spawnNode").gameObject.GetComponent<Transform>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
        awayTime = 1f;
        hScript = this.gameObject.GetComponent<healthScript>();
    }

    void Update()
    {
        if(gcScript.playerTurn != true){
            if(rgbody2D.velocity.x < Mathf.Abs(.1f) && rgbody2D.velocity.y < Mathf.Abs(.1f)){
                awayTime -= Time.deltaTime;
            }
            if(awayTime < 0){
                gcScript.endEnemyAction();
            }
        }
        if(hScript.health < 1)
        {
            doDeath();
        }
    }

    void beforeTurn()
    {
        awayTime = 1f;
        onTurn();
    }

    public void onTurn()
    {
        //raycasting and AI
        float randNum = Random.Range(0.0f,1.0f);
        if(randNum > .5){
            //currently giving a random x,y
            //need to change to look for player rigidbody and send in that direction
            rgbody2D.velocity = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        }
        else{
            Object newSlime = Instantiate(Resources.Load("slime"), spawnNode.position, spawnNode.rotation);
            newSlime.name = "slime";
        }
    }

    public void afterTurn()
    {
            
    }

    public void doDeath(){
        Debug.Log("death");
    }
}