using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadScene(1);
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper == null) {return;}
        scoreKeeper.ResetScore();
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad(2, 2f));
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    } 

    public void QuiteGame() {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
