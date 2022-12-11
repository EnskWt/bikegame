using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] car;
    public GameObject[] spawnPos;

    private int carNum;
    private int spawnPosNum;

    private float TimeBtwSpawns;
    public float StartTimeBtwSpawns;

    private Quaternion carQuaternion;
    void Start()
    {
        TimeBtwSpawns = StartTimeBtwSpawns;

        carNum = Random.Range(0, car.Length);
        spawnPosNum = Random.Range(0, spawnPos.Length);
        if (spawnPosNum == 0)
        {
            carQuaternion = new Quaternion(0, 360, 0, 1);
        }
        else
        {
            carQuaternion = new Quaternion(0, 0, 0, 1);
        }
        Instantiate(car[carNum], spawnPos[spawnPosNum].transform.position, carQuaternion);
    }


    void Update()
    {
        if (TimeBtwSpawns <= 0)
        {
            carNum = Random.Range(0, car.Length);
            spawnPosNum = Random.Range(0, spawnPos.Length);
            if (spawnPosNum == 0)
            {
                carQuaternion = new Quaternion(0, 360, 0, 1);
            }
            else
            {
                carQuaternion = new Quaternion(0, 0, 0, 1);
            }
            Instantiate(car[carNum], spawnPos[spawnPosNum].transform.position, carQuaternion);

            TimeBtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
            TimeBtwSpawns -= Time.deltaTime;
        }
    }
}
