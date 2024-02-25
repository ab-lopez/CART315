using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public GameObject asteroidToSpawn, enemyToSpawn;
    public int asteroidCounter, enemyCounter;
    public List<GameObject> asteroids = new List<GameObject>(); // asteroid list

    ShipController sC;
    
    private List<GameObject> asteroidsToRemove = new List<GameObject>();   // temp asteroid destroy list, lists asteroids that need to be destroyed
    private List<GameObject> enemies = new List<GameObject>(); // enemy list
    private List<GameObject> enemiesToRemove = new List<GameObject>();   // temp enemy destroy list, lists enemies that need to be destroyed

    private float asteroidYPosition, enemyYPosition;
    private Vector3 asteroidSpawnPosition, enemySpawnPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        setAsteroidPosition();
        setEnemyPosition();
        asteroidCounter = 0;
        enemyCounter = 0;

        GameObject obj = GameObject.Find("Ship");
        sC = obj.GetComponent<ShipController>();

    }

    // Update is called once per frame
    void Update()
    {
        spawnAsteroid();

        foreach(GameObject asteroid in asteroids){
            
            if(asteroid == null)
            {
                // check that Destroy hasn't already been called on this object
                continue;
            }

            if (asteroid.transform.position.x <= -9f){ // delete
                asteroidsToRemove.Add(asteroid); // add to temporary list for removal
                destroyAsteroid(asteroid);
            }

        }

        foreach(GameObject asteroid in asteroidsToRemove){
            asteroids.Remove(asteroid); // Go through temp asteroidsToRemove list, remove those asteroids from OG list
        }

        asteroidsToRemove.Clear(); // Clear list after removal



        spawnEnemy();

        foreach(GameObject enemy in enemies){
            
            if(enemy == null)
            {
                // check that Destroy hasn't already been called on this object
                continue;
            }

            if (enemy.transform.position.x <= -9f){ // delete
                enemiesToRemove.Add(enemy); // add to temporary list for removal
                destroyEnemy(enemy);
            }

        }

        foreach(GameObject enemy in enemiesToRemove){
            enemies.Remove(enemy); // Go through temp asteroidsToRemove list, remove those asteroids from OG list
        }

        enemiesToRemove.Clear(); // Clear list after removal

        


    }

    void setAsteroidPosition(){
        asteroidYPosition = Random.Range(-4.5f, 4.5f);
        asteroidSpawnPosition = new Vector3(10, asteroidYPosition, 0);
        transform.position = asteroidSpawnPosition;
        Debug.Log("set");
    }

       void setEnemyPosition(){
        enemyYPosition = Random.Range(-4.5f, 4.5f);
        enemySpawnPosition = new Vector3(10, enemyYPosition, 0);
        transform.position = enemySpawnPosition;
        Debug.Log("set");
    }

    void spawnAsteroid(){
    
        if(asteroidCounter <= 1){
            Debug.Log("spawn");
            GameObject asteroid = Instantiate(asteroidToSpawn, transform.position, Quaternion.identity);
            asteroids.Add(asteroid);
            asteroidCounter++;
            setAsteroidPosition();
        }
    }

      void spawnEnemy(){
    
        if(enemyCounter <= 1){
            Debug.Log("spawn");
            GameObject enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            enemies.Add(enemy);
            enemyCounter++;
            setEnemyPosition();
        }
    }

    public void destroyAsteroid(GameObject asteroid){
        Destroy(asteroid);
        setAsteroidPosition();
        asteroidCounter--;
    }
    public void destroyEnemy(GameObject enemy){
        Destroy(enemy);
        setEnemyPosition();
        enemyCounter--;

        if(sC != null){
            int randomLoot = UnityEngine.Random.Range(0, 4);
            sC.addBullets(randomLoot);
        }
    }
}
