using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    public GameObject evilBulletToSpawn;
    private float timer = 0.0f;
    private float interval;


   [SerializeField]

    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        randomizeTime();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // keep moving to the left
        timer += Time.deltaTime;

        if(timer >= interval){ 
            Debug.Log("shot");
            Shoot();

            timer = 0.0f; // reset timer
            randomizeTime();
        }

    }

    void Shoot(){
        GameObject bullet = Instantiate(evilBulletToSpawn, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }

    void randomizeTime(){
        interval = UnityEngine.Random.Range(1f, 5f);
    }

}
