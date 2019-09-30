using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	float score;
	public Text scoreText;
	bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
    	isAlive = true;
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    	if (isAlive) {
	        score += Time.deltaTime;
	        scoreText.GetComponent<Text>().text = "Score: " + Mathf.Floor(score);
	    }
    }
    public void Died() {
    	isAlive = false;
        score += Time.deltaTime;

        scoreText.GetComponent<Text>().text = "Final Score: " + Mathf.Floor(score);

    }
    public void Boost(float boostAmount)
    {
        score += boostAmount;
    }
    public float curScore()
    {
        return score;
    }
}
