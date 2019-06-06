using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour {

    public bool turn;
    bool selecToken;
    bool selecDice;
    ControlPlayers cp;
    int diceNumber;
    int tokenNumber;
    int numberMove;
    GameObject[] tokens;
    string color;

    // Use this for initialization
    void Start() {
        turn = false;
        selecToken = false;
        selecDice = false;
        numberMove = 0;
        cp = this.GetComponent<ControlPlayers>();
        tokens = new GameObject[4];
        color = this.GetComponent<Node>().color;
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < tokens.Length; i++) {
            tokens[i] = GameObject.Find("Token" + color + (i + 1));
        }

        if (turn) {
            rotateCamera();
            throwDice();

            if (GameObject.Find("Dice1").GetComponent<Dice>().getValue() != 0 && GameObject.Find("Dice2").GetComponent<Dice>().getValue() != 0) {
                Debug.Log(this.name + " Select Token");
                selecToken = true;
                selectToken();
                selectDice();
            }
        }
    }

    void throwDice() {
        if (!selecToken && !selecDice && cp.isThrowDice()) {
            GameObject.Find("Dice1").GetComponent<Dice>().throwDice();
            GameObject.Find("Dice2").GetComponent<Dice>().throwDice();
        }
    }

    void selectToken() {
        if (selecToken) {
            if (cp.isRight()) {
                GameObject.Find("UI").GetComponent<CanvasController>().selectRight();
            } else if (cp.isLeft()) {
                GameObject.Find("UI").GetComponent<CanvasController>().selectLeft();
            } else if (cp.isSelect()) {
                tokenNumber = GameObject.Find("UI").GetComponent<CanvasController>().selectToken();
                selecToken = false;
                selecDice = true;
            }
        }
    }

    void selectDice() {
        if (selecDice) {
            if (cp.isRight()) {
                GameObject.Find("UI").GetComponent<CanvasController>().selectDiceRight();
            } else if (cp.isLeft()) {
                GameObject.Find("UI").GetComponent<CanvasController>().selectDiceLeft();
            } else if (cp.isSelect()) {
                diceNumber = GameObject.Find("UI").GetComponent<CanvasController>().selectDice();
                selecDice = false;
                moveToken();

                if (numberMove == 2) {
                    selecToken = false;
                    numberMove = 0;
                    endTurn();
                } else {
                    selecToken = true;
                }
            }
        }
    }

    void rotateCamera() {
        if (cp.isClockwise()) {

        } else if (cp.isCounterclockwise()) {

        }
    }

    void moveToken() {
        Debug.Log("Valores seleccionados");
        Debug.Log(tokenNumber);
        Debug.Log(diceNumber);

        int value = GameObject.Find("Dice" + diceNumber).GetComponent<Dice>().getValue();

        GameObject.Find("Token" + color + tokenNumber).GetComponent<Token>().Move(value);
        numberMove++;
    }

    public void startTurn() {
        this.turn = true;
    }

    public void endTurn() {
        this.turn = false;
    }

    public bool isTurn() {
        return turn;
    }
}
