using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	private bool diving;
	public float flyingSpeed;
	public float divingSpeed;
	private float stopDivingY = .7f; 
	private float despawnX;

	void Start()
    {
    	diving = false;
    	despawnX = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touched Bird!");
            collision.transform.GetComponent<Player>().Die();
            GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().Died();
        }
    }
    public void Dive() {
    	Debug.Log("rotating");
		transform.eulerAngles = new Vector3(
    			transform.eulerAngles.x,
    			transform.eulerAngles.y,
    			transform.eulerAngles.z+45);   
    	diving = true; 
	}

	private void Update() {
		Debug.Log(transform.position.y);
		if (transform.position.x < despawnX) {
			Destroy(gameObject);
			return;
		}
		if (!diving) {
			if (despawnX == 0) {
				despawnX = transform.position.x-70;
			}
			transform.Translate(Vector2.left * Time.deltaTime*flyingSpeed);
		} else {
			//stop diving
			if (transform.position.y < stopDivingY) {
				Debug.Log("Stop diving");
				diving = false;
				transform.eulerAngles = new Vector3(
								    				transform.eulerAngles.x,
								    				transform.eulerAngles.y,
								    				transform.eulerAngles.z-90
								    				);   

				transform.Translate(Vector2.left * Time.deltaTime*flyingSpeed);
			} else {
				Debug.Log("Keep diving");
				//keep diving
				transform.Translate(new Vector2(-1,0) * Time.deltaTime*divingSpeed);

			}
		}

        

	}
}
