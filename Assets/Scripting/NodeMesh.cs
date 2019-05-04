using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMesh : MonoBehaviour {

    public GameObject rootNodes;
    public GameObject[] hands;
    public GameObject[] prisons;
    public GameObject[] witchers;
    public GameObject[] crowns;

    public bool isLap(GameObject node) {
        if (rootNodes == node) {
            return true;
        } else {
            return false;
        }
    }

    public int contNodes() {
        int count = 1;
        GameObject node = rootNodes;

        while (!isLap(node.GetComponent<Node>().next())) {
            count++;
            node = node.GetComponent<Node>().next();
        }

        return count;
    }

    public int contExtraNodes() {
        int count = 0;
        GameObject node = rootNodes;

        while (!isLap(node)) {
            if (node.GetComponent<Node>().extraNext() != null) {
                GameObject extra = node.GetComponent<Node>().extraNext();

                while (!(extra == null)) {
                    count++;
                    extra = extra.GetComponent<Node>().extraNext();
                }
            }
            node = node.GetComponent<Node>().extraNext();
        }

        return count;
    }

    public void setRoot(GameObject root) {
        this.rootNodes = root;
    }

    public string report() {
        string msj = "";
        msj += "Report NodeMesh" + "\n";
        msj += "Count hands: " + hands.Length + "\n";
        msj += "Count prisons: " + prisons.Length + "\n";
        msj += "Count crowns: " + crowns.Length + "\n";
        msj += "Count witchers: " + witchers.Length + "\n";
        msj += "Count nodes: " + contNodes() + "\n";
        msj += "Count extraNode: " + contExtraNodes() + "\n";

        return msj;
    }
}
