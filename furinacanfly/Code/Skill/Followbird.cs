using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followbird : MonoBehaviour
{
    GameObject bird;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.Find("Circle (1)");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bird.transform.position.x, bird.transform.position.y, -5);
        
    }
}
