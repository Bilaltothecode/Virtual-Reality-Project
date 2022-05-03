using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject white1, white2, white3, red1, red2, red3, green1, green2, green3, blue1, blue2, blue3;

    public void SpawnWeight(string type)
    {
        GameObject toSpawn;
        switch (type)
        {
            case "red":
                switch (Random.Range(0, 3))
                {
                    case 0:
                        toSpawn = red1;
                        break;
                    case 1:
                        toSpawn = red2;
                        break;
                    default:
                        toSpawn = red3;
                        break;
                }
                break;
            case "green":
                switch (Random.Range(0, 3))
                {
                    case 0:
                        toSpawn = green1;
                        break;
                    case 1:
                        toSpawn = green2;
                        break;
                    default:
                        toSpawn = green3;
                        break;
                }
                break;
            case "blue":
                switch (Random.Range(0, 3))
                {
                    case 0:
                        toSpawn = blue1;
                        break;
                    case 1:
                        toSpawn = blue2;
                        break;
                    default:
                        toSpawn = blue3;
                        break;
                }
                break;
            default:
                switch (Random.Range(0, 3))
                {
                    case 0:
                        toSpawn = white1;
                        break;
                    case 1:
                        toSpawn = white2;
                        break;
                    default:
                        toSpawn = white3;
                        break;
                }
                break;
        }
        toSpawn = Instantiate(toSpawn);
        toSpawn.transform.position = transform.position;
    }
}
