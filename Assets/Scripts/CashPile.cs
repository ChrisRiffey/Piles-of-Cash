using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashSpawning
{
    public class CashPile : MonoBehaviour
    {
        public GameObject cashStackWorldReference;
        public GameObject cashStackPrefab;  

        public float dollarValue;

        float dollarValueSpawned;

        public int rows, columns, maxPileValue;

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

            //references to hollow out occuluded stacks
            GameObject[][][] stacks = new GameObject[180][][];
            for (int i = 0; i < 180; i++)
            {
                stacks[i] = initialize2DArray<GameObject>(rows, columns);
            }

            Vector3 spawnPosition = transform.position;
            int layerNum = 0;
            //


            //
            while (dollarValueSpawned < maxPileValue)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int c = 0; c < rows; c++)
                    {
                        stacks[layerNum][c][i] = Instantiate(cashStackPrefab, spawnPosition, Quaternion.identity, transform);
                        dollarValueSpawned += stackUSDValue;

                        if (dollarValueSpawned >= maxPileValue || dollarValueSpawned >= dollarValue)
                            yield break;

                        if (spawnInterval != 0f)
                            yield return spawnIntervalWFS;

                        spawnPosition += Vector3.forward * stackDimensions.z;
                    }
                    spawnPosition = new Vector3(spawnPosition.x + stackDimensions.x, spawnPosition.y, transform.position.z);
                }
                if(layerNum > 0)
                    destroyInnerItems(stacks[layerNum - 1]);
                layerNum++;
                spawnPosition = new Vector3(transform.position.x, spawnPosition.y + stackDimensions.y, transform.position.z);
            }
        }

        T[][] initialize2DArray<T>(int r, int c)
        {
            T[][] twoDArray = new T[r][];
            for (int i = 0; i < r; i++)
                twoDArray[i] = new T[c];

            return twoDArray;
        }

        void destroyInnerItems(GameObject[][] objArray)
        {
            Debug.Log("I was called");
            for (int r = 0; r < objArray.Length; r++)
            {
                for (int c = 0; c < objArray[r].Length; c++)
                {
                    if (r != 0 && c != 0 && r != rows - 1 && c != columns - 1)
                        if(Application.isPlaying)
                            Destroy(objArray[r][c]); 
                        else
                            DestroyImmediate(objArray[r][c]);

                }
            }
        }
    }
}

