using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBullet : MonoBehaviour
{
public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (speed) * Time.deltaTime); // keep moving to the right
       
    // Past a certain point, delete bullet
        if (transform.position.x >= -7f){ 
            Destroy(gameObject, 4);
        }
    }


    void OnCollisionEnter2D(Collision2D other){
        Destroy(other.gameObject);
        SceneManager.LoadScene (sceneName:"End Screen");

        Destroy(gameObject); // Destroy the bullet object (if needed)
    }
}
