using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 target;



    [SerializeField]
    private HarvestManager harvestManager;


    private void Start()
    {
        StartHarvest();
    }

    public void StartHarvest()
    {
        harvestManager.isHarvestStart = true;
    }

    void Update()
    {
        if (harvestManager.isHarvestStart)
        {
            if(harvestManager.currentHarvest < harvestManager.HarvestPost.Count)
            {
                target = harvestManager.HarvestPost[harvestManager.currentHarvest].position;
                MoveHarvest();
            }
        }
    }

    private void MoveHarvest()
    {
        float step = speed * Time.deltaTime;

        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
    }


}
