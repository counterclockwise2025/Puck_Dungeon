using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowSpellPickupScript : MonoBehaviour
{
    public GameObject abilityButtonPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.AddComponent<arrowSpellScript>();
            playerScript pScript = other.gameObject.GetComponent<playerScript>();
            Transform abilityUI = GameObject.Find("playerPuck/puckSprite/actionUIHolder/OnScreenActionUI/portraitBackplate/abilityHotBar/Canvas").transform;

            GameObject newButton = Instantiate(abilityButtonPrefab, this.gameObject.transform.position,Quaternion.identity);
            newButton.gameObject.transform.SetParent(abilityUI);

            Destroy(this.gameObject);
        }
    }
}
