using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hi
public class Ghost : MonoBehaviour
{
    public float attack_Timer;
    public float bace_time_before_attack;
    public float time_before_attack;
    public bool check_pos;
    public bool count_time_before_attack;
    public bool attacking;
    public bool invisible;
    public int bace_attack_Timer;
    public float appear_Timer;
    public float appear_Time;
    public int time;
    public float speed;
    //float disx;
    //float disy;
    float posx;
    float posy;
    void Attack()
    {


        if (attack_Timer < 0)
        {
            check_pos = false;
            if (count_time_before_attack)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                time_before_attack = bace_time_before_attack;
                count_time_before_attack = false;
            }
            if (time_before_attack < 0)
            {

                if (attacking)
                {
                    //往角色後方一段距離(還沒做
                    //transform.position += new Vector3(disx, disy, 0)*speed*Time.deltaTime;
                    //transform.position += new Vector3(disx, disy, 0)*speed*Time.deltaTime;
                    //transform.localPosition = Vector3.MoveTowards(transform.position, new Vector3(posx, posy, 0), speed * Time.deltaTime);

                }
                attacking = true;

                if (transform.position == new Vector3(posx, posy, 0))
                {
                    attack_Timer = bace_attack_Timer;
                    attacking = false;
                    gameObject.GetComponent<Renderer>().enabled = false;
                    check_pos = true;
                    count_time_before_attack = true;

                }
            }
            else time_before_attack -= Time.deltaTime;
        }
        else attack_Timer -= Time.deltaTime;



    }











    private void Move()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (check_pos)
        {
            posx = GameObject.Find("player").transform.position.x;
            posy = GameObject.Find("player").transform.position.y;
            //disx = GameObject.Find("player").transform.position.x - transform.position.x;
            //disy = GameObject.Find("player").transform.position.y - transform.position.y;
        }
        Attack();
        if (attacking == false) Move();

    }
}
