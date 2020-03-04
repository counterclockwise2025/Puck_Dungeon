using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageUIScript : MonoBehaviour
{
    playerScript pScript;
    Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        damageText = GetComponent<Text>();
        pScript = this.gameObject.transform.parent.root.gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        damageText.text = "Damage: " + pScript.pDamage;
    }
}
