using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterScripts : MonoBehaviour
{
    public NavMeshAgent navA;
    public Transform[] target = new Transform[5];
    public GameObject targetPlayer;
    public AudioSource audioSource;
    public float curTime = 0;
    public float coolTime = 30f;
    public ENEMYSTATE enemyState;
    public int rnd;
    public bool playerfound = false;
    public Animator enemyAnim;
    public float distance;
    public float mindist;
    public float mcurTime;
    public float mcoolTime;
    public bool isplayerRun = false;
    public AudioClip crySound;
    public AudioClip detectSound;
    public PlayerController playerController;
    public MouseLook mouseLook;
    public GameObject playerCam;
    public bool isSoundON = true;
    public bool isEscape = false;
    public GameObject[] doors;


    public enum ENEMYSTATE
    {
        IDLE = 0,
        WALK,
        DETECTED,
        ATTACK,
        ESCAPE
    }




    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyState = ENEMYSTATE.IDLE;
        audioSource = GetComponent<AudioSource>();
        navA = GetComponent<NavMeshAgent>();
        audioSource.Play();

    }
    private void Update()
    {
        if (isEscape)
        {
            StartCoroutine(EscapeStart());
            //enemyState = ENEMYSTATE.ESCAPE;
            //gameObject.GetComponent<SphereCollider>().radius = 50;
            //navA.speed = 4f;
            //mcurTime = 0;
        }

        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);

        if (isEscape == false)
        {
            if (targetPlayer.GetComponent<PlayerController>().moveSpd == 4)
            {
                isplayerRun = true;
                gameObject.GetComponent<SphereCollider>().radius = 20;
                navA.speed = 4.5f;
                mcurTime = 0;
            }
            else
            {
                isplayerRun = false;
                if (isplayerRun == false)
                {
                    mcurTime += Time.deltaTime;
                    if (mcurTime > mcoolTime)
                    {
                        gameObject.GetComponent<SphereCollider>().radius = 5;
                        navA.speed = 2f;
                        mcurTime = 0;
                    }
                }

            }
        }




        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                enemyAnim.SetInteger("EState", 0);
                curTime += Time.deltaTime;
                if (curTime > coolTime)
                {
                    rnd = Random.Range(0, 9);
                    curTime = 0;
                    enemyState = ENEMYSTATE.WALK;
                }
                break;

            case ENEMYSTATE.WALK:
                enemyAnim.SetInteger("EState", 1);
                navA.SetDestination(target[rnd].transform.position);

                if (gameObject.transform.position.x == target[rnd].transform.position.x && gameObject.transform.position.z == target[rnd].transform.position.z)
                {
                    enemyState = ENEMYSTATE.IDLE;
                }

                break;

            case ENEMYSTATE.DETECTED:
                enemyAnim.SetInteger("EState", 1);

                if (playerfound)
                {
                    navA.SetDestination(targetPlayer.transform.position);
                    if (distance <= mindist)
                    {
                        isSoundON = true;
                        enemyState = ENEMYSTATE.ATTACK;
                    }
                }
                else
                {
                    enemyState = ENEMYSTATE.WALK;
                }


                break;

            case ENEMYSTATE.ATTACK:
                if (isSoundON)
                {
                    isSoundON = false;
                    audioSource.volume = 0.8f;
                    audioSource.PlayOneShot(detectSound);
                }
                playerCam.transform.LookAt(gameObject.transform);
                
                targetPlayer.GetComponent<PlayerController>().hp -= 100;

                break;

            case ENEMYSTATE.ESCAPE:
                navA.SetDestination(targetPlayer.transform.position);
                if (distance <= mindist)
                {
                    enemyState = ENEMYSTATE.ATTACK;
                }
                break;

            default:
                break;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerfound = true;
            enemyState = ENEMYSTATE.DETECTED;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerfound = false;
            enemyState = ENEMYSTATE.WALK;
        }

    }

    IEnumerator EscapeStart()
    {
        yield return new WaitForSeconds(2f);
        enemyState = ENEMYSTATE.ESCAPE;
        gameObject.GetComponent<SphereCollider>().radius = 50;
        doors[0].GetComponent<NavMeshObstacle>().enabled = false;
        doors[1].GetComponent<NavMeshObstacle>().enabled = false;
        doors[2].GetComponent<NavMeshObstacle>().enabled = false;
        doors[3].GetComponent<NavMeshObstacle>().enabled = false;
        doors[4].GetComponent<NavMeshObstacle>().enabled = false;
        doors[5].GetComponent<NavMeshObstacle>().enabled = false;
        doors[6].GetComponent<NavMeshObstacle>().enabled = false;
        doors[7].GetComponent<NavMeshObstacle>().enabled = false;
        doors[8].GetComponent<NavMeshObstacle>().enabled = false;
        doors[9].GetComponent<NavMeshObstacle>().enabled = false;
        doors[10].GetComponent<NavMeshObstacle>().enabled = false;
        doors[11].GetComponent<NavMeshObstacle>().enabled = false;
        doors[12].GetComponent<NavMeshObstacle>().enabled = false;
        doors[13].GetComponent<NavMeshObstacle>().enabled = false;
        navA.speed = 4.5f;
        mcurTime = 0;
    }





}
