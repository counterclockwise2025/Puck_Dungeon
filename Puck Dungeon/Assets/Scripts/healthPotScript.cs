using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotScript : MonoBehaviour
{

    public playerScript pOne;
    public slimeScript enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter2D(Collider2D col)
    // {
        
    // }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            col.gameObject.GetComponent<playerScript>().addHealth();
        }
        if(col.gameObject.tag == "enemy"){
            Destroy(this.gameObject);
            // col.gameObject.GetComponent<slimeScript>().addHealth();
        }
    }
}
