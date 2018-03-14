using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CashSpawning
{
    public class PileSpawner : MonoBehaviour
    {

        [Tooltip("Point the x-axis (red arrow) to the direction of spawning")]
        public GameObject cashPilePrefab, singleMeshCashPilePrefab;
        public int moneyToSpawn;
        public float spaceBetweenSpawns, spawnInterval;
        public UnityEvent OnSpawningCompleted;


        int pilesAmt, SPPilesAmt;
        int spawnsMade;
         
        Vector3 spawnPos;

        private void Start()
        {
            startSpawning(); 
        }
        public void startSpawning()
        {
            pilesAmt = (int)(moneyToSpawn / CashPile.MAXTOTALVALUE);  
            SPPilesAmt = (int)(moneyToSpawn % CashPile.MAXTOTALVALUE);

            spawnPos = transform.position;

            spawnsMade = 0;
            InvokeRepeating("spawnStack", 0f, spawnInterval);
        }

        void spawnStack()
        {
            if (spawnsMade >= SPPilesAmt)
            {
                CancelInvoke("spawnSingleMeshCP");
                if (pilesAmt > 0)
                {
                    CashPile cp = Instantiate(singleMeshCashPilePrefab, spawnPos, Quaternion.identity, transform).GetComponent<CashPile>();
                    Invoke("triggerOnSpawnComplete", cp.spawnStack());
                }
            }

            Instantiate(singleMeshCashPilePrefab, spawnPos, Quaternion.identity, transform);
            spawnPos += transform.right * spaceBetweenSpawns;

            spawnsMade++;
        }

        void triggerOnSpawnComplete()
        {
            OnSpawningCompleted.Invoke(); 
        }
      
    }
}

