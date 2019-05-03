using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    public Vector3 position;
    public Vector3 rotation;
    public Node nextNode;
    public Node extraNode;
    public List<GameObject> tokens;
    public string color;
    public bool secure;
    public bool exit;

    //Reference of measurements game
    public float widthNode = 0.6f;
    public float heightToken = 12f;

    public Node(Vector3 position, Vector3 rotation, Node nextNode, Node extraNode, string color, bool secure, bool exit) {
        this.position = position;
        this.rotation = rotation;
        this.nextNode = nextNode;
        this.extraNode = extraNode;
        tokens = new List<GameObject>();
        this.color = color;
        this.secure = secure;
        this.exit = exit;
    }

    public void attachNode(Node node) {
        this.nextNode = node;
    }

    public void attachExtraNode(Node node) {
        this.extraNode = node;
    }

    public void organizeTokens() {
        int cantToken = tokens.Count;
        float space = widthNode / (cantToken + 1);

        int pos = 1;
        foreach (GameObject token in tokens) {
            token.transform.localPosition = new Vector3((space * pos) - (widthNode / 2), this.heightToken, 0);
            pos++;
        }
    }

    public void organizePrisionTokens() {
        Vector3[] positionsPrison = new Vector3[] {
            new Vector3(0.44f, heightToken, -0.3f),
            new Vector3(0.16f, heightToken, 0.05f),
            new Vector3(-0.16f, heightToken, 0.05f),
            new Vector3(-0.44f, heightToken, -0.3f)};

        int pos = 0;
        foreach (GameObject token in tokens) {
            token.transform.localPosition = positionsPrison[pos];
            pos++;
        }
    }
}

