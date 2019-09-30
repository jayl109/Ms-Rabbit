using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    
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
    {
        GameObject go = GameObject.FindWithTag("ScoreCounter");
                Debug.Log("Final Score: " + go);
                    //.GetComponent<ScoreCounter>().curScore());

        DontDestroyOnLoad(go);
        SceneManager.LoadScene("EndScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    #endregion
}
