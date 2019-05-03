using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMesh : MonoBehaviour {

    public Node rootNodes;
    public Node[] prisons;
    public Node[] crowns;
    public Vector3[] hands;
    public Vector3[] witchers;

    public bool isLap(Node node) {
        if (rootNodes == node) {
            return true;
        } else {
            return false;
        }
    }

    public int contNodes() {
        int count = 1;
        Node node = rootNodes;

        while (!isLap(node.nextNode)) {
            count++;
            node = node.nextNode;
        }

        return count;
    }

    public int contExtraNodes() {
        int count = 0;
        Node node = rootNodes;

        while (!isLap(node.nextNode)) {
            if (node.extraNode != null) {
                Node extra = node.extraNode;

                while (true) {
                    count++;
                    extra = extra.nextNode;
                    if (extra.nextNode == null) {
                        count++;
                        break;
                    }
                }
            }
            node = node.nextNode;
        }

        return count;
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
