using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneAIBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private float delay = 1;
    public AudioClip soundClip;

    void Start()
    {
        SoundManager.PlaySound(soundClip);
        agent = GetComponent<NavMeshAgent>();
        Destroy(gameObject, GameManager.Instance.cloneLifeTime);
        InvokeRepeating("IncreaseFundsForPlayer", delay, delay);

        if (GameManager.Instance.CubicleSlots.Count > 0)
        {
            // Convert HashSet to a list to access elements by index
            List<Transform> cubicleList = new List<Transform>(GameManager.Instance.CubicleSlots);

            // Get a random index within the range of the list
            int randomIndex = Random.Range(0, cubicleList.Count);

            // Get the target from the list using the random index
            target = cubicleList[randomIndex]; // Remove Transform declaration

            // Set destination to the target position
            agent.SetDestination(target.position);

            // Remove the target from the HashSet
            GameManager.Instance.RemoveCubiclePointsFromList(target);
        }
        else
        {
            Debug.LogWarning("No available cubicle slots for the clone to move to.");
        }
    }

    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            //Vector3 directionToTarget = target.position - transform.position;
            //this.gameObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.x,);
        }
    }

    void IncreaseFundsForPlayer(){
        GameManager.Instance.playerMoney += GameManager.Instance.cloneIncome;
    }

    void OnDestroy() {
        GameManager.Instance.clonesSpawned--;
        GameManager.Instance.AddCubiclePointsToList(target);
        CancelInvoke("IncreaseFundsForPlayer");
    }
}
