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

        public int rows, columns; 

        public float stackUSDValue;

        public float spawnInterval = 0;

        public static float MAXTOTALVALUE = 1470000;

        static Vector3 stackDimensions;
        static GameObject CASHSTACKWORLDREF;  

        static WaitForSeconds spawnIntervalWFS;

        private void Awake()
        { 
            if (CASHSTACKWORLDREF == null)
                CASHSTACKWORLDREF = cashStackWorldReference; 


            if (spawnIntervalWFS == null)
                spawnIntervalWFS = new WaitForSeconds(spawnInterval);

            if (stackDimensions == Vector3.zero)
            {
                BoxCollider bc = CASHSTACKWORLDREF.GetComponentInChildren<BoxCollider>();
                stackDimensions = new Vector3(bc.bounds.size.x, bc.bounds.size.y, bc.bounds.size.z);
            }

            dollarValueSpawned = 0;


        }
        // Use this for initialization
        void Start()
        {

        }

        public float spawnStack(int amountToSpawn, bool animate)
        {
            dollarValue = amountToSpawn; 
            StartCoroutine(spawnStackCR());
            spawnInterval = animate ? spawnInterval : 0; 
            return (dollarValue/100) * spawnInterval;  
        }

        public float spawnStack()
        {
            StartCoroutine(spawnStackCR());
            return (dollarValue / 100) * spawnInterval;
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
            while (dollarValueSpawned < MAXTOTALVALUE)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int c = 0; c < rows; c++)
                    {
                        stacks[layerNum][c][i] = Instantiate(cashStackPrefab, spawnPosition, Quaternion.identity, transform);
                        dollarValueSpawned += stackUSDValue;

                        if (dollarValueSpawned >= MAXTOTALVALUE || dollarValueSpawned >= dollarValue) //finish spawning
                        {
                            combineChildMeshes();
                            destroyAllChildren(); 
                            yield break;
                        }


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


        //helper methods
        T[][] initialize2DArray<T>(int r, int c)
        {
            T[][] twoDArray = new T[r][];
            for (int i = 0; i < r; i++)
                twoDArray[i] = new T[c];

            return twoDArray;
        }

        void destroyInnerItems(GameObject[][] objArray)
        {
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

        void combineChildMeshes()
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length - 1];
            int i = 1;
            while (i < meshFilters.Length)
            {
                combine[i - 1].mesh = meshFilters[i].sharedMesh;
                Matrix4x4 myTransform = transform.worldToLocalMatrix;
                combine[i - 1].transform = myTransform * meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false); 
                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
  
            transform.gameObject.SetActive(true);
        }

        void destroyAllChildren()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}

