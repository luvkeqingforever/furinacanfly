using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


    public class player_status : MonoBehaviour
    {
    
    public int skill_offet = 2; 
    public GameObject fireball;
        float horizon;
        float vertical;
        float speed = 4;
    bool fire_ball = true;
    bool water_eddy = true;
    public bool water_eddy_on = false;
    /*float maxdistance = 5;
    float mindistance = 0;
    float distance_of_enemy;*/
    GameObject clt;
        // Start is called before the first frame update
        void Start()
        {
        clt = GameObject.Find("continue_luncher_timer");
    }

    // Update is called once per frame
    void Update()
    {
        horizon = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;
        transform.Translate(horizon * Time.deltaTime, vertical * Time.deltaTime, 0);

        Vector3 vec = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        vec.Normalize();
        float f = (float)(Mathf.Atan(vec.y / vec.x) / Mathf.PI * 180) - 90;
        if (vec.x < 0)
        {
            f -= 180;
        }
        transform.rotation = Quaternion.Euler(0, 0, (float)(f));
        if (fire_ball) 
        {
            skill_fire_ball(f);
        }
        if(water_eddy) 
        {
            skill_water_eddy();
        }
     
        }
    void skill_fire_ball(float f)
    {
        //ÂI®g
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            float x = Mathf.Cos((f + 90) / 180 * Mathf.PI) * skill_offet;
            float y = Mathf.Sin((f + 90) / 180 * Mathf.PI) * skill_offet;
            //Debug.Log ((f+90) + " , " + x + " , "+y);
            Instantiate(fireball, new Vector2(x + transform.position.x, y + transform.position.y), this.transform.rotation);
        }*/


        //³s®g
        if (Input.GetKey(KeyCode.E) && clt.GetComponent<continue_luncher_timer_script>().shot_ok)
        {
            float x = Mathf.Cos((f + 90) / 180 * Mathf.PI) * skill_offet;
            float y = Mathf.Sin((f + 90) / 180 * Mathf.PI) * skill_offet;
            //Debug.Log ((f+90) + " , " + x + " , "+y);
            Instantiate(fireball, new Vector2(x + transform.position.x, y + transform.position.y), this.transform.rotation);
            clt.GetComponent<continue_luncher_timer_script>().shot_ok = false;
        }
    }
    void skill_water_eddy()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok) 
        {
            water_eddy_on = true;
            clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok = false;
        }
    }
    }

