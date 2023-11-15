using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continue_luncher_timer_script : MonoBehaviour
{
    //fireball
    public float interval_time = 2;
    public float t = 0;
    public bool shot_ok = true;
    //eddy
    public float water_eddy_continued_time = 10;
    public float t1 = 0;
    public bool water_eddy_end = false;
    public float t2 = 0;
    public float water_eddy_cd = 5;
    public bool water_eddy_ok = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fireball
        if (!shot_ok) 
        {
            t += Time.deltaTime; 
        }
        
        if(t> interval_time) 
        {
            shot_ok=true;
            t = 0;
        }
        //water_eddy
        if(!water_eddy_ok&&!water_eddy_end)
        {
            t1 += Time.deltaTime;
        }
        if( t1 >= water_eddy_continued_time)
        {
            
            water_eddy_ok=false;
            water_eddy_end=true;
            t1 = 0;
        }
        if(water_eddy_end)
        {
            t2 += Time.deltaTime;
        }
        if(t2>= water_eddy_cd)
        {
            t2 = 0;
            water_eddy_end = false;
            water_eddy_ok = true;
        }

    }
}
