using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour {

    public bool turn;
    bool selecToken;
    bool selecDice;
    ControlPlayers cp;

    // Use this for initialization
    void Start() {
        turn = false;
        selecToken = false;
        selecDice = false;
        cp = this.GetComponent<ControlPlayers>();
    }

    // Update is called once per frame
    void Update() {
        if (turn && GameObject.Find("Dice1").GetComponent<Dice>().getValue() != 0 && GameObject.Find("Dice2").GetComponent<Dice>().getValue() != 0) {
            Debug.Log(this.name + " Select Token");
            selecToken = true;
        }

        if (turn) {
            if (cp.isLeft()) {
            } else if (cp.isRight()) {
            } else if (cp.isSelect()) {
            } else if (cp.isThrowDice()) {
                Debug.Log("Throw dice by: " + this.name);
                throwDice();
            } else if (cp.isCounterclockwise()) {
            } else if (cp.isClockwise()) {
            } else if (cp.isSoplo()) {
            }
        }
    }

    void throwDice() {
        if (!selecToken && !selecDice) {
            GameObject.Find("Dice1").GetComponent<Dice>().throwDice();
            GameObject.Find("Dice2").GetComponent<Dice>().throwDice();
        }
    }

    void moveSelectToken() {

    }

    void moveSelectDice() {

    }

    void rotateCamera() {

    }


}
