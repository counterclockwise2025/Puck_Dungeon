using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgPotScript : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            col.gameObject.GetComponent<playerScript>().addDmg();
        }
        if(col.gameObject.tag == "enemy"){
            // col.gameObject.GetComponent<slimeScript>().addDmg();
        }
    }
}
