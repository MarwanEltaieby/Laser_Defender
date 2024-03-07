using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    ScoreKeeper scoreKeeper;
    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start() {
        scoreText.text = scoreKeeper.GetScore().ToString();    
    }

}
