using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private void Awake() {
        int instanceCount = FindObjectsOfType<ScoreKeeper>().Length;
        if (instanceCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    int score;

    public int GetScore() {
        return score;
    }

    public void SetScore(int score) {
        this.score += score;
        Debug.Log(this.score);
    } 

    public void ResetScore() {
        score = 0;
    }
}
