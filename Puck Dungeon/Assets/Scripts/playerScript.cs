using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{

    public bool isSelected = false;
    private bool canShoot = true;
    public bool canSelect;
    public bool isAiming = false;
    Rigidbody2D rgbody2D;
    public Text txtPHealth;
    public Text txtPDamage;
    public Text txtPSpeed;
    public float pHealth = 10;
    public float pDamage = 5;
    public float speed = 10;
    public float maxSpeed = 15;
    public gameControllerScriptNew gcScript;
    // public slimeScript eScript;
    SpriteRenderer spriteRen;
    public GameObject actionUI;
    public GameObject[] playerObjs;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        rgbody2D = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
        // eScript = GameObject.Find("slime").GetComponent<slimeScript>();
        actionUI = GameObject.Find("actionUIHolder");
        actionUI.SetActive(false);
        playerObjs = GameObject.FindGameObjectsWithTag("Player");
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
        if(canSelect == false && gcScript.pOneTurn == true){
            spriteRen.color = Color.grey;
        }else if(canSelect == true || gcScript.pOneTurn == false){
            spriteRen.color = Color.white;
        }
    }

    private void OnMouseDown(){
        if(canSelect == true){
            if(gcScript.pOneTurn == true){
                isSelected = true;
            }
        }
    }

    private void aim()
    {
        if(canSelect == true){
            if(gcScript.pOneTurn == true){
                if(isSelected == true)
                {
                    if(isAiming == true){
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
                        if(Input.mouseScrollDelta.y > 0 && speed < maxSpeed){
                            speed += 1;
                        }
                        if(Input.mouseScrollDelta.y < 0 && speed > 0)
                        {
                            speed -= 1;
                        }
                        if(Input.GetMouseButtonDown(1)){
                            isSelected = false;
                            canShoot = false;
                            isAiming = false;
                        }
                    }
                    if(Input.GetMouseButtonDown(1)){
                            isSelected = false;
                            canShoot = false;
                            isAiming = false;
                    }
                }
                // if(fireArrow == true)
                // {
                //     if(Input.GetMouseButtonDown(0)){
                //         isSelected = false;
                //         canShoot = false;
                //         isAiming = false;
                //     }
                // }
                else
                {
                    canShoot = false;
                }
            }
        }
        
    }

    public void doAim(){
        isAiming = true;
    }


    private void updateUI(){
        txtPHealth.text = "" + pHealth;
        txtPDamage.text = "" + pDamage;
        txtPSpeed.text = "" + speed;
        if(isSelected == true && isAiming == false)
        {
            actionUI.SetActive(true);
        }
        if(isSelected == false || isAiming == true)
        {
            actionUI.SetActive(false);
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
        // actionUI.SetActive(false);
        isAiming = false;
    }

    public void addDmg()
    {
        pDamage += 1;
    }

    public void addHealth()
    {
        pHealth += 1;
    }

    public void checkHealth()
    {
        if(pHealth < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gcScript.pOneTurn == false){
            if(col.gameObject.tag == "enemy")
                {
                    pHealth -= col.gameObject.GetComponent<damageScript>().damage;
                    checkHealth();
                }
        }
    }
}
