using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightChecker : MonoBehaviour
{
    [SerializeField]
    int targetWeight = 5;
    [SerializeField]
    PositionDetector detector;
    [SerializeField]
    TextMeshPro tmp;

    bool hitTarget = false;

    void Update()
    {
        if (!hitTarget)
        {
            tmp.text = detector.totalWeight + "/" + targetWeight + "kg";
            if (detector.totalWeight == targetWeight)
            {
                tmp.color = Color.green;
                hitTarget = true;
                HitTarget();
            }
            else
            {
                if (detector.totalWeight == 0)
                    tmp.color = Color.white;
                else if (detector.totalWeight > targetWeight)
                    tmp.color = Color.red;
                else
                    tmp.color = Color.yellow;
            }
        }
    }

    protected virtual void HitTarget()
    {

    }
}
