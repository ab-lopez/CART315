using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (speed) * Time.deltaTime); // keep moving to the right
       
    // Past a certain point, delete bullet
        if (transform.position.x >= 7f){ 
            Destroy(gameObject, 4);
        }
    }


    void OnCollisionEnter2D(Collision2D other){
         MobManager mobManager = FindObjectOfType<MobManager>(); // Find the MobManager instance

        if (mobManager != null && other.gameObject.tag == "Asteroid") { // Ensure the collided object is an asteroid
            mobManager.destroyAsteroid(other.gameObject); // Let MobManager handle the destruction
        }
        else if (mobManager != null && other.gameObject.tag == "Enemy"){
            mobManager.destroyEnemy(other.gameObject); // Let MobManager handle the destruction
        }

        Destroy(gameObject); // Destroy the bullet object (if needed)
    }
}
