using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestManager : MonoBehaviour
{

    public GameObject plantPrefabs;

    public List<Transform> HarvestPost;


    public bool isHarvestStart;

    [SerializeField]
    private float harvestTimer;
    private float orHarvestTimer;


    public int currentHarvest;

    private void Start()
    {
        //simpan nilai default timer ke orHarvestTimer
        orHarvestTimer = harvestTimer;
    }

    public void StartHarvest()
    {
        isHarvestStart = true;
    }

    private void Update()
    {
        if (isHarvestStart)
        {
            Harvest();
        }
    }

    private void Harvest()
    {

        //check apabila harvest belum selesai di index
        if (currentHarvest < HarvestPost.Count)
        {

            //harvesting process
            if (harvestTimer == orHarvestTimer)
            {
                SpawnTree(currentHarvest);
            }
            //timer pengurang
            harvestTimer -= Time.deltaTime;

            if (harvestTimer <= 0)
            {
                currentHarvest++;
                harvestTimer = orHarvestTimer;
            }
        }

        else
        {
            isHarvestStart = false;
            currentHarvest = 0;
        }
    }

    private void SpawnTree(int index)
    {
        Instantiate(plantPrefabs, HarvestPost[index].position, Quaternion.identity);
    }
}
