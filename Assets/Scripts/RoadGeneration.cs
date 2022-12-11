using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGeneration : MonoBehaviour
{

    public GameObject CarRoad;
    public GameObject[] CarRoadPos;
    public int StartNumOfRoads;
    public int MiddleNumOfRoads;
    public int FinishNumOfRoads;

    public int RealStartNumOfRoads;
    public int RealMiddleNumOfRoads;
    public int RealFinishNumOfRoads;

    public int NumOfPos;
    void Start()
    {
        StartNumOfRoads = Random.Range(1, 2);
        MiddleNumOfRoads = Random.Range(1, 4);
        FinishNumOfRoads = Random.Range(1, 2);

        RealStartNumOfRoads = 0;
        RealMiddleNumOfRoads = 0;
        RealFinishNumOfRoads = 0;

        for (RealStartNumOfRoads = 0; RealStartNumOfRoads < StartNumOfRoads; RealStartNumOfRoads++)
        {
            NumOfPos = Random.Range(0, 1);
            Instantiate(CarRoad, CarRoadPos[NumOfPos].transform.position, Quaternion.identity);
            Destroy(CarRoadPos[NumOfPos]);
        }
        for (RealMiddleNumOfRoads = 0; RealMiddleNumOfRoads < MiddleNumOfRoads; RealMiddleNumOfRoads++)
        {
            NumOfPos = Random.Range(2, 5);
            Instantiate(CarRoad, CarRoadPos[NumOfPos].transform.position, Quaternion.identity);
            Destroy(CarRoadPos[NumOfPos]);
        }
        for (RealFinishNumOfRoads = 0; RealFinishNumOfRoads < FinishNumOfRoads; RealFinishNumOfRoads++)
        {
            NumOfPos = Random.Range(6, 7);
            Instantiate(CarRoad, CarRoadPos[NumOfPos].transform.position, Quaternion.identity);
            Destroy(CarRoadPos[NumOfPos]);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SpawnedRoad")
        {
            Destroy(other.gameObject);
        }
    }
}
