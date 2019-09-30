using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
	public Player player;
	private float moveAt;
	// public int incrementSpawn; // What to increment spawnAt by.
    public float groundLen;
    //prefab to spawn 2nd ground
	public GameObject groundprefab;
	public GameObject birdPrefab;
	private float birdY = 2.82f;
	//initial ground player is on is set, generate the other 2
	public GameObject ground;
	private GameObject ground2;
	private GameObject ground3;

	public GameObject skyPrefab;
	public GameObject sky;
	private GameObject sky2; 
	private GameObject sky3;

	private GameObject sky4; 
	private GameObject sky5; 
	private GameObject sky6;

	public GameObject tree;
    public GameObject heart;

	private float skyHeight = 4f;
    public float skyY;
	public float treeY = 1.13f;
	private float spawnTreeAt = 0f;
    public float spawnHeartAt = 5f;
    private float spawnHeartCooldown = 5f;
	private float spawnTreeCooldown = 10f;

	private bool spawnTree = true;

    // Start is called before the first frame update
    void Start()
    {
    	moveAt = (groundLen * 1.1f);
    	//Debug.Log("moveAt: " + moveAt);

    	ground2 = Instantiate(groundprefab, new Vector3(ground.transform.position.x + groundLen, 0, 0), Quaternion.identity);
    	ground3 = Instantiate(groundprefab, new Vector3(ground.transform.position.x + groundLen + groundLen, 0, 0), Quaternion.identity);

    	sky2 = Instantiate(skyPrefab, new Vector3(sky.transform.position.x + groundLen, skyY, 0), Quaternion.identity);
    	sky3 = Instantiate(skyPrefab, new Vector3(sky.transform.position.x + groundLen * 2, skyY, 0), Quaternion.identity);

    	sky4 = Instantiate(skyPrefab, new Vector3(sky.transform.position.x, skyY + skyHeight, 0), Quaternion.identity);
    	sky5 = Instantiate(skyPrefab, new Vector3(sky4.transform.position.x + groundLen, sky4.transform.position.y, 0), Quaternion.identity);
    	sky6 = Instantiate(skyPrefab, new Vector3(sky4.transform.position.x + groundLen * 2, sky4.transform.position.y, 0), Quaternion.identity);

    }
    
    void moveGroundAndSky() {
    	ground.transform.Translate(groundLen * 3, 0,0);
    	GameObject temp3 = ground3;
    	GameObject temp2 = ground2;
    	ground3=ground;
    	ground2 = temp3;
    	ground = temp2; 

    	sky.transform.Translate(groundLen * 3, 0,0);
    	temp3 = sky3;
    	temp2 = sky2;
    	sky3 = sky;
    	sky2 = temp3;
    	sky = temp2; 

    	//move the upper layer of sky too
    	sky4.transform.Translate(groundLen * 3, 0,0);
    	temp3 = sky6;
    	temp2 = sky5;
    	sky6 = sky4;
    	sky5 = temp3;
    	sky4 = temp2; 
    }
    void SpawnTree() {
    	//Debug.Log("spawn tree");
		float spawnTreeDist = Random.Range(0,2);
		GameObject spawned = Instantiate(tree, new Vector3(spawnTreeAt+spawnTreeDist+10, treeY, 0), Quaternion.identity);
		spawned.transform.position = new Vector3(spawnTreeAt+spawnTreeDist+10, treeY, 0);
		//Debug.Log("final spawn pos: " + (spawnTreeAt+spawnTreeDist+10) + "spawn tree at: " + spawnTreeAt + "spawn tree dist at :" + spawnTreeDist);

		//Debug.Log(spawned.transform.position);
    }
    void SpawnBird() {
    	//Debug.Log("spawn bird");
    	//too hard to make it not impossible
		float spawnBirdDist = Random.Range(0,5);
		GameObject spawned = Instantiate(birdPrefab, new Vector3(spawnTreeAt+spawnBirdDist+30, birdY, 0), Quaternion.identity);
		spawned.transform.position = new Vector3(spawnTreeAt+spawnBirdDist+30, birdY, 0);
		//Debug.Log("final spawn pos: " + (spawnTreeAt+spawnBirdDist+10) + "spawn bird at: " + spawnTreeAt + "spawn bird dist at :" + spawnBirdDist);

		//Debug.Log(spawned.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
    	//spawn ground
    	if (player.transform.position.x > moveAt) {
    		//Debug.Log("move ground");
    		moveGroundAndSky();
    		
            moveAt += groundLen; 
    	}

    	if (player.transform.position.x > spawnTreeAt) {
    		// float treeOrBird = Random.Range(0,4);
			spawnTreeAt += spawnTreeCooldown;
			if (spawnTree) {
				SpawnTree();
			} else {
				SpawnBird();
			}
			spawnTree = !spawnTree;

    		

    	}

        if (player.transform.position.x > spawnHeartAt)
        {
            Debug.Log("spawn heart");
            
            spawnHeartAt += spawnHeartCooldown;
            float spawnHeartDist = Random.Range(0, 4);
            float heartY = Random.Range(1, 2f);
            GameObject spawned = Instantiate(heart, new Vector3(spawnHeartAt + spawnHeartDist + 10, heartY, 0), Quaternion.identity);
            spawned.transform.position = new Vector3(spawnHeartAt + spawnHeartDist + 10, heartY, 0);
            Debug.Log("final spawn pos: " + (spawnHeartAt + spawnHeartDist + 10) + "spawn heart at: " + spawnHeartAt + "spawn heart dist at :" + spawnHeartDist);

            Debug.Log(spawned.transform.position);

        }
        
        // if (player.transform.position.x > 15) {
        // Debug.Log(player.transform.position.x);

        // }

        // Debug.Log(player.transform.position.x);

    }
}
