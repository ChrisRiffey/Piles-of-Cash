﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;  

public class CashSpawner : MonoBehaviour {
    public float distanceBetweenPiles;
    public float stackSpawnInterval;

    public int maxRow, maxCol;  

    [Header("Must be BIG to SMALL")]
    public GameObject[] stackDenominationPrefab;

    public UnityEvent OnSpawnComplete;

    static WaitForSeconds stackSpawnIntervalWFS;

    int money;
    private void Awake()
    {
        if (stackSpawnIntervalWFS == null)
            stackSpawnIntervalWFS = new WaitForSeconds(stackSpawnInterval);
    }
    private void Start()
    {
        spawnMoney(56500, GameObject.Find("TestProfile").transform);  
    }

    public void spawnMoney(float amount, Transform startPosition)
    {
        // 0 - 1.5 mil stack, 1 - 10k, 2 - 5k, 3 - 1k, 4 - 100)
        money = (int)amount; 
        int[] stacksToSpawn = parseNumOfStacksToSpawn(amount);
        StartCoroutine(stackSpawningCR(stacksToSpawn, startPosition.position)); 
     
    }

    IEnumerator stackSpawningCR(int[] stacksToSpawn, Vector3 startPosition)
    {
        Vector3 direction = -transform.right;
        GameObject profileParent = new GameObject(money + "  profile");  
        for(int prefabIndex = 0; prefabIndex < stacksToSpawn.Length; prefabIndex++)
        {
            Vector3 spawnPosition = startPosition;

            GameObject[][] stacks = initialize2DArray<GameObject>(10, 10);
            GameObject stackParent = new GameObject("stack" + prefabIndex);
            stackParent.transform.parent = profileParent.transform;

            Stack stackSettings = stackDenominationPrefab[prefabIndex].GetComponent<Stack>();

            int stacksSpawned = 0; 
            
            for (int row = 0; row < maxRow; row++)
            {
                if (stacksSpawned >= stacksToSpawn[prefabIndex])
                    break;

                for (int col = 0; col < maxCol; col++)
                {
                    if (stacksSpawned >= stacksToSpawn[prefabIndex])
                        break; 
     
                    stacks[row][col] = Instantiate(stackDenominationPrefab[prefabIndex], spawnPosition, Quaternion.identity, stackParent.transform);
                    stacksSpawned++; 

                    if (stackSpawnInterval != 0f)
                        yield return stackSpawnIntervalWFS;

                    spawnPosition += Vector3.right * (stackSettings.worldDimensions.x + stackSettings.worldDimensions.x / 4);
                }


                spawnPosition = new Vector3(startPosition.x, startPosition.y, spawnPosition.z - stackSettings.worldDimensions.z);
            }

            if(stacksToSpawn[prefabIndex] != 0)
                startPosition += direction * distanceBetweenPiles;  
        }
        OnSpawnComplete.Invoke();  
    }

    int[] parseNumOfStacksToSpawn(float amount)
    {

        int[] stackDenominations = {1500000, 10000, 5000, 1000, 100};
        int[] stackCount = new int[stackDenominations.Length];

        for (int i = 0; i < stackCount.Length; i++)
        {
            stackCount[i] = amount > 0 ? (int)(amount / stackDenominations[i]) : 0;

            amount -= stackCount[i] * stackDenominations[i];
        }

        return stackCount; 
    }
    T[][] initialize2DArray<T>(int r, int c)
    {
        T[][] twoDArray = new T[r][];
        for (int i = 0; i < r; i++)
            twoDArray[i] = new T[c];

        return twoDArray;
    }


    
}