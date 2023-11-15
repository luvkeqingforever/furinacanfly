using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_Attack : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Circle (1)");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hehe");
        if (collision.gameObject.tag == "Enemy")
        {
          //  Debug.Log("hehehe");
            collision.gameObject.GetComponent<Enemy_status>().HP -= 10;

        }
    }
    

}
