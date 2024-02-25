using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public MobManager mM;

   [SerializeField]
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // keep moving to the left

    }
}
