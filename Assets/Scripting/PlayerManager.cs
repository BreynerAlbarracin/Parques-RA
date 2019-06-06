using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    GameObject[] players;

    // Use this for initialization
    void Start() {
        players = new GameObject[2];
    }

    // Update is called once per frame
    void Update() {
        players[0] = GameObject.Find("HandsRed");
        players[1] = GameObject.Find("HandsYellow");
        
        players[0].GetComponent<ActionPlayer>().startTurn();

        if (!players[0].GetComponent<ActionPlayer>().isTurn()) {
            players[1].GetComponent<ActionPlayer>().startTurn();
        } else {
            Debug.Log("Turno player 1");
        }

        if (!players[1].GetComponent<ActionPlayer>().isTurn()) {
            players[0].GetComponent<ActionPlayer>().startTurn();
        }else{
            Debug.Log("Turno player 2");
        }
    }
}