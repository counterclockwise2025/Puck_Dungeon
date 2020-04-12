using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedUIScript : MonoBehaviour
{
    playerScript pScript;
    Text speedTxt;
    // Start is called before the first frame update
    void Start()
    {
        speedTxt = GetComponent<Text>();
        pScript = this.gameObject.transform.parent.root.gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        speedTxt.text = "Speed: " + pScript.speed;
        if(pScript.speed == pScript.baseSpeed){
            speedTxt.color = Color.green;
        }
        else{
            speedTxt.color = Color.black;
        }
    }
}
