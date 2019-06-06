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

    // Use this for initialization
    void Start() {
        diceGUI1 = GameObject.Find("DiceGUI1");
        diceGUI2 = GameObject.Find("DiceGUI2");
    }

    // Update is called once per frame
    void Update() {
        dice1 = GameObject.Find("Dice1").GetComponent<Dice>().getValue();
        dice2 = GameObject.Find("Dice2").GetComponent<Dice>().getValue();
        diceGUI1.GetComponent<RawImage>().texture = textures[dice1];
        diceGUI2.GetComponent<RawImage>().texture = textures[dice2];
    }

    public void selectLeft() {

    }
    public void selectRight() {

    }

    public int selectToken() {
        return 0;
    }

    public void selectDiceRight() {

    }

    public void selectDiceLeft() {

    }

    public int selectDice(){
        return 0;
    }
}