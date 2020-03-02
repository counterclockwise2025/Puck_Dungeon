using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{

    public int index;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void doQuit()
    {
        Application.Quit();
    }

    public void levelFirst()
    {
        index = Random.Range(2,6);
        SceneManager.LoadScene(index);
    }
}
