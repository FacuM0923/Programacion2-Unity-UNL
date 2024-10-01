using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject GameOverPanel;

    public void ShowGameOver(){
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);

    }

    public void ResetLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
