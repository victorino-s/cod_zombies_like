using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class uitest : MonoBehaviour {

    NavMeshAgent agent;
    Animator _animator;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
        {
            agent.SetDestination(GameObject.Find("Player_Sample(Clone)").transform.position);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(agent.velocity);
        }

        if(agent.velocity != Vector3.zero)
        {
            _animator.SetTrigger("WalkTrigger");
        }
        else
        {
            _animator.SetTrigger("IdleTrigger");
        }
	}
}
