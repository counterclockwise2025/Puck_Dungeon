using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour
{

    private bool isSelected = false;
    private bool canShoot = false;
    public bool canSelect = true;
    Rigidbody2D rgbody2D;
    public float eHealth = 10;
    public float eDamage = 5;
    public Text txtEHealth;
    public Text txtEDamage;
    public float speed = 10;
    public gameControllerScriptNew gcScript;
    public playerScript pScript;
    SpriteRenderer spriteRen;


    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        rgbody2D = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
    }

    // Update is called once per frame
    void Update()
    {
        aim();
        updateUI();
        updateSprite();
    }

    private void updateSprite()
    {
        if(canSelect == false && gcScript.pOneTurn == false){
            spriteRen.color = Color.grey;
        }else if(canSelect == true || gcScript.pOneTurn == true){
            spriteRen.color = Color.white;
        }
    }

    private void OnMouseDown(){
        if(gcScript.pOneTurn == false){
            isSelected = true;
        }
    }

    private void updateUI(){
        txtEHealth.text = "" + eHealth;
        txtEDamage.text = "" + eDamage;
    }

    private void aim()
    {
        if(canSelect == true){
            if(gcScript.pOneTurn == false){
            if(isSelected == true)
            {
                //rotation
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 5.23f;

                Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                checkShoot();
                canShoot = true;

                if(Input.GetMouseButtonDown(1)){
                    isSelected = false;
                    canShoot = false;
                }
            }else
            {
                canShoot = false;
            }
        }
        }
    }

    private void checkShoot()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true){
            doShoot();
            canShoot = false;
        }
    }


    private void doShoot()
    {
        rgbody2D.velocity = transform.right * speed;
        isSelected = false;
        canSelect = false;
        StartCoroutine(newTurn());
    }

    IEnumerator newTurn()
    {

        yield return new WaitForSeconds(4);
        // gcScript.changeTurn();
        isSelected = false;
    }

    public void addDmg()
    {
        eDamage += 1;
    }

    public void addHealth()
    {
        eHealth += 1;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gcScript.pOneTurn == true){
            if(col.gameObject.tag == "Player")
                {
                    eHealth -= pScript.pDamage;
                }
        }
    }
}
