using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hi

public class SlimeMovement : MonoBehaviour
{
    public enum Status { idle, walk, attack, chase, died };
    public Status status;
    public bool isFaceRight;
    public float IdleTimeMax = 5;
    public float IdleTimeMin= 3;
    float IdleTime;
    public float WalkTimeMax = 1;
    public float WalkTimeMin = 0.5f;
    public float WalkTime;
    public float WalkDisX;
    public float WalkDisY;
    public float WalkSpeed = 0.5f;

    public float speed = 1.5f;
    public Transform myTransform;
    public Transform playerTransform;
    public float distance;
    public float DisChase = 10;
    public float disX;
    public float disY;

    public float AngryLevel;
    public float VecX ;
    public float VecY ;
    public float AttackTime;
    public float AttackTimeCheck;
    public float TargetDisX;
    public float TargetDisY;
    public float Gravity = 20;
    public double theta;
    public float YGap = 2;
    public float AttackDelay = 0.2f;
    public float AttackDelayCheck;
    public float JumpTime = 3;
    public GameObject SplitSlime;
    public float SplitGap;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        status = Status.idle;
        AngryLevel = 0;
        WalkDisX = Random.Range(-1f, 1f);
        WalkDisY = Random.Range(-1f, 1f);

        if (this.transform.GetComponent<SpriteRenderer>().flipX)
        {
            isFaceRight = false;
        }
        else
        {
            isFaceRight = true;
        }
}

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.Find("player").transform;
        disX = playerTransform.transform.position.x - myTransform.position.x;
        disY = playerTransform.transform.position.y - myTransform.position.y;
        distance = Mathf.Sqrt(Mathf.Abs(playerTransform.transform.position.x - myTransform.position.x) * Mathf.Abs(playerTransform.transform.position.x - myTransform.position.x) + Mathf.Abs(playerTransform.transform.position.y - myTransform.position.y) * Mathf.Abs(playerTransform.transform.position.y - myTransform.position.y));
        // 開耕號(絕對值(敵人X-我X)^2+絕對值(敵人Y-我Y)^2)

        Debug.Log("distance: " + distance + " disX" +  disX + " disY" + disY + " deltaTime:" + Time.deltaTime);

        if (distance < DisChase && (status == Status.attack || status == Status.died) == false)
        {
            if (status == Status.idle || status == Status.walk)
            {
                AngryLevel += 1;
            }
            status = Status.chase;
            
        }

        if (isFaceRight == true)
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = true;
        }


        switch (status)
        {
            case Status.idle: //切換狀態基
                if (IdleTime <= 0)//切換遊走
                {
                    status = Status.walk;
                }
                IdleTimeControl();//停滯時間
                break;
            case Status.walk:
                if (WalkTime <= 0)//切換到停滯
                {
                    status = Status.idle;
                }

                transform.Translate(new Vector3(WalkSpeed * (WalkDisX /*sin*/), WalkSpeed * (WalkDisY /*cos*/), 0) * Time.deltaTime);//遊走

                WalkTimeControl();//遊走時間控制
                break;

            case Status.chase:

                Debug.Log("chase");
                if (disX >= 0)//面朝方向
                {
                    isFaceRight = true;
                }
                else
                {
                    isFaceRight = false;
                }

                transform.Translate(new Vector3(speed * (disX / distance/*sin*/), speed * (disY / distance/*cos*/), 0) * Time.deltaTime); //追玩家

                AngryLevel += Time.deltaTime; //怒氣直
                if (distance >= DisChase && AngryLevel < 5) //超出範圍 變回停滯
                {
                    status = Status.idle;
                    IdleTime = Random.Range(IdleTimeMin, IdleTimeMax);
                }
                if (AngryLevel >= 5) //超過怒氣直 切換到跳躍攻擊
                {
                    Debug.Log("go to attack");
                    status = Status.attack;
                    TargetDisX = playerTransform.transform.position.x - myTransform.position.x + Random.Range(-1, 1);
                    TargetDisY = playerTransform.transform.position.y - myTransform.position.y + Random.Range(-1, 1);
                    AttackDelayCheck = AttackDelay;
                    JumpTime -= 1;
                    


                    if (TargetDisY < 0)
                    {
                        VecY = Mathf.Sqrt(2 * YGap * Gravity);
                        //更號(往上距離*2*重利)
                        AttackTime = (VecY / Gravity) + Mathf.Sqrt((2 * (YGap + Mathf.Abs(TargetDisY))) / Gravity);
                        VecX = TargetDisX;
                    }
                    else if (TargetDisY >= 0)
                    {
                        VecY = Mathf.Sqrt(2 * Gravity * (TargetDisY + YGap));
                        //更號(2*重利(差距+往上距離))
                        AttackTime = Mathf.Sqrt((2 * (YGap + TargetDisY)) / Gravity) + Mathf.Sqrt((2 * YGap) / Gravity);
                        VecX = TargetDisX;
                    }

                    AttackTimeCheck = AttackTime;





                }

                break;
            case Status.attack:
                //AttackTarget();
                Debug.Log("attack , VecX: " + VecX + " VecY: " + VecY);
                AngryLevel = 0;


                if (AttackDelayCheck <= 0 && AttackTimeCheck > 0)
                {
                    this.GetComponent<EdgeCollider2D>().enabled = false;
                    transform.Translate(new Vector3(VecX, VecY, 0) * (Time.deltaTime / AttackTime)); //攻擊函式
                    VecY = VecY - Gravity * Time.deltaTime;
                    AttackTimeCheck -= Time.deltaTime;

                    if (AttackTimeCheck <= 0)
                    {
                        AttackDelayCheck = AttackDelay;
                        this.GetComponent<EdgeCollider2D>().enabled = true;
                    }
                } else if (AttackTimeCheck <= 0 && AttackTimeCheck == -69)
                {
                    if (JumpTime<=0)
                    {
                        status = Status.died;
                    }
                    else
                    {
                        status = Status.chase;
                    }
                    
                    
                }
                else
                {
                    AttackDelayCheck -= Time.deltaTime;

                    if (AttackDelayCheck <= 0 && AttackTimeCheck <= 0) 
                    {
                        AttackTimeCheck = -69;
                    }
                }

                
                break;
            case Status.died:
                Split();
                break;
        }
    }

    /*void AttackTarget() 
    {
        transform.Translate(new Vector3( VecX , 0, 0) * (Time.deltaTime / DeltaTime));
        AttackTimeCheck -= Time.deltaTime;

        if (AttackTimeCheck <= 0)
        {
            status = Status.chase;
            AngryLevel = 0;
        }
    }*/

    void IdleTimeControl()
    {
        if (IdleTime>0)
        {
            IdleTime -= Time.deltaTime;
        }
        else
        {
            IdleTime = Random.Range(IdleTimeMin,IdleTimeMax);
        }
    }

    void WalkTimeControl()
    {
        if (WalkTime > 0)
        {
            WalkTime -= Time.deltaTime;
        }
        else
        {
            WalkTime = Random.Range(WalkTimeMin , WalkTimeMax);
            WalkDisX = Random.Range(-1f, 1f);
            WalkDisY = Random.Range(-1f, 1f);
            

            if (WalkDisX >= 0)
            {
                isFaceRight = true;
            }
            else
            {
                isFaceRight = false;
            }
        }
    }

    void Split()
    {
        if (this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x - 0.1f, this.transform.localScale.y - 0.1f, this.transform.localScale.z - 0.1f) ;
            //this.transform.Scale -= 0.1;
            //this.transform.Scale -= 0.1;
            if (this.transform.localScale.x <= 0)
            {
                this.transform.localScale = new Vector3(0, 0, 0);
                Instantiate(SplitSlime, new Vector3(transform.position.x + SplitGap, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                Instantiate(SplitSlime, new Vector3(transform.position.x - SplitGap, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                Destroy(gameObject);
            }
        }
        else
        {

        }
    }

}
