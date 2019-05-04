using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token  : MonoBehaviour {
    public Node nodeAttach;
    public string color;
    public string model;

    public Token(Node nodeAttach, string color, string model) {
        this.nodeAttach = nodeAttach;
        this.color = color;
        this.model = model;
    }
}
