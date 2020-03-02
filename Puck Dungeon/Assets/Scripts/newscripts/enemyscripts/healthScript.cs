using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{

    public float health;
    public Text healthTxt;

    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        healthTxt = GameObject.Find("healthTxt").GetComponent<Text>();
        healthTxt.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void checkHealth()
    {
        healthTxt.text = health.ToString();
        if(health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
