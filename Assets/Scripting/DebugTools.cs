using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour {

    public bool DebugMode;
    bool debugged;

    // Use this for initialization
    void Start() {
        debugged = false;
    }

    // Update is called once per frame
    void Update() {
        if (debugged) {
            createDebugView();
        }
    }

    void createDebugView() {
        Debug.Log("DEBUG PROJECT MODE ON, EXECUTING DEBUG TASK");

        GameObject.Find("MallaTestVisual").SetActive(false);

        GameObject camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(-15f, 27.9f, -10);
        camera.transform.Rotate(new Vector3(59f, 60f, 0f));

        Debug.Log("Creation debug fixed objects");

        foreach (Transform child in GameObject.Find("Nodes").transform) {
            debugged = true;
            GameObject debugOBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);
            debugOBJ.transform.SetParent(child);
            debugOBJ.name = "debugBox";
            debugOBJ.transform.localPosition = new Vector3(0, 0, 0);
            debugOBJ.transform.localRotation = new Quaternion(0, 0, 0, 0);
            debugOBJ.transform.localScale = new Vector3(3.95f, 0.04f, 0.97f);
        }
    }

}
