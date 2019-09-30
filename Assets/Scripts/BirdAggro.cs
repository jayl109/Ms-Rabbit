using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAggro : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bird is diving!!");
            transform.parent.gameObject.GetComponent<BirdScript>().Dive();

        }
    }
}
