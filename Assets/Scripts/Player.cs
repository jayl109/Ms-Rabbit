using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
//  public float movespeed;
//  public float xinput;
//  public float yinput;
    public float walkingSpeed;
    public float jumpforce;
    private float playerY = .597f;
    Rigidbody2D playerRB;
    Animator anim;

    #region UnityFuncs
    //called once on creation
    private void Awake() {
		playerRB = GetComponent<Rigidbody2D>();
        transform.Translate(Vector2.right * Time.deltaTime*walkingSpeed);
        anim = GetComponent<Animator>();
        // GetComponent<Rigidbody2D>().velocity = new Vector2(1, GetComponent<Rigidbody2D>().velocity.y) * walkingSpeed;
	}
	//called once per frame
	private void Update() {
		transform.Translate(Vector2.right * Time.deltaTime*walkingSpeed);

        //Always Moving
        // GetComponent<Rigidbody2D>().velocity = new Vector2(1, GetComponent<Rigidbody2D>().velocity.y) * walkingSpeed;
        
        if (Input.GetKeyDown("space")) {
			Jump();
		}

	}
    #endregion

    public void Die() {
        // 	FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Debug.Log("Dead :(");
	 	Destroy(this.gameObject);
	 	GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManagerScript>().LoseGame();
        
	}

	private void Jump() {
       if (playerRB.transform.position.y <= playerY)
        {
            StartCoroutine(JumpSeq());
        }
        else
        {
            Debug.Log("Cannot Jump");
        }

    }

    IEnumerator JumpSeq()
    {
        Debug.Log("Jumpeddd");
        anim.SetBool("Jumping", true);
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        Vector2 thrust = new Vector2(0, jumpforce);//thrust will be 4 times as strong in the y af it is in the x

        playerRB.AddForce(thrust, ForceMode2D.Force);
        yield return new WaitForSeconds(.1f);
        yield return new WaitUntil(() => (playerRB.transform.position.y <= playerY));
        Debug.Log("jumping is false");
        anim.SetBool("Jumping", false);
    }

	// #region movement_funcs
	// private void Move() {
	// 	// anim.SetBool("Moving", true);
	// 	if (xinput > 0) {
	// 		playerRB.velocity = Vector2.right * movespeed;
	// 		currDirection = Vector2.right;
	// 	}
	// 	else if (xinput < 0) {
	// 		playerRB.velocity = Vector2.left * movespeed;
	// 		currDirection = Vector2.left;

	// 	}
	// 	else if (yinput > 0) {
	// 		playerRB.velocity = Vector2.up * movespeed;
	// 		currDirection = Vector2.up;
	// 	}
	// 	else if (yinput < 0) {
	// 		playerRB.velocity = Vector2.down * movespeed;
	// 		currDirection = Vector2.down;

	// 	}
	// 	else {
	// 		playerRB.velocity = Vector2.zero;
	// 		anim.SetBool("Moving", false);

	// 	}
	// 	anim.SetFloat("DirX", currDirection.x);
	// 	anim.SetFloat("DirY", currDirection.y);

	// }
	// #endregion


	
}
