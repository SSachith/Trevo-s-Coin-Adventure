using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_script : MonoBehaviour {
    public ScoreTextScript score;   
    public bool marks = false;
	
     void OnTriggerEnter2D(Collider2D col){
       Destroy(gameObject);
       ScoreTextScript.coinAmount += 1;
       }
}
