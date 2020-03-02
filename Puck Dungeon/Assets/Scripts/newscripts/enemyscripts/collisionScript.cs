using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    public gameControllerScriptNew gcScript;
    public healthScript hScript;
    Rigidbody2D rgbody2D;


    // Start is called before the first frame update
    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
        hScript = GetComponent<healthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gcScript.pOneTurn == true){
            if(col.gameObject.tag == "Player")
                {
                    hScript.health -= col.gameObject.GetComponent<playerScript>().pDamage;
                    hScript.checkHealth();
                }
        }
    }
}
