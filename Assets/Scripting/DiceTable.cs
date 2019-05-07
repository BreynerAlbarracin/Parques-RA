using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTable : MonoBehaviour {

    Vector3 dice1Velocity;
    Vector3 dice2Velocity;

    bool reportDice1;
    bool reportDice2;
    public int dice1;
    public int dice2;
    GameObject cameraGame;
    GameObject diceGO1;
    GameObject diceGO2;

    // Use this for initialization
    void Start() {
        reportDice1 = false;
        reportDice2 = false;
        dice1 = 0;
        dice2 = 0;
        cameraGame = GameObject.Find("Camera");
        diceGO1 = GameObject.Find("Dice1");
        diceGO2 = GameObject.Find("Dice2");
    }

    // Update is called once per frame
    void Update() {
        if (reportDice1 && reportDice2) {
            diceGO1.transform.SetParent(cameraGame.transform);
            diceGO1.transform.localPosition = new Vector3(4f, 0.8f, 5f);
            diceGO1.transform.localRotation = defRotation(dice1);
            diceGO2.transform.SetParent(cameraGame.transform);
            diceGO2.transform.localPosition = new Vector3(4f, -0.8f, 5f);
            diceGO2.transform.localRotation = defRotation(dice2);
        }
    }

    void OnTriggerStay(Collider obj) {
        dice1Velocity = GameObject.Find("Dice1").GetComponent<Rigidbody>().velocity;
        dice2Velocity = GameObject.Find("Dice2").GetComponent<Rigidbody>().velocity;

        if (!reportDice1 && dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f) {
            switch (obj.gameObject.name) {
                case "Dice1Side1":
                    dice1 = 3;
                    reportDice1 = true;
                    break;
                case "Dice1Side2":
                    dice1 = 4;
                    reportDice1 = true;
                    break;
                case "Dice1Side3":
                    dice1 = 1;
                    reportDice1 = true;
                    break;
                case "Dice1Side4":
                    dice1 = 2;
                    reportDice1 = true;
                    break;
                case "Dice1Side5":
                    dice1 = 6;
                    reportDice1 = true;
                    break;
                case "Dice1Side6":
                    dice1 = 5;
                    reportDice1 = true;
                    break;
            }
        }

        if (!reportDice2 && dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f) {
            switch (obj.gameObject.name) {
                case "Dice2Side1":
                    dice2 = 3;
                    reportDice2 = true;
                    break;
                case "Dice2Side2":
                    dice2 = 4;
                    reportDice2 = true;
                    break;
                case "Dice2Side3":
                    dice2 = 1;
                    reportDice2 = true;
                    break;
                case "Dice2Side4":
                    dice2 = 2;
                    reportDice2 = true;
                    break;
                case "Dice2Side5":
                    dice2 = 6;
                    reportDice2 = true;
                    break;
                case "Dice2Side6":
                    dice2 = 5;
                    reportDice2 = true;
                    break;
            }
        }
    }

    Quaternion defRotation(int number) {
        Quaternion rotation = new Quaternion();
        switch (number) {
            case 1:
                rotation.Set(0f, 0.9f, 0f, -0.3f);
                break;
            case 2:
                rotation.Set(0f, 0.4f, 0f, -0.9f);
                break;
            case 3:
                rotation.Set(0f, 0.3f, 0f, 0.9f);
                break;
            case 4:
                rotation.Set(0f, -0.9f, 0f, -0.5f);
                break;
            case 5:
                rotation.Set(0.7f, -0.2f, -0.2f, -0.7f);
                break;
            case 6:
                rotation.Set(0.7f, 0.2f, -0.2f, 0.7f);
                break;
        }

        return rotation;
    }
}

