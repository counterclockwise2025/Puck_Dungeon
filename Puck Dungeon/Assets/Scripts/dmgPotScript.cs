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

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<playerScript>().addDmg();
        }
        if(col.gameObject.tag == "enemy"){
            col.gameObject.GetComponent<slimeScript>().addDmg();
        }
    }
}
