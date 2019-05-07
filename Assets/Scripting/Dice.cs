using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    public void throwDice() {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 15, this.transform.localPosition.z);
        this.transform.localRotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);
    }
}