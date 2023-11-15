using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_water_eddy_viewer : MonoBehaviour
{
    GameObject clt;

    public Text Watereddy_timer;
    // Start is called before the first frame update
    void Start()
    {
        clt = GameObject.Find("continue_luncher_timer");
    }

    // Update is called once per frame
    void Update()
    {
       if(clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok)
        {
            Watereddy_timer.text = "Ready";
        }       
        if(clt.GetComponent<continue_luncher_timer_script>().water_eddy_end&&!clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok)
        {
            Watereddy_timer.text = "OFF:" + (clt.GetComponent<continue_luncher_timer_script>().water_eddy_cd - clt.GetComponent<continue_luncher_timer_script>().t2);
        }
        if(!clt.GetComponent<continue_luncher_timer_script>().water_eddy_ok&& !clt.GetComponent<continue_luncher_timer_script>().water_eddy_end)
        {
            Watereddy_timer.text = "ON:" + (clt.GetComponent<continue_luncher_timer_script>().water_eddy_continued_time - clt.GetComponent<continue_luncher_timer_script>().t1);
        }

    }
}
