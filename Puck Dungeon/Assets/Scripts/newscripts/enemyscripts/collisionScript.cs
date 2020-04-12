using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    public gameControllerScriptNew gcScript;
    public healthScript hScript;
    private bool checkPlayerPos;
    public float sphereRadius;
    Rigidbody2D rgbody2D;


    // Start is called before the first frame update
    void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gcScript = GameObject.Find("GameController").GetComponent<gameControllerScriptNew>();
        hScript = GetComponent<healthScript>();
    }

    // Update is called once per frame
    // do not know if this is correctly written still working on this to improve the code itself
    void Update()
    {
        // RaycastHit hit;
        // //do not know if the vector 3 to check direction is correct
        // Ray enemyRay = new Ray(transform.position, Vector2.left);

// <<<<<<< HEAD
        // if(!checkPlayerPos)
        // {
        //     if(Physics.Raycast(enemyRay, out hit, Player))
        //     {
        //         if(hit.collider.tag == "Player")
        //         {
        //             Vector2 targetDir;
        //             targetDir = this.gameObject.transform.position - hit.collider.gameObject.transform;
        //             rgbody2D.velocity = targetDir;
        //         }
        //     }
        // }
// =======
//         if(checkPlayerPos)
//         {
//             if(Physics.Raycast(enemyRay, out hit, Player))
//             {
//                 if(hit.collider.tag == "Player")
//                 {
//                     OnCollisionEnter2D();
//                 }
//             }
//         }
// >>>>>>> 37ce5f3f4647771dc583dec73565224edee29837
//     }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(gcScript.playerTurn == true){
            if(col.gameObject.tag == "Player")
                {
                    hScript.health = hScript.health - col.gameObject.GetComponent<playerScript>().pDamage;
                    hScript.checkHealth();
                }
        }
    }
}

