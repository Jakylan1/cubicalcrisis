using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerMoney = 0;
    public bool canPlayerEarnMoneyFromCubicle = false;
    public GameObject clonePrefab;
    public Transform cloneSpawnPoint;
    public HashSet<Transform> CubicleSlots = new HashSet<Transform>(); // Use HashSet<Transform> instead of List<Transform>
    public UnityEvent AddMoneyEvent;
    public int playerMaxClones = 3;
    public int clonesSpawned = 0;
    public int cloneCostTospawn = 5;
    public int cloneLifeTime = 21;
    public int cloneIncome = 20;
    public int numOfCubicles = 0;
    public int nextCubicleElement;
    public int cubicleCost = 500;
    [SerializeField] private List<GameObject> cubicles;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnClone()
    {
        if (CubicleSlots.Count-1 > 0 & clonesSpawned < playerMaxClones)
        {
            Instantiate(clonePrefab, cloneSpawnPoint.position, cloneSpawnPoint.rotation);
            clonesSpawned++;
            TakeMoney(cloneCostTospawn);
            //cloneCostTospawn;
        }
        else
        {
            print("Cant spawn Anymore Clones");
        }
    }

    public void AddCubiclePointsToList(Transform slotPoint)
    {
        if (!CubicleSlots.Contains(slotPoint)) // Check if the slot point already exists in the set
        {
            CubicleSlots.Add(slotPoint); // Add the slot point to the HashSet
        }
    }

    public void RemoveCubiclePointsFromList(Transform slotPoint)
    {
        CubicleSlots.Remove(slotPoint); // Remove the slot point from the HashSet
    }

    public void AddMoney(){
        AddMoneyEvent?.Invoke();
    }

    public void TakeMoney(int money){
        playerMoney -= money;
    }

    public void spawnNextCubicle(){
        if(cubicles.Count > nextCubicleElement){
            cubicles[nextCubicleElement].SetActive(true);
            nextCubicleElement++;
            TakeMoney(cubicleCost);
        }
    }

    public void IncreaseMaxClones(){
        playerMaxClones++;
        TakeMoney(200);
    }

    public void IncreaseCloneProductivity(){
        cloneIncome += 30;
        TakeMoney(250);
    }
}