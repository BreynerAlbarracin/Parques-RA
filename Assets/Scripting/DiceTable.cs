using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTable : MonoBehaviour {

    Vector3 dice1Velocity;
    Vector3 dice2Velocity;
    GameObject diceGO1;
    GameObject diceGO2;

    // Use this for initialization
    void Start() {
        diceGO1 = GameObject.Find("Dice1");
        diceGO2 = GameObject.Find("Dice2");
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerStay(Collider obj) {
        dice1Velocity = GameObject.Find("Dice1").GetComponent<Rigidbody>().velocity;
        dice2Velocity = GameObject.Find("Dice2").GetComponent<Rigidbody>().velocity;

        if (dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f && dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f) {
            switch (obj.gameObject.name) {
                case "Dice1Side1":
                    diceGO1.GetComponent<Dice>().setValue(3);
                    break;
                case "Dice1Side2":
                    diceGO1.GetComponent<Dice>().setValue(4);
                    break;
                case "Dice1Side3":
                    diceGO1.GetComponent<Dice>().setValue(1);
                    break;
                case "Dice1Side4":
                    diceGO1.GetComponent<Dice>().setValue(2);
                    break;
                case "Dice1Side5":
                    diceGO1.GetComponent<Dice>().setValue(6);
                    break;
                case "Dice1Side6":
                    diceGO1.GetComponent<Dice>().setValue(5);
                    break;

                //Case to dice face two
                case "Dice2Side1":
                    diceGO2.GetComponent<Dice>().setValue(3);
                    break;
                case "Dice2Side2":
                    diceGO2.GetComponent<Dice>().setValue(4);
                    break;
                case "Dice2Side3":
                    diceGO2.GetComponent<Dice>().setValue(1);
                    break;
                case "Dice2Side4":
                    diceGO2.GetComponent<Dice>().setValue(2);
                    break;
                case "Dice2Side5":
                    diceGO2.GetComponent<Dice>().setValue(6);
                    break;
                case "Dice2Side6":
                    diceGO2.GetComponent<Dice>().setValue(5);
                    break;
            }
        }
    }
}

