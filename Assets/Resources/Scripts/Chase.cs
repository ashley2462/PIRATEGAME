using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    //the enemy will know the distance of the player from the enemy
    public Transform player;
    //all objects tagged enemy applies to this code
    public GameObject[] Enemy;
	// Use this for initialization
	void Start () {
        //establishing the variable Enemy is all gameobjects tagged Enemy
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        // loop to detect all objects tagged "Enemy"
       for( int i= 0; i < Enemy.Length; i++)
        {
//Test the distance between the player's position and the enemy position.
		if(Vector3.Distance(player.position, Enemy[i].transform.position) < 20)
        {//Works out the direction of the player 
            Vector3 direction = player.position - Enemy[i].transform.position;
            direction.y = 0;
                //follows the player's direction by looking at where they are going
                Enemy[i].transform.rotation = Quaternion.Slerp(Enemy[i].transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                //if greater than the distance calculated is greater then 50, translate the enemy in the forward position 
                //magnitude is length of a vector
                if (direction.magnitude > 10)
            {
                    Enemy[i].transform.Translate(0, 0, 0.05f);
            }
        }
        
        }
	}
}