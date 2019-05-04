using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Vector3 position;
    public Vector3 rotation;
    public GameObject nextNode;
    public GameObject extraNode;
    public List<GameObject> tokens;
    public string color;
    public bool secure;
    public bool exit;

    //Reference of measurements game
    public float widthNode = 0.6f;
    public float heightToken = 12f;

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

    public Quaternion gerRotation(){
        return this.transform.rotation;
    }

    public void setTranslation(Vector3 translation) {
        this.position = translation;
        this.transform.Translate(position);
    }
    public Vector3 getPosition(){
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

    public void organizeTokens() {
        int cantToken = tokens.Count;
        float space = widthNode / (cantToken + 1);

        int pos = 1;
        foreach (GameObject token in tokens) {
            token.transform.Translate(new Vector3((space * pos) - (widthNode / 2), this.heightToken, 0));
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
            token.transform.Translate(positionsPrison[pos]);
            pos++;
        }
    }
}

