using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipController : MonoBehaviour
{


    public GameObject bulletToSpawn;
    public int bulletCounter;


    [SerializeField]
    private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-7, 0, 0);
        speed = 4.5f;
        bulletCounter = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = 10f;
            // Debug.Log("speed: " + speed);
        }
        else{
            speed = 4.5f;
        }





        transform.Translate(Vector3.up * verticalMovement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && bulletCounter >= 1){
            Shoot();
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletToSpawn, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        bulletCounter--;
        // Debug.Log("bullets left: " + bulletCounter);
    }

    public void addBullets(int amount){
        bulletCounter += amount; // add three bullets every time funciton is called
        // Debug.Log("bullets left: " + bulletCounter);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Asteroid"){
            Destroy(gameObject);
            SceneManager.LoadScene (sceneName:"End Screen");
        }
        else if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            SceneManager.LoadScene (sceneName:"End Screen");
        }
    }
}
