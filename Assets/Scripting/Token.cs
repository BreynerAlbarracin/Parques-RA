using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {
    public string color;
    public string model;

    public Token(string color, string model) {
        this.color = color;
        this.model = model;
    }

    public void Move(int value) {
        Transform parent = this.transform.root;
        GameObject go = parent.gameObject;

        go.GetComponent<Node>().detachToken(this.gameObject);

        while (value != 0) {
            go = go.GetComponent<Node>().next();
            value--;
        }

        go.GetComponent<Node>().addToken(this.gameObject);
    }
}
