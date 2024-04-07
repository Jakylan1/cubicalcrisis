using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cubical : MonoBehaviour
{
    public GameObject[] slotPoints;
    public AudioClip soundClip;

    void Start()
    {
        for (int i = 0; i < slotPoints.Length; i++)
        {
            GameManager.Instance.AddCubiclePointsToList(slotPoints[i].transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Collided with player");
            GameManager.Instance.canPlayerEarnMoneyFromCubicle = true;
            SoundManager.PlaySound(soundClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.canPlayerEarnMoneyFromCubicle = false;
        }
    }
}
