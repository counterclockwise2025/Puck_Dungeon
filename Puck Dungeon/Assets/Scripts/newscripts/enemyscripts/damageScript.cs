using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageScript : MonoBehaviour
{

    public float damage = 6;
    public Text dmgTxt;

    // Start is called before the first frame update
    void Start()
    {
        dmgTxt = GameObject.Find("dmgTxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dmgTxt.text = "" + damage;

    }
}
