using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpellScript : MonoBehaviour
{

    public GameObject[] players;
    public bool isFiring = true;
    public Rigidbody2D rgbody2D;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        rgbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0)){
            rgbody2D.velocity = transform.right * 5f;
        }
    }
}
