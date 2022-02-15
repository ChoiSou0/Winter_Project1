using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1_Ctrl : MonoBehaviour
{
    private GameManager gameManager;
    public Transform target;
    public Vector3 player;
    public Vector3 d;
    public float FollowPos;

    public Vector2 v, w;
    public float num1;
    public float num2;
    public float num3;
    public float num4;
    //public Vector2 FollowPos, player;

    public float LifeTime;
    public float Speed;

    public int xVec;
    public int yVec;

    int cnt;

    public bool Follow;

    private float distanceLength;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(FollowPos);
        //player = new Vector2(target.position.x, target.position.y);
        //Vector2 p = transform.position;
        //FollowPos = Mathf.Atan2(player.x - transform.position.x, player.y - transform.position.y) * Mathf.Rad2Deg;
        ////this.transform.rotation = Quaternion.AngleAxis(FollowPos, Vector3.forward);
        //Vector3 dir = new Vector3(FollowPos, FollowPos, 0);
        ////transform.rotation = Quaternion.LookRotation(dir);
        //transform.Translate(dir.normalized * Time.deltaTime);

        //Vector2 v = target.transform.position - this.transform.position;
        //float x = target.position.x - transform.position.x;
        //float y = transform.position.y - transform.position.y;
        //float angle = (float)(Mathf.Atan2(y, x) * 180 / 3.14f);

        //p.x += Mathf.Cos(angle / 180 * 3.14f) * Speed * Time.deltaTime;
        //p.y += Mathf.Sin(angle / 180 * 3.14f) * Speed * Time.deltaTime;


        //if (gameManager.FireBall1_On == true)
        //{
        //    player = new Vector2(target.rotation.x, target.rotation.y);
        //    gameManager.FireBall1_On = false;
        //    FollowPos = Mathf.Atan2(player.y - transform.rotation.y, player.x - transform.rotation.x) * Mathf.Rad2Deg;
        //    this.transform.rotation = Quaternion.AngleAxis(FollowPos - 90, Vector3.forward);
        //    Follow = true;
        //}

        //if (Follow == true && LifeTime <= 5)
        //{
        //    LifeTime += Time.deltaTime;
        //    //transform.Rotate(0, 0, transform.rotation.z);
        //    transform.Translate(Vector2.right * Speed * Time.deltaTime);
        //    //transform.Translate(Vector2.up * Speed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(FollowPos.x * xVec, FollowPos.y * yVec), Speed * Time.deltaTime);

        //    if (LifeTime >= 5)
        //    {
        //        Destroy(gameObject);
        //        Follow = false;
        //        LifeTime = 0;
        //    }
        //}

        if (gameManager.FireBall1_On == true)
        {
            gameManager.FireBall1_On = false;
            //Vector2 v = target.transform.position;
            //Vector2 w = this.transform.position;
            //num1 = v.x - w.x;
            //num2 = v.y - w.y;
            //num3 = num1 * num1 + num2 * num2;
            //num4 = (float)Mathf.Sqrt(num3);
            
            v = transform.position;
            if (target.transform.position.x > transform.position.x && target.transform.position.y > transform.position.y)
            {
                w = new Vector2(target.transform.position.x + transform.position.x, target.transform.position.y + transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x < transform.position.x && target.transform.position.y > transform.position.y)
            {
                w = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y + transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x > transform.position.x && target.transform.position.y < transform.position.y)
            {
                w = new Vector2(target.transform.position.x + transform.position.x, target.transform.position.y - transform.position.y);
                w = w + w + w;
            }
            else if (target.transform.position.x < transform.position.x && target.transform.position.y < transform.position.y)
            {
                w = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
                w = w + w + w;
            }

            startTime = Time.time;
            distanceLength = Vector2.Distance(v, w);
            Follow = true;
        }

        if (Follow == true && LifeTime <= 5)
        {
            LifeTime += Time.deltaTime;
            float distCovered = (Time.time - startTime) * Speed;
            float franJourney = distCovered / distanceLength;
            transform.position = Vector2.Lerp(v, w, franJourney);
            

            if (LifeTime >= 5)
                Destroy(gameObject);
        }

    }
}
