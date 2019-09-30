using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    public GameObject scoreText;

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
        float temp = Mathf.Floor(go.GetComponent<ScoreCounter>().curScore());
        SceneManager.LoadScene("EndScene");
        scoreText.GetComponent<FinalScore>().text = "Final Score: " + temp);

        Destroy(go);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    #endregion
}
