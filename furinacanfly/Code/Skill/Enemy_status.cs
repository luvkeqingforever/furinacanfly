using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class Enemy_status : MonoBehaviour
{
    public int HP = 100000;
    GameObject player;
    public bool water_eddy_is = false;
    
    
    
    GameObject clt;
    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.Find("Circle (1)");
        clt = GameObject.Find("continue_luncher_timer");
    }

    // Update is called once per frame
    void Update()
    {

        if (water_eddy_is&&!clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok&& !clt.GetComponent<continue_luncher_timer_script>().water_eddy_end)
        {
            
            water_eddy_effect();
        }
       
        water_eddy_is = false;
       
    }
    public void water_eddy_effect()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = Quaternion.Euler(0, 0, 80) * direction;
        float distanceThisFrame = 20 * Time.deltaTime;
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);//space.world ¥i¬Ù²¤


 
    }
}
