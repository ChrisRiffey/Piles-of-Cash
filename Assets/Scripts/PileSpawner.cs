using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CashSpawning
{
    public class PileSpawner : MonoBehaviour
    {


        public GameObject cashPilePrefab, singleMeshCashPilePrefab;
        public int moneyToSpawn;
        public float spawnInterval;

        [Tooltip("Indexes refer to the children in SpawnLocations")]
        public int[] spawnOrder;
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
            pilesAmt = (int)(moneyToSpawn % CashPile.MAXTOTALVALUE);  
            SPPilesAmt = (int)(moneyToSpawn / CashPile.MAXTOTALVALUE);

            spawnPos = transform.position;

            spawnsMade = 0;
            InvokeRepeating("spawnStack", 0f, spawnInterval);
        }

        void spawnStack()
        {
            Vector3 spawnPos = transform.GetChild(0).GetChild(spawnOrder[spawnsMade]).position;
            if (spawnsMade >= SPPilesAmt)
            {
                CancelInvoke("spawnStack");
                if (pilesAmt > 0)
                {
                    CashPile cp = Instantiate(cashPilePrefab, spawnPos, Quaternion.identity, transform).GetComponent<CashPile>();
                    if (SPPilesAmt > 0)
                        Invoke("triggerOnSpawnComplete", cp.spawnStack(pilesAmt, false));
                    else
                        Invoke("triggerOnSpawnComplete", cp.spawnStack(pilesAmt, true));
                    return;
                }
            }


            Instantiate(singleMeshCashPilePrefab, spawnPos, Quaternion.identity, transform);

            spawnsMade++;
        }

        void triggerOnSpawnComplete()
        {
            OnSpawningCompleted.Invoke(); 
        }
      
    }
}

