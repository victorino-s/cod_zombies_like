using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public float attackDelay;
    public bool presenceInAttackZone = false;

    float lastAttackTime = 0f;
    NavMeshAgent agent;
    bool initialized = false;
    float lastCheckedDistance = 0f;
    bool isAttacking = false;
    // Use this for initialization
    void Start()
    {
        attackDelay = attackDelay > 0f ? attackDelay : .8f;

        agent = GetComponent<NavMeshAgent>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        agent.SetDestination(ChooseRandomPlayer().transform.position - (transform.forward * GetComponent<CapsuleCollider>().radius));
        lastCheckedDistance = Vector3.Distance(transform.position, agent.destination);

    }
    public IEnumerator PlayAttack()
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        yield return null;
        GetComponent<Animator>().SetBool("IsAttacking", false);
        isAttacking = false;
    }

    public IEnumerator PlayOneShot(string paramName)
    {
        GetComponent<Animator>().SetBool(paramName, true);
        yield return null;
        GetComponent<Animator>().SetBool(paramName, false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (presenceInAttackZone && (Time.time > lastAttackTime + attackDelay) && !isAttacking)
        {
            isAttacking = true;
            Debug.Log("Attack");
            StartCoroutine(PlayAttack());

            
        }


        if (presenceInAttackZone)
        {
            agent.destination = transform.position;

                GetComponent<Animator>().SetTrigger("IdleTrigger");
        }
        else if ((lastCheckedDistance - Vector3.Distance(transform.position, agent.destination)) < (lastCheckedDistance / 2f))
        {
            RecalculatePath();
        }

    }
    
    void LateUpdate()
    {
        if(agent.velocity != Vector3.zero)
        {
            GetComponent<Animator>().SetTrigger("WalkTrigger");
        }
    }

    void RecalculatePath()
    {
        agent.SetDestination(ChooseRandomPlayer().transform.position);
        lastCheckedDistance = Vector3.Distance(transform.position, agent.destination);
    }
    GameObject ChooseRandomPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1)
        {
            return players[0];
        }

        int elu = Random.Range(0, players.Length - 1);

        return players[elu];
    }


}
