using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    GameObject diceGUI1;
    GameObject diceGUI2;
    int dice1;
    int dice2;
    public Texture[] textures = new Texture[7];
    public GameObject[] tokens;
    int indToken;
    int indDice;
    public GameObject selector;

    // Use this for initialization
    void Start() {
        diceGUI1 = GameObject.Find("DiceGUI1");
        diceGUI2 = GameObject.Find("DiceGUI2");
        indToken = 0;
        indDice = 0;
    }

    // Update is called once per frame
    void Update() {
        dice1 = GameObject.Find("Dice1").GetComponent<Dice>().getValue();
        dice2 = GameObject.Find("Dice2").GetComponent<Dice>().getValue();
        diceGUI1.GetComponent<RawImage>().texture = textures[dice1];
        diceGUI2.GetComponent<RawImage>().texture = textures[dice2];
    }

    public void loadTokens(GameObject[] tokens) {
        this.tokens = tokens;

        if (!GameObject.Find("SelectParticle(Clone)")) {
            Debug.Log("Creando particulas: ");
            GameObject go = GameObject.Instantiate(selector);
            go.transform.SetParent(tokens[indToken].transform);
            go.transform.localPosition = Vector3.zero;
        }
    }

    public void selectLeft() {
        Destroy(GameObject.Find("SelectParticle(Clone)"));

        indToken--;

        if (indToken < 0) {
            indToken = 3;
        }

        Debug.Log(indToken);
    }

    public void selectRight() {
        Destroy(GameObject.Find("SelectParticle(Clone)"));

        Debug.Log("last:  " + indToken);

        indToken++;

        if (indToken > 3) {
            indToken = 0;
        }

        Debug.Log(indToken);
    }

    public int selectToken() {
        return indToken;
    }

    public void selectDiceRight() {

    }

    public void selectDiceLeft() {

    }

    public int selectDice() {
        return 0;
    }
}