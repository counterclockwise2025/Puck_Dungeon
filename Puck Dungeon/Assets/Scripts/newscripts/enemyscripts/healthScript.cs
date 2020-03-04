using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{

    public float health;
    public Text healthTxt;

    // Start is called before the first frame update
    void Awake() {
        healthTxt = this.gameObject.transform.Find("Canvas/healthTxt").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the health UI to the objects health value
        healthTxt.text = health + "";
    }


    public void checkHealth()
    {
        if(health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
