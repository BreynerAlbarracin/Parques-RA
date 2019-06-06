using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Vector3 position;
    public Vector3 rotation;
    public GameObject nextNode;
    public GameObject extraNode;
    public List<GameObject> tokens = new List<GameObject>();
    public string color;
    public bool secure;
    public bool exit;

    //Reference of measurements game
    public float widthNode = 0.6f;
    public float heightToken = 0.5f;

    void Start() {
        tokens = new List<GameObject>();
    }

    public void attachNode(GameObject node) {
        this.nextNode = node;
    }

    public void attachExtraNode(GameObject node) {
        this.extraNode = node;
    }

    public void setRotation(Vector3 rotation) {
        this.rotation = rotation;
        this.transform.Rotate(rotation);
    }

    public Quaternion getRotation() {
        return this.transform.rotation;
    }

    public void setTranslation(Vector3 translation) {
        this.position = translation;
        this.transform.Translate(position);
    }
    public Vector3 getPosition() {
        return this.transform.position;
    }

    public void setColor(string color) {
        this.color = color;
    }

    public void setSecure(bool secure) {
        this.secure = secure;
    }

    public void setExit(bool exit) {
        this.exit = exit;
    }

    public GameObject next() {
        return nextNode;
    }

    public GameObject extraNext() {
        return extraNode;
    }

    public void addToken(GameObject token) {
        tokens.Add(token);
        organizeTokens();
    }

    public void addPrisonToken(GameObject token) {
        tokens.Add(token);

        organizePrisionTokens();
    }

    public void organizeTokens() {
        float space = widthNode / (tokens.Count + 1);

        int pos = 1;
        foreach (GameObject token in tokens) {
            token.transform.localPosition = new Vector3((space * pos) - (widthNode / 2), this.heightToken, 0);
            pos++;
        }
    }

    public void organizePrisionTokens() {
        Vector3[] positionsPrison = new Vector3[] {
            new Vector3(1.68f, heightToken, 0f),
            new Vector3(0.55f, heightToken, 0.21f),
            new Vector3(-0.665f, heightToken, 0.116f),
            new Vector3(-1.78f, heightToken, -0.3f)};

        int pos = 0;
        foreach (GameObject token in tokens) {
            token.transform.localPosition = new Vector3(0, 0, 0);
            token.transform.localPosition = positionsPrison[pos];
            pos++;
        }
    }
}

