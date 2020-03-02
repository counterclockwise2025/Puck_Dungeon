using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimeScript : MonoBehaviour
{
    Rigidbody2D rgbody2D;
    public float eHealth = 10;
    public float eDamage = 5;
    public Text txtEHealth;
    public Text txtEDamage;
    public float speed = 10;
    public gameControllerScriptNew gcScript;
    public playerScript pScript;

    // Start is called before the first frame update
    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
        pScript = GameObject.Find("playerPuck").GetComponent<playerScript>();
    }

    void OnEnabled()
    {
        gameControllerScriptNew.OnClicked += doShoot;
    }

    void OnDisabled()
    {
        gameControllerScriptNew.OnClicked -= doShoot;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    private void updateUI(){
        txtEHealth.text = "" + eHealth;
        txtEDamage.text = "" + eDamage;
    }

    void doShoot()
    {
        rgbody2D.velocity = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }


    public void addDmg()
    {
        eDamage += 1;
    }

    public void addHealth()
    {
        eHealth += 1;
    }

    public void checkHealth()
    {
        if(eHealth < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gcScript.pOneTurn == true){
            if(col.gameObject.tag == "Player")
            {
                eHealth -= col.gameObject.GetComponent<playerScript>().pDamage;
                checkHealth();
            }
        }
    }
}
