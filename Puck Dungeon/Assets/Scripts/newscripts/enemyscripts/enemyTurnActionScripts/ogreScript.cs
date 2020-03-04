using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ogreScript : MonoBehaviour
{
    Rigidbody2D rgbody2D;
    Transform spawnNode;
    gameControllerScriptNew gcScript;

    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        spawnNode = this.gameObject.transform.Find("spawnNode").gameObject.GetComponent<Transform>();
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
        if(this.gameObject.activeSelf == true){
            Object newSlime = Instantiate(Resources.Load("slime"), spawnNode.position, spawnNode.rotation);
            newSlime.name = "slime";
        }   
    }
}