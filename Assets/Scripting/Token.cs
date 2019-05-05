using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token  : MonoBehaviour {
    public string color;
    public string model;

    public Token(string color, string model) {
        this.color = color;
        this.model = model;
    }
}
