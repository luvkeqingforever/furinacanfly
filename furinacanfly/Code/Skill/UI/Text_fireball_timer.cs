using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_fireball_timer : MonoBehaviour
{
    GameObject clt;
    float time = 0;
    public Text Fireball_timer;
    // Start is called before the first frame update
    void Start()
    {
        clt = GameObject.Find("continue_luncher_timer");
    }

    // Update is called once per frame
    void Update()
    {
        time = clt.GetComponent<continue_luncher_timer_script>().interval_time - clt.GetComponent<continue_luncher_timer_script>().t;
        if (time == clt.GetComponent<continue_luncher_timer_script>().interval_time) 
        {
            Fireball_timer.text = "Ready";
        }
        else
        {
            Fireball_timer.text = ""+time;
        }

    }
}
