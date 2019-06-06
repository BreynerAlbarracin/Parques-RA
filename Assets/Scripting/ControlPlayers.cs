using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayers : MonoBehaviour {

    /*
		The players need control the token using their hands, however, we would use a keyinput to manager
		game, after, the game input will be swap Leap Motion
	*/

    /*
		The user have 7 controlles:
		1 Change token onward
		2 Change token backward
		3 Rotate the camera clockwise
		4 Rotate the camera counterclockwise
		5 Select 
		6 Roll the dice
		7 "Soplar" the player after moved its tokens

		Any player have its 7 keys:
		Player 1
		1 a - Left
		2 d - Right
		3 w - Select
		4 s - Throw Dice
		5 e - Clockwise
		6 q - Counter ClockWise
        7 z - "Soplar"
	*/

    bool left;
    bool right;
    bool select;
    bool throwDice;
    bool counterClockwise;
    bool clockwise;
    bool soplo;

    // Use this for initialization
    void Start() {
        setFalse();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Input A Down");
            left = true;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("Input D Down");
            right = true;
        } else if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("Input W Down");
            select = true;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("Input S Down");
            throwDice = true;
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Input E Down");
            clockwise = true;
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Input Q Down");
            counterClockwise = true;
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("Input Z Down");
            soplo = true;
        } else {
            setFalse();
        }
    }
    void setFalse() {
        left = false;
        right = false;
        select = false;
        throwDice = false;
        clockwise = false;
        counterClockwise = false;
        soplo = false;
    }

    public bool isLeft() {
        return left;
    }
    public bool isRight() {
        return right;
    }
    public bool isSelect() {
        return select;
    }
    public bool isThrowDice() {
        return throwDice;
    }
    public bool isCounterclockwise() {
        return counterClockwise;
    }
    public bool isClockwise() {
        return clockwise;
    }
    public bool isSoplo() {
        return soplo;
    }
}