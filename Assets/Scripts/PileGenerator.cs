using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CashSpawning
{
    public class PileGenerator : MonoBehaviour
    {
        public float money;
        public Transform PileParent;
        public GameObject CashPilePrefab;

        public void createPile()
        {
            float spawnedMoney = 0;
            while (spawnedMoney < money)
            {
                float maxPileValue = CashPilePrefab.GetComponent<CashPile>().maxPileValue;
                float moneyLeftToSpawn = money - spawnedMoney; 
                float pileMoney = moneyLeftToSpawn < maxPileValue ? moneyLeftToSpawn : maxPileValue;
                spawnedMoney += pileMoney;

                CashPile spawnedPile = Instantiate(CashPilePrefab, PileParent).GetComponent<CashPile>();

                spawnedPile.dollarValue = pileMoney;
                spawnedPile.spawnStack();
            }
        }
    }
}

