using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public float boostAmountDividedBy2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Heart Boost!");
           
            GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().Boost(boostAmountDividedBy2);
            Destroy(this.gameObject);
        }
    }
}
