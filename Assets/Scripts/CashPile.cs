using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashSpawning
{
    public class CashPile : MonoBehaviour
    {
        public GameObject cashStack;
        public float dollarValue;
        float dollarValueSpawned;

        public float rows, columns, maxPileValue;

        public float stackUSDValue;

        public float spawnInterval = 0; 

        static Vector3 stackDimensions;

        WaitForSeconds spawnIntervalWFS; 
        // Use this for initialization
        void Start()
        { 
            dollarValueSpawned = 0;

            BoxCollider bc = cashStack.GetComponent<BoxCollider>();

            //local space dimensions
            if(stackDimensions == Vector3.zero)
            {
                stackDimensions = new Vector3(bc.bounds.size.x, bc.bounds.size.y, bc.bounds.size.z);
                Debug.Log(stackDimensions); 
            }

            spawnIntervalWFS = new WaitForSeconds(spawnInterval);

            StartCoroutine(createStack()); 
        }

        public IEnumerator createStack()
        {
            Vector3 spawnPosition = transform.position;
            while (dollarValueSpawned < maxPileValue)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int c = 0; c < rows; c++)
                    {
                        Instantiate(cashStack, spawnPosition, Quaternion.identity, transform);
                        if(spawnInterval != 0f)
                            yield return spawnIntervalWFS;  

                        dollarValueSpawned += stackUSDValue;

                        if (dollarValueSpawned >= maxPileValue || dollarValueSpawned >= dollarValue)
                            yield break;

                        spawnPosition += Vector3.right * stackDimensions.x;
                    }
                    spawnPosition = new Vector3(transform.position.x, spawnPosition.y, spawnPosition.z + stackDimensions.z);
                }
                spawnPosition = new Vector3(transform.position.x, spawnPosition.y + stackDimensions.y, transform.position.z);
            }
        }
    }
}

