using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaUIScript : MonoBehaviour
{
    playerScript pScript;
    Text manaText;
    // Start is called before the first frame update
    void Start()
    {
        manaText = GetComponent<Text>();
        pScript = this.gameObject.transform.parent.root.gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "Mana: " + pScript.pMana;
    }
}

