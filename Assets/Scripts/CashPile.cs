using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashSpawning
{
    public class CashPile : MonoBehaviour
    {
        public GameObject cashStackWorldReference;
        public float dollarValue;

        float dollarValueSpawned;

        public float rows, columns, maxPileValue;

        public float stackUSDValue;

        public float spawnInterval = 0; 

        static Vector3 stackDimensions;
        static GameObject CASHSTACKWORLDREF;  

        static WaitForSeconds spawnIntervalWFS;

        private void Awake()
        {
            if (CASHSTACKWORLDREF == null)
                CASHSTACKWORLDREF = cashStackWorldReference; 


            if (spawnIntervalWFS == null)
                spawnIntervalWFS = new WaitForSeconds(spawnInterval);
        }
        // Use this for initialization
        void Start()
        {
            dollarValueSpawned = 0;

            BoxCollider bc = CASHSTACKWORLDREF.GetComponentInChildren<BoxCollider>();

            //worldspace space dimensions
            if(stackDimensions == Vector3.zero)
            {
                stackDimensions = new Vector3(bc.bounds.size.x, bc.bounds.size.y, bc.bounds.size.z);
            }


            if (dollarValue != 0 && dollarValueSpawned == 0)
                spawnStack(); 
        }

        public void spawnStack()
        {
            StartCoroutine(spawnStackCR()); 
        }

        IEnumerator spawnStackCR()
        {
            Vector3 spawnPosition = transform.position;
            while (dollarValueSpawned < maxPileValue)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int c = 0; c < rows; c++)
                    {
                        Instantiate(CASHSTACKWORLDREF, spawnPosition, Quaternion.identity, transform);
                        if(spawnInterval != 0f)
                            yield return spawnIntervalWFS;  

                        dollarValueSpawned += stackUSDValue;

                        if (dollarValueSpawned >= maxPileValue || dollarValueSpawned >= dollarValue)
                            yield break;

                        spawnPosition += Vector3.forward * stackDimensions.z;
                    }
                    spawnPosition = new Vector3(spawnPosition.x + stackDimensions.x, spawnPosition.y, transform.position.z);
                }
                spawnPosition = new Vector3(transform.position.x, spawnPosition.y + stackDimensions.y, transform.position.z);
            }
        }
    }
}

