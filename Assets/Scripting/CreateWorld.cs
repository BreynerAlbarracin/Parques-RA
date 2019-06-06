using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateWorld : MonoBehaviour {

    // The board have a distribution according to next estructure
    // 1. Blue x+ z+
    // 2. Red x- z+
    // 3. Green x- z-
    // 4. Yellow x+ z-
    /*
      2 | 1
    ----|----
      3 | 4
    */

    // Colors to use
    string[] colors = new string[] { "Blue", "Red", "Green", "Yellow" };

    // Position by fixed elements
    Vector3 handsP = new Vector3(10.7f, 9.8f, 10.65f);
    Vector3 witcherP = new Vector3(7.1f, 5.8f, 7.1f);
    Vector3 prisonP = new Vector3(9f, 5.13f, 8.76f);
    Vector3 crownP = new Vector3(3.8f, 9.22f, 0f);
    Vector3 start = new Vector3(11.8f, 1.5f, 0f);

    // Reference to mesh nodes
    NodeMesh nodemesh;
    Transform nodes;

    // Use this for initialization
    void Start() {
        Debug.Log("Find Board");
        nodemesh = GameObject.Find("Board").GetComponent<NodeMesh>();
        nodes = GameObject.Find("Nodes").transform;

        Debug.Log("Creating objects");
        createHands();
        createPrisons();
        createWitchers();
        createCrowns();
        createNodes();
        createTokens();
    }

    // Update is called once per frame
    void Update() {

    }

    // This method allow create the hands GameObject
    void createHands() {
        Debug.Log("Creating hands nodes");
        Vector3[] vectors = createMirrorVectors(handsP);
        GameObject[] hands = new GameObject[4];
        Transform players = GameObject.Find("Players").transform;

        hands[0] = createEGO("HandsBlue", vectors[0], new Vector3(0f, 225f, 0f), colors[0], false, false, players);
        hands[0].AddComponent<ControlPlayers>();
        hands[0].AddComponent<ActionPlayer>();
        hands[1] = createEGO("HandsRed", vectors[1], new Vector3(0f, 135f, 0f), colors[1], false, false, players);
        hands[1].AddComponent<ControlPlayers>();
        hands[1].AddComponent<ActionPlayer>();
        hands[2] = createEGO("HandsGreen", vectors[2], new Vector3(0f, 45f, 0f), colors[2], false, false, players);
        hands[2].AddComponent<ControlPlayers>();
        hands[2].AddComponent<ActionPlayer>();
        hands[3] = createEGO("HandsYellow", vectors[3], new Vector3(0f, 315f, 0f), colors[3], false, false, players);
        hands[3].AddComponent<ControlPlayers>();
        hands[3].AddComponent<ActionPlayer>();

        nodemesh.crowns = hands;
    }

    // This method create a prison positions
    void createPrisons() {
        Debug.Log("Creating prisons nodes");
        Vector3[] vectors = createRotationVector(prisonP);
        GameObject[] prisons = new GameObject[4];

        prisons[0] = createEGO("PrisonBlue", vectors[0], new Vector3(0f, 225f, 0), colors[0], false, false, nodes);
        prisons[1] = createEGO("PrisonRed", vectors[1], new Vector3(0f, 135f, 0), colors[1], false, false, nodes);
        prisons[2] = createEGO("PrisonGreen", vectors[2], new Vector3(0f, 45f, 0), colors[2], false, false, nodes);
        prisons[3] = createEGO("PrisonYellow", vectors[3], new Vector3(0f, 315f, 0), colors[3], false, false, nodes);

        nodemesh.prisons = prisons;
    }

    // This method allow create the witchers GameObject
    void createWitchers() {
        Debug.Log("Creating witchers nodes");
        Vector3[] vectors = createMirrorVectors(witcherP);
        GameObject[] witchers = new GameObject[4];

        witchers[0] = createEGO("WitcherBlue", vectors[0], new Vector3(0f, 225f, 0f), colors[0], false, false, nodes);
        witchers[1] = createEGO("WitcherRed", vectors[1], new Vector3(0f, 135f, 0f), colors[1], false, false, nodes);
        witchers[2] = createEGO("WitcherGreen", vectors[2], new Vector3(0f, 45f, 0f), colors[2], false, false, nodes);
        witchers[3] = createEGO("WitcherYellow", vectors[3], new Vector3(0f, 315f, 0f), colors[3], false, false, nodes);

        nodemesh.crowns = witchers;
    }

    // This method create a crowns positions
    void createCrowns() {
        Debug.Log("Creating crowns nodes");
        Vector3[] vectors = createRotationVector(crownP);
        GameObject[] crowns = new GameObject[4];

        crowns[0] = createEGO("CrownBlue", vectors[0], new Vector3(0f, 270f, 0f), colors[0], false, false, nodes);
        crowns[1] = createEGO("CrownRed", vectors[1], new Vector3(0f, 180f, 0f), colors[1], false, false, nodes);
        crowns[2] = createEGO("CrownGreen", vectors[2], new Vector3(0f, 90f, 0f), colors[2], false, false, nodes);
        crowns[3] = createEGO("CrownYellow", vectors[3], new Vector3(0f, 0f, 0f), colors[3], false, false, nodes);

        nodemesh.crowns = crowns;
    }

    // This methid create a board nodes
    void createNodes() {
        Debug.Log("Creating boards nodes");
        Vector3[] vectors = createRotationVector(start);
        Transform nodes = GameObject.Find("Nodes").transform;

        GameObject rootBlue = createEGO("RootBlue", vectors[0], new Vector3(0f, -90f, 0f), colors[0], true, true, nodes);
        GameObject rootRed = createEGO("RootRed", vectors[1], new Vector3(0f, 180f, 0f), colors[1], true, true, nodes);
        GameObject rootGreen = createEGO("RootGreen", vectors[2], new Vector3(0f, 90f, 0f), colors[2], true, true, nodes);
        GameObject rootYellow = createEGO("RootYellow", vectors[3], new Vector3(0f, 0f, 0f), colors[3], true, true, nodes);

        nodemesh.setRoot(rootBlue);

        GameObject nodeB = rootBlue;
        GameObject nodeR = rootRed;
        GameObject nodeG = rootGreen;
        GameObject nodeY = rootYellow;

        Debug.Log("Creating ladder from root nodes");
        vectors[0].z = vectors[0].z + 3.95f;
        vectors = createRotationVector(vectors[0]);

        for (int i = 0; i < 4; i++) {
            GameObject nodeBT = createEGO("LadderBlue-" + i, new Vector3(vectors[0].x - i, vectors[0].y + i, vectors[0].z), new Vector3(0f, -90f, 0f), colors[0], false, false, nodes);
            GameObject nodeRT = createEGO("LadderRed-" + i, new Vector3(vectors[1].x, vectors[1].y + i, vectors[1].z - i), new Vector3(0f, 180f, 0f), colors[1], false, false, nodes);
            GameObject nodeGT = createEGO("LadderGreen-" + i, new Vector3(vectors[2].x + i, vectors[2].y + i, vectors[2].z), new Vector3(0f, 90f, 0f), colors[2], false, false, nodes);
            GameObject nodeYT = createEGO("LadderYellow-" + i, new Vector3(vectors[3].x, vectors[3].y + i, vectors[3].z + i), new Vector3(0f, 0f, 0f), colors[3], false, false, nodes);

            nodeB.GetComponent<Node>().attachNode(nodeBT);
            nodeR.GetComponent<Node>().attachNode(nodeRT);
            nodeG.GetComponent<Node>().attachNode(nodeGT);
            nodeY.GetComponent<Node>().attachNode(nodeYT);

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;
            Debug.Log(i);
        }

        Debug.Log("Creating curve nodes from ladder");
        vectors = createRotationVector(new Vector3(nodeB.GetComponent<Node>().getPosition().x - 1, nodeB.GetComponent<Node>().getPosition().y + 1, nodeB.GetComponent<Node>().getPosition().z));

        float spaceXCurve = 3.9f / 7;
        float spaceZCurve = 3.85f / 7;
        float angule = 90 / 8;
        float factor = 0;

        for (int i = 0; i < 8; i++) {
            GameObject nodeBT = createEGO("CurveBlue-" + i, new Vector3(vectors[0].x - ((spaceXCurve * i) + (spaceXCurve * factor)), vectors[0].y, vectors[0].z + ((spaceZCurve * i) - (spaceZCurve * factor))), new Vector3(0f, (-90 + i * angule), 0f), colors[0], false, false, nodes);
            GameObject nodeRT = createEGO("CurveRed-" + i, new Vector3(vectors[1].x - ((spaceXCurve * i) - (spaceXCurve * factor)), vectors[1].y, vectors[1].z - ((spaceZCurve * i) + (spaceZCurve * factor))), new Vector3(0f, (-180 + i * angule), 0f), colors[1], false, false, nodes);
            GameObject nodeGT = createEGO("CurveGreen-" + i, new Vector3(vectors[2].x + ((spaceXCurve * i) + (spaceXCurve * factor)), vectors[2].y, vectors[2].z - ((spaceZCurve * i) - (spaceZCurve * factor))), new Vector3(0f, (90 + i * angule), 0f), colors[2], false, false, nodes);
            GameObject nodeYT = createEGO("CurveYellow-" + i, new Vector3(vectors[3].x + ((spaceXCurve * i) - (spaceXCurve * factor)), vectors[3].y, vectors[3].z + ((spaceZCurve * i) + (spaceZCurve * factor))), new Vector3(0f, (0 + i * angule), 0f), colors[3], false, false, nodes);

            if (i < 3) {
                factor += 0.7f;
            } else if (i >= 4) {
                factor -= 0.7f;
            }

            nodeB.GetComponent<Node>().attachNode(nodeBT);
            nodeR.GetComponent<Node>().attachNode(nodeRT);
            nodeG.GetComponent<Node>().attachNode(nodeGT);
            nodeY.GetComponent<Node>().attachNode(nodeYT);

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;

            Debug.Log(i);
        }

        Debug.Log("Creating ladders nodes from curve");
        vectors = createRotationVector(new Vector3(nodeB.GetComponent<Node>().getPosition().x, nodeB.GetComponent<Node>().getPosition().y - 1, nodeB.GetComponent<Node>().getPosition().z + 1));

        for (int i = 0; i < 4; i++) {
            GameObject nodeBT = createEGO("LaddersBlue-" + i, new Vector3(vectors[0].x, vectors[0].y - i, vectors[0].z + i), new Vector3(0f, 0f, 0f), colors[0], false, false, nodes);
            GameObject nodeRT = createEGO("LaddersRed-" + i, new Vector3(vectors[1].x - i, vectors[1].y - i, vectors[1].z), new Vector3(0f, 270f, 0f), colors[1], false, false, nodes);
            GameObject nodeGT = createEGO("LaddersGreen-" + i, new Vector3(vectors[2].x, vectors[2].y - i, vectors[2].z - i), new Vector3(0f, 180f, 0f), colors[2], false, false, nodes);
            GameObject nodeYT = createEGO("LaddersYellow-" + i, new Vector3(vectors[3].x + i, vectors[3].y - i, vectors[3].z), new Vector3(0f, 90f, 0f), colors[3], false, false, nodes);

            nodeB.GetComponent<Node>().attachNode(nodeBT);
            nodeR.GetComponent<Node>().attachNode(nodeRT);
            nodeG.GetComponent<Node>().attachNode(nodeGT);
            nodeY.GetComponent<Node>().attachNode(nodeYT);

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;

            Debug.Log(i);
        }

        Debug.Log("Creating staircase to the crowns");
        nodeB.GetComponent<Node>().attachNode(rootRed);
        nodeR.GetComponent<Node>().attachNode(rootGreen);
        nodeG.GetComponent<Node>().attachNode(rootYellow);
        nodeY.GetComponent<Node>().attachNode(rootBlue);

        vectors = createRotationVector(new Vector3(start.x - 1, start.y + 1, start.z));

        for (int i = 0; i < 7; i++) {
            GameObject nodeBT = createEGO("StaircaseBlue-" + i, new Vector3(vectors[0].x - i, vectors[0].y + i, vectors[0].z), new Vector3(0f, -90f, 0f), colors[0], false, false, nodes);
            GameObject nodeRT = createEGO("StaircaseRed-" + i, new Vector3(vectors[1].x, vectors[1].y + i, vectors[1].z - i), new Vector3(0f, 180f, 0f), colors[1], false, false, nodes);
            GameObject nodeGT = createEGO("StaircaseGreen-" + i, new Vector3(vectors[2].x + i, vectors[2].y + i, vectors[2].z), new Vector3(0f, 90f, 0f), colors[2], false, false, nodes);
            GameObject nodeYT = createEGO("StaircaseYellow-" + i, new Vector3(vectors[3].x, vectors[3].y + i, vectors[3].z + i), new Vector3(0f, 0f, 0f), colors[3], false, false, nodes);

            if (i == 0) {
                rootBlue.GetComponent<Node>().attachExtraNode(nodeBT);
                rootRed.GetComponent<Node>().attachExtraNode(nodeRT);
                rootGreen.GetComponent<Node>().attachExtraNode(nodeGT);
                rootYellow.GetComponent<Node>().attachExtraNode(nodeYT);

                nodeB = rootBlue.GetComponent<Node>().extraNext();
                nodeR = rootRed.GetComponent<Node>().extraNext();
                nodeG = rootGreen.GetComponent<Node>().extraNext();
                nodeY = rootYellow.GetComponent<Node>().extraNext();
            } else {
                nodeB.GetComponent<Node>().attachNode(nodeBT);
                nodeR.GetComponent<Node>().attachNode(nodeRT);
                nodeG.GetComponent<Node>().attachNode(nodeGT);
                nodeY.GetComponent<Node>().attachNode(nodeYT);

                nodeB = nodeBT;
                nodeR = nodeRT;
                nodeG = nodeGT;
                nodeY = nodeYT;
            }

            Debug.Log(i);
        }

        Debug.Log(nodemesh.report());
    }

    // This method return array of vectors with the mirror vectors using the same Y
    Vector3[] createMirrorVectors(Vector3 vector) {
        Vector3[] vectors = new Vector3[4];

        vectors[0] = new Vector3(vector.x, vector.y, vector.z);
        vectors[1] = new Vector3(vector.x * -1, vector.y, vector.z);
        vectors[2] = new Vector3(vector.x * -1, vector.y, vector.z * -1);
        vectors[3] = new Vector3(vector.x, vector.y, vector.z * -1);

        return vectors;
    }

    // This method return array of vectors with the position in the four quadrant like a mirror
    Vector3[] createRotationVector(Vector3 vector) {
        Vector3[] vectors = new Vector3[4];

        vectors[0] = new Vector3(vector.x, vector.y, vector.z);
        vectors[1] = new Vector3(vector.z * -1, vector.y, vector.x);
        vectors[2] = new Vector3(vector.x * -1, vector.y, vector.z * -1);
        vectors[3] = new Vector3(vector.z, vector.y, vector.x * -1);

        return vectors;
    }

    // This methos allow create a empty GameObject
    GameObject createEGO(string name, Vector3 position, Vector3 rotation, string color, bool secure, bool exit, Transform parent) {
        GameObject gObject = new GameObject();
        gObject.transform.SetParent(parent);
        gObject.name = name;

        gObject.AddComponent<Node>();
        Node data = gObject.GetComponent<Node>();

        data.setTranslation(position);
        data.setRotation(rotation);
        data.setColor(color);
        data.setSecure(secure);
        data.setExit(exit);

        return gObject;
    }

    // This method allow create tokens into the prisons
    void createTokens() {
        Debug.Log("Creating tokens");
        GameObject prisonB = GameObject.Find("PrisonBlue");
        GameObject prisonR = GameObject.Find("PrisonRed");
        GameObject prisonG = GameObject.Find("PrisonGreen");
        GameObject prisonY = GameObject.Find("PrisonYellow");

        for (int i = 0; i < 4; i++) {
            GameObject tokenB = createToken("Token" + colors[0] + (i + 1), prisonB.GetComponent<Node>(), colors[0], "", prisonB.transform);
            prisonB.GetComponent<Node>().addPrisonToken(tokenB);
            GameObject tokenR = createToken("Token" + colors[1] + (i + 1), prisonR.GetComponent<Node>(), colors[1], "", prisonR.transform);
            prisonR.GetComponent<Node>().addPrisonToken(tokenR);
            GameObject tokenG = createToken("Token" + colors[2] + (i + 1), prisonG.GetComponent<Node>(), colors[2], "", prisonG.transform);
            prisonG.GetComponent<Node>().addPrisonToken(tokenG);
            GameObject tokenY = createToken("Token" + colors[3] + (i + 1), prisonY.GetComponent<Node>(), colors[3], "", prisonY.transform);
            prisonY.GetComponent<Node>().addPrisonToken(tokenY);
            Debug.Log(i);
        }
    }

    // This method create a token to play
    GameObject createToken(string name, Node node, string color, string model, Transform parent) {
        GameObject token = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        token.transform.SetParent(parent);
        token.transform.Rotate(new Vector3());
        token.transform.Translate(new Vector3());
        token.transform.localScale = new Vector3(0.53f, 0.53f, 0.53f);
        token.name = name;
        token.GetComponent<Renderer>().material.color = Color.black;

        token.AddComponent(typeof(Token));
        Token data = token.GetComponent<Token>();

        data.color = color;
        data.model = model;

        return token;
    }
}



