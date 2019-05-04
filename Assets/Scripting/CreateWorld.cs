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

    // Debug mode
    public bool debug = false;

    //Amount nodes in each houses
    string[] colors = new string[] { "Blue", "Red", "Green", "Yellow" };
    int cantStais = 7;
    int cantCurve = 8;
    int cantAsc = 5;
    int cantDes = 4;

    // Position by fixed elements
    Vector3 handsP = new Vector3(10.7f, 9.8f, 10.65f);
    Vector3 witcherP = new Vector3(7.1f, 5.8f, 7.1f);
    Vector3 prisonP = new Vector3(8.95f, 5.13f, 8.6f);
    Vector3 crownP = new Vector3(3.8f, 9.22f, 0f);
    Vector3 start = new Vector3(11.8f, 1.5f, 0f);

    // Reference to mesh nodes
    NodeMesh nodemesh;

    // Defauld Log Debug.Log("CreateWorld.");

    // Use this for initialization
    void Start() {
        Debug.Log("Find Board");
        nodemesh = GameObject.Find("Board").GetComponent<NodeMesh>();

        Debug.Log("Creation fixed objects");
        createFixedPosition();
        createPrisons();
        createCrowns();
        createNodes();
        createGameObjectsNode();
        createTokens();

        if (debug) {
            Debug.Log("Run debug task");
            createDebugView();
        }
    }

    // Update is called once per frame
    void Update() {

    }

    // This method create a fixed positions
    void createFixedPosition() {
        Debug.Log("Creating hands and witchers nodes");
        nodemesh.hands = createMirrorVectors(handsP);
        nodemesh.witchers = createMirrorVectors(witcherP);
    }

    // This method create a prison positions
    void createPrisons() {
        Debug.Log("Creating prisons nodes");
        Vector3[] vectors = createMirrorVectors(prisonP);
        Node[] prisons = new Node[4];

        prisons[0] = new Node(vectors[0], new Vector3(0f, -135f, 0), null, null, colors[0], false, false);
        prisons[1] = new Node(vectors[1], new Vector3(0f, 135f, 0), null, null, colors[1], false, false);
        prisons[2] = new Node(vectors[2], new Vector3(0f, 45f, 0), null, null, colors[2], false, false);
        prisons[3] = new Node(vectors[3], new Vector3(0f, -45f, 0), null, null, colors[3], false, false);

        nodemesh.prisons = prisons;
    }

    // This method create a crowns positions
    void createCrowns() {
        Debug.Log("Creating crowns nodes");
        Vector3[] vectors = createMirrorVectors(prisonP);
        Node[] crowns = new Node[4];

        crowns[0] = new Node(vectors[0], new Vector3(0f, -90f, 0f), null, null, colors[0], false, false);
        crowns[1] = new Node(vectors[1], new Vector3(0f, 180f, 0f), null, null, colors[1], false, false);
        crowns[2] = new Node(vectors[2], new Vector3(0f, 90f, 0f), null, null, colors[2], false, false);
        crowns[3] = new Node(vectors[3], new Vector3(0f, 0f, 0f), null, null, colors[3], false, false);

        nodemesh.crowns = crowns;
    }

    // This methid create a board nodes
    void createNodes() {
        Debug.Log("Creating boards nodes");
        Vector3[] vectors = createRotationVector(start);

        Node rootBlue = new Node(vectors[0], new Vector3(0f, -90f, 0f), null, null, colors[0], true, false);
        Node rootRed = new Node(vectors[1], new Vector3(0f, 180f, 0f), null, null, colors[1], true, false);
        Node rootGreen = new Node(vectors[2], new Vector3(0f, 90f, 0f), null, null, colors[2], true, false);
        Node rootYellow = new Node(vectors[3], new Vector3(0f, 0f, 0f), null, null, colors[3], true, false);

        nodemesh.rootNodes = rootBlue;

        Node nodeB = rootBlue;
        Node nodeR = rootRed;
        Node nodeG = rootGreen;
        Node nodeY = rootYellow;

        Debug.Log("Creating ladder from root nodes");
        vectors[0].z = vectors[0].z + 3.95f;
        vectors = createRotationVector(vectors[0]);

        for (int i = 0; i < 4; i++) {
            Node nodeBT = new Node(new Vector3(vectors[0].x - i, vectors[0].y + i, vectors[0].z), new Vector3(0f, -90f, 0f), null, null, colors[0], false, false);
            Node nodeRT = new Node(new Vector3(vectors[1].x, vectors[1].y + i, vectors[1].z - i), new Vector3(0f, 180f, 0f), null, null, colors[1], false, false);
            Node nodeGT = new Node(new Vector3(vectors[2].x + i, vectors[2].y + i, vectors[2].z), new Vector3(0f, 90f, 0f), null, null, colors[2], false, false);
            Node nodeYT = new Node(new Vector3(vectors[3].x, vectors[3].y + i, vectors[3].z + i), new Vector3(0f, 0f, 0f), null, null, colors[3], false, false);

            nodeB.nextNode = nodeBT;
            nodeR.nextNode = nodeRT;
            nodeG.nextNode = nodeGT;
            nodeY.nextNode = nodeYT;

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;
            Debug.Log(i);
        }

        Debug.Log("Creating curve nodes from ladder");
        vectors = createRotationVector(new Vector3(nodeB.position.x - 1, nodeB.position.y + 1, nodeB.position.z));

        float spaceXCurve = 3.9f / 7;
        float spaceZCurve = 3.85f / 7;
        float angule = 90 / 8;
        float factor = 0;

        for (int i = 0; i < 8; i++) {
            Node nodeBT = new Node(new Vector3(vectors[0].x - ((spaceXCurve * i) + (spaceXCurve * factor)), vectors[0].y, vectors[0].z + ((spaceZCurve * i) - (spaceZCurve * factor))), new Vector3(0f, (-90 + i * angule), 0f), null, null, colors[0], false, false);
            Node nodeRT = new Node(new Vector3(vectors[1].x - ((spaceXCurve * i) - (spaceXCurve * factor)), vectors[1].y, vectors[1].z - ((spaceZCurve * i) + (spaceZCurve * factor))), new Vector3(0f, (-180 + i * angule), 0f), null, null, colors[1], false, false);
            Node nodeGT = new Node(new Vector3(vectors[2].x + ((spaceXCurve * i) + (spaceXCurve * factor)), vectors[2].y, vectors[2].z - ((spaceZCurve * i) - (spaceZCurve * factor))), new Vector3(0f, (90 + i * angule), 0f), null, null, colors[2], false, false);
            Node nodeYT = new Node(new Vector3(vectors[3].x + ((spaceXCurve * i) - (spaceXCurve * factor)), vectors[3].y, vectors[3].z + ((spaceZCurve * i) + (spaceZCurve * factor))), new Vector3(0f, (0 + i * angule), 0f), null, null, colors[3], false, false);

            if (i < 3) {
                factor += 0.7f;
            } else if (i >= 4) {
                factor -= 0.7f;
            }

            nodeB.nextNode = nodeBT;
            nodeR.nextNode = nodeRT;
            nodeG.nextNode = nodeGT;
            nodeY.nextNode = nodeYT;

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;

            Debug.Log(i);
        }

        Debug.Log("Creating ladders nodes from curve");
        vectors = createRotationVector(new Vector3(nodeB.position.x, nodeB.position.y - 1, nodeB.position.z + 1));

        for (int i = 0; i < 4; i++) {
            Node nodeBT = new Node(new Vector3(vectors[0].x, vectors[0].y - i, vectors[0].z + i), new Vector3(0f, 0f, 0f), null, null, colors[0], false, false);
            Node nodeRT = new Node(new Vector3(vectors[1].x - i, vectors[1].y - i, vectors[1].z), new Vector3(0f, 270f, 0f), null, null, colors[1], false, false);
            Node nodeGT = new Node(new Vector3(vectors[2].x, vectors[2].y - i, vectors[2].z - i), new Vector3(0f, 180f, 0f), null, null, colors[2], false, false);
            Node nodeYT = new Node(new Vector3(vectors[3].x + i, vectors[3].y - i, vectors[3].z), new Vector3(0f, 90f, 0f), null, null, colors[3], false, false);

            nodeB.nextNode = nodeBT;
            nodeR.nextNode = nodeRT;
            nodeG.nextNode = nodeGT;
            nodeY.nextNode = nodeYT;

            nodeB = nodeBT;
            nodeR = nodeRT;
            nodeG = nodeGT;
            nodeY = nodeYT;

            Debug.Log(i);
        }

        Debug.Log("Creating staircase to the crowns");
        nodeB.nextNode = rootRed;
        nodeR.nextNode = rootGreen;
        nodeG.nextNode = rootYellow;
        nodeY.nextNode = rootBlue;

        vectors = createRotationVector(new Vector3(start.x - 1, start.y + 1, start.z));

        for (int i = 0; i < 7; i++) {
            Node nodeBT = new Node(new Vector3(vectors[0].x - i, vectors[0].y + i, vectors[0].z), new Vector3(0f, -90f, 0f), null, null, colors[0], false, false);
            Node nodeRT = new Node(new Vector3(vectors[1].x, vectors[1].y + i, vectors[1].z - i), new Vector3(0f, 180f, 0f), null, null, colors[1], false, false);
            Node nodeGT = new Node(new Vector3(vectors[2].x + i, vectors[2].y + i, vectors[2].z), new Vector3(0f, 90f, 0f), null, null, colors[2], false, false);
            Node nodeYT = new Node(new Vector3(vectors[3].x, vectors[3].y + i, vectors[3].z + i), new Vector3(0f, 0f, 0f), null, null, colors[3], false, false);

            if (i == 0) {
                rootBlue.extraNode = nodeBT;
                rootRed.extraNode = nodeRT;
                rootGreen.extraNode = nodeGT;
                rootYellow.extraNode = nodeYT;

                nodeB = rootBlue.extraNode;
                nodeR = rootRed.extraNode;
                nodeG = rootGreen.extraNode;
                nodeY = rootYellow.extraNode;
            } else {
                nodeB.nextNode = nodeBT;
                nodeR.nextNode = nodeRT;
                nodeG.nextNode = nodeGT;
                nodeY.nextNode = nodeYT;

                nodeB = nodeBT;
                nodeR = nodeRT;
                nodeG = nodeGT;
                nodeY = nodeYT;
            }

            Debug.Log(i);
        }
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

    // This method create empty GameObjects in the nodes positions
    void createGameObjectsNode() {
        Debug.Log("Creating empty GameObjects according to nodes");

        GameObject nodes = GameObject.Find("Nodes");

        float angule = 225;
        Debug.Log("Creating fixed nodes (Hands and Witchers)");
        for (int i = 0; i < 4; i++) {
            GameObject hand = createEGO("Hands-" + colors[i], nodemesh.hands[i], new Vector3(0, angule, 0), nodes.transform);
            GameObject witcher = createEGO("Witcher-" + colors[i], nodemesh.witchers[i], new Vector3(0, angule, 0), nodes.transform);
            GameObject prison = createEGO("Prison-" + colors[i], nodemesh.prisons[i].position, new Vector3(0, angule, 0), nodes.transform);
            GameObject crown = createEGO("Crown-" + colors[i], nodemesh.crowns[i].position, new Vector3(0, angule, 0), nodes.transform);
            angule -= 90;

            Debug.Log(i);
        }

        Debug.Log("Creating empty GameObject nodes and extranodes position");
        Node node = nodemesh.rootNodes;

        int count = 1;
        while (true) {
            bool finish = false;
            if (nodemesh.isLap(node.nextNode)) {
                finish = true;
            }
            GameObject nodeGO = createEGO("Node: " + node.color + count, node.position, node.rotation, nodes.transform);
            if (node.extraNode != null) {
                Debug.Log("Creating Extra Nodes");
                Node extra = node.extraNode;
                while (true) {
                    bool finish2 = false;
                    if (extra.nextNode == null) {
                        finish2 = true;
                    }
                    GameObject nodeGOEX = createEGO("NodeExtra: " + extra.color + "-" + count, extra.position, extra.rotation, nodes.transform);
                    extra = extra.nextNode;
                    if (finish2) {
                        break;
                    }
                }
            }
            node = node.nextNode;
            count++;
            Debug.Log(count);
            if (finish) {
                Debug.Log("Stopping method to create EGB");
                break;
            }
        }
    }

    // This methos allow create a empty GameObject
    GameObject createEGO(string name, Vector3 position, Vector3 rotation, Transform parent) {
        GameObject gObject = new GameObject();
        gObject.name = name;
        gObject.transform.SetParent(parent);
        gObject.transform.Translate(position);
        gObject.transform.Rotate(rotation);
        gObject.AddComponent(typeof(Node));

        return gObject;
    }

    void createTokens() {
        Debug.Log("Creating tokens");
        GameObject prisonB = GameObject.Find("Prison-Blue");
        GameObject prisonR = GameObject.Find("Prison-Red");
        GameObject prisonG = GameObject.Find("Prison-Green");
        GameObject prisonY = GameObject.Find("Prison-Yellow");

        for (int i = 0; i < 4; i++) {
            GameObject tokenB = createToken(colors[0] + (i + 1), prisonB.GetComponent<Node>(), colors[0], "", prisonB.transform);
            GameObject tokenR = createToken(colors[1] + (i + 1), prisonR.GetComponent<Node>(), colors[1], "", prisonR.transform);
            GameObject tokenG = createToken(colors[2] + (i + 1), prisonG.GetComponent<Node>(), colors[2], "", prisonG.transform);
            GameObject tokenY = createToken(colors[3] + (i + 1), prisonY.GetComponent<Node>(), colors[3], "", prisonY.transform);

            Debug.Log(i);
        }
    }

    GameObject createToken(string name, Node node, string color, string model, Transform parent) {
        GameObject token = new GameObject();
        token.name = name;
        token.AddComponent(typeof(Token));

        Token data = token.GetComponent<Token>();
        data.color = color;
        // data.nodeAttach = node;
        data.model = model;

        token.transform.SetParent(parent);
        token.transform.Rotate(new Vector3());
        token.transform.Translate(new Vector3());

        return token;
    }




    /* 
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
    ---------------------------------DEBUG ZONE-------------------------------------------------
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
    */

    // This method contains debug tasks only executable if debug is True
    void createDebugView() {
        Debug.Log("DEBUG PROJECT MODE ON, EXECUTING DEBUG TASK");

        GameObject.Find("MallaTestVisual").SetActive(false);
        GameObject.Find("Terrain").SetActive(false);

        GameObject camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(0f, 30f, 0);
        camera.transform.Rotate(new Vector3(90f, 0f, 0f));

        GameObject debugMesh = new GameObject();
        debugMesh.name = "DebugMesh";
        debugMesh.transform.SetParent(GameObject.Find("Root").transform);

        Debug.Log("Creation debug fixed objects");

        foreach (Transform child in GameObject.Find("Nodes").transform) {
            GameObject debugOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            debugOBJ.transform.SetParent(child);
            debugOBJ.name = "debugBox";
            debugOBJ.transform.localPosition = new Vector3(0, 0, 0);
            debugOBJ.transform.localRotation = new Quaternion(0, 0, 0, 0);
            debugOBJ.transform.localScale = new Vector3(3.95f, 0.04f, 0.97f);
        }

        Debug.Log(nodemesh.report());
    }

}



