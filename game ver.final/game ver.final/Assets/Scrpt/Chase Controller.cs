//using UnityEngine;

//public class ChaseController : MonoBehaviour
//{
//    public float moveSpeed = 12f; // 敵の移動速度
//    public float stoppingDistance = 8f; // プレイヤーを追跡する距離
//    private Transform player; // プレイヤーのTransform
//    private bool isFollowingPlayer = false; // プレイヤーを追跡中かどうかのフラグ   

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform; // プレイヤーのTransformを取得
//    }

//    void Update()
//    {

//        // プレイヤーを追跡する条件
//        if (Vector3.Distance(transform.position, player.position) < stoppingDistance)
//        {
//            isFollowingPlayer = true; // プレイヤーを追跡開始
//        }
//        else if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
//        {
//            isFollowingPlayer = false; // プレイヤーを追跡停止
//        }

//        if (isFollowingPlayer)
//        {
//            // プレイヤーの方向を向く
//            transform.LookAt(player);

//            // プレイヤーに向かって移動する
//            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseController : MonoBehaviour  //プレイヤーをずっと追う
{
    public Transform player;
    NavMeshAgent agent;
    public bool Enemy = false;     //敵が宝を持ってるか

    //以下コアのオブジェクト二つを反映するために名前増やした修正　by國重

    // [SerializeField] private Renderer takara;
    // [SerializeField] private Renderer Ptakara;

    [SerializeField] private Renderer takara1;
    [SerializeField] private Renderer takara2;
    [SerializeField] private Renderer Ptakara1;
    [SerializeField] private Renderer Ptakara2;
    [SerializeField] private DoorScript doorScript; 




    public NavMeshAgent navMeshAgent;
    public Transform[] point;
    int number;

    //★
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //★
        animator = GetComponent<Animator>();

        //takara.enabled = false;
        //Ptakara.enabled = true;

       
        doorScript.HideSpecifiedObjects(); 
        

        takara1.enabled = false;
        takara2.enabled = false;
        Ptakara1.enabled = true;
        Ptakara2.enabled = true;


        Time.timeScale = 1;

        number = Random.Range(0, point.Length);
    }

    void Update()
    {
        if (Enemy == false)
        {
            agent.destination = player.position;
        }
        else
        {
            navMeshAgent.SetDestination(point[number].position);
        }

        //agent.velocity = (agent.steeringTarget - transform.position).normalized * agent.speed;
        //transform.forward = agent.steeringTarget - transform.position;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") //プレイヤーから宝を取る
        {
            if (Enemy == false) //敵　宝を取る
            {
                Enemy = true;
                //takara.enabled = true;
                //Ptakara.enabled = false;
                takara1.enabled = true;
                takara2.enabled = true;
                Ptakara1.enabled = false;
                Ptakara2.enabled = false;

                //★アニメーションうまく作動せず
                //animator.SetBool("steal", true);
                //animator.SetBool("catch", false);

                    doorScript.ShowSpecifiedObjects(); // ドアを消す
                }


            
        }
            else if (Enemy) //プレイヤー、宝取り返す
            {
                Enemy = false;
                //takara.enabled = false;
                //Ptakara.enabled = true;
                takara1.enabled = false;
                takara2.enabled = false;
                Ptakara1.enabled = true;
                Ptakara2.enabled = true;

            
            
            doorScript.HideSpecifiedObjects(); // ドアを戻す
            

            //★アニメーションうまく作動せず
            //animator.SetBool("catch", true);
            //animator.SetBool("steal", false);
            // StartCoroutine(stop());
        }
    }

    public IEnumerator stop()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3.0f);

        Time.timeScale = 1;
    }

}