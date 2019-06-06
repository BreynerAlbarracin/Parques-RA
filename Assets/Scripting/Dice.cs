using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    public int value;

    public void throwDice() {
        this.value = 0;
        this.transform.SetParent(GameObject.Find("Dices").transform);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 15, this.transform.localPosition.z);
        this.transform.localRotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);
    }

    public void setValue(int value) {
        this.value = value;
    }

    public int getValue() {
        return this.value;
    }
}