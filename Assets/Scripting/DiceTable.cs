using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTable : MonoBehaviour {

    Vector3 dice1Velocity;
    Vector3 dice2Velocity;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay(Collider obj) {
        dice1Velocity = GameObject.Find("Dice1").GetComponent<Rigidbody>().velocity;
        dice1Velocity = GameObject.Find("Dice2").GetComponent<Rigidbody>().velocity;

        if (dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f && dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f) {
            switch (obj.gameObject.name) {
				case "Side1":
				Debug.Log("3");
				break;
				case "Side2":
				Debug.Log("4");
				break;
				case "Side3":
				Debug.Log("1");
				break;
				case "Side4":
				Debug.Log("2");
				break;
				case "Side5":
				Debug.Log("6");
				break;
				case "Side6":
				Debug.Log("5");
				break;
            }
        }
    }
}
