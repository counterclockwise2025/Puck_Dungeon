using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageScript : MonoBehaviour
{

    public float damage;
    public Text dmgTxt;

    // Start is called before the first frame update
    void Start()
    {
        dmgTxt = this.gameObject.transform.Find("Canvas/dmgTxt").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dmgTxt.text = "" + damage;
    }
}
