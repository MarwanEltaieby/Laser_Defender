using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    HealthHandler healthHandler;
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text scoreText;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthHandler>();
    }

    private void Start() {
        healthSlider.maxValue = healthHandler.GetHealth();
    }

    private void Update() {
        healthSlider.value = healthHandler.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
