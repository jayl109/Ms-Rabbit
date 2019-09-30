using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    // public GameObject scoreText;
    private float finalScore = 0;
    #region Unity_Functions
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
    }

    #endregion

    #region Scene_Transitions
    public void LoseGame()
    {;
        GameObject go = GameObject.FindWithTag("ScoreCounter");
        finalScore = Mathf.Floor(go.GetComponent<ScoreCounter>().curScore());
        SceneManager.LoadScene("EndScene");
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameObject.FindWithTag("FinalScore").GetComponent<Text>().text = "Final Score: " + finalScore;

    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    #endregion
}
