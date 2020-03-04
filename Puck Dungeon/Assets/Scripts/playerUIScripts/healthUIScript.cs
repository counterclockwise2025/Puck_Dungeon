using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUIScript : MonoBehaviour
{
    playerScript pScript;
    Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        pScript = this.gameObject.transform.parent.root.gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + pScript.pHealth;
    }
}
