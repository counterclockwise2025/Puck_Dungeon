using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") && Camera.main.transform.position.y < 4.5f){
            Camera.main.transform.Translate(0,.1f,0);
        }
        if(Input.GetKey("s") && Camera.main.transform.position.y > -4.5f){
            Camera.main.transform.Translate(0,-.1f,0);
        }
        if(Input.GetKey("a") && Camera.main.transform.position.x > -9f){
            Camera.main.transform.Translate(-.1f,0,0);
        }
        if(Input.GetKey("d") && Camera.main.transform.position.x < 9f){
            Camera.main.transform.Translate(.1f,0,0);
        }







        if(Input.mouseScrollDelta.y < 0 && Camera.main.orthographicSize <= 5){
            Camera.main.orthographicSize += .3f;
        }
        if(Input.mouseScrollDelta.y > 0 && Camera.main.orthographicSize >= 1){
            Camera.main.orthographicSize -= .3f;
        }
    }
}
