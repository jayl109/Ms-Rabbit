using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touched tree!");
            collision.transform.GetComponent<Player>().Die();
            GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().Died();
        }
    }
}
