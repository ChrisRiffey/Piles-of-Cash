using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashSpawning
{
    public class CashPile : MonoBehaviour
    {
        public GameObject stackPrefab;  

        public float value;

        public int rows, columns; 

        public float spawnInterval = 0;

        public float maxFeetHeight = 6;

        float valueSpawned;

        [Header("MAX VALUE IS READ ONLY")]
        public float maxValue; 

        static WaitForSeconds spawnIntervalWFS;

        private void Awake()
        { 
            if (spawnIntervalWFS == null)
                spawnIntervalWFS = new WaitForSeconds(spawnInterval);
        }

        // Use this for initialization
        void Start()
        {
            spawnStack();   
        }

        //returns expected completion time
        public float spawnStack(int amountToSpawn, bool animate)
        {
            value = amountToSpawn; 
            StartCoroutine(spawnStackCR());
            spawnInterval = animate ? spawnInterval : 0; 
            return (value/100) * spawnInterval;  
        }

        public float spawnStack()
        {
            if(value > maxValue)
            {
                value = maxValue;
                Debug.Log("!WARNING! Value exceed maxValue"); 
            }
            
            StartCoroutine(spawnStackCR());
            return (value / 100) * spawnInterval;
        }

        IEnumerator spawnStackCR()
        {
            //references to hollow out occuluded stacks
            GameObject[][][] stacks = new GameObject[180][][];
            for (int i = 0; i < 180; i++)
            {
                stacks[i] = initialize2DArray<GameObject>(rows, columns);
            }

            Stack stackSettings = stackPrefab.GetComponent<Stack>();  
            Vector3 spawnPosition = transform.position;
            int layerNum = 0;
            while (valueSpawned < maxValue)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int c = 0; c < rows; c++)
                    {
                        stacks[layerNum][c][i] = Instantiate(stackPrefab, spawnPosition, Quaternion.identity, transform);
                        valueSpawned += stackSettings.value;

                        if (valueSpawned >= maxValue || valueSpawned >= value) //finish spawning
                        {
                            
                            //yield return new WaitForEndOfFrame();   
                            combineChildMeshes();
                            destroyAllChildren(); 
                           
                            yield break;
                        }


                        if (spawnInterval != 0f)
                            yield return spawnIntervalWFS;

                        spawnPosition += Vector3.forward * stackSettings.worldDimensions.z;
                    }
                    spawnPosition = new Vector3(spawnPosition.x + stackSettings.worldDimensions.x, spawnPosition.y, transform.position.z);
                }
                if(layerNum > 0)
                    destroyInnerItems(stacks[layerNum - 1]);
                layerNum++;
                spawnPosition = new Vector3(transform.position.x, spawnPosition.y + stackSettings.worldDimensions.y, transform.position.z);
            }

        }

        public void updateMaxValue()
        {
            Stack stackSettings = stackPrefab.GetComponent<Stack>();
            maxValue = (int)((rows * columns * stackSettings.value) * ((maxFeetHeight * 0.3048) / stackSettings.worldDimensions.y));
            maxValue = (int)(maxValue / stackSettings.value) * stackSettings.value; 
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

        ///bugged
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

