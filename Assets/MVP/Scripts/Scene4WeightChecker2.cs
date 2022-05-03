using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene4WeightChecker2 : WeightChecker
{
    [SerializeField]
    Animator fadeAnimator;
    public static bool weightGood = false;

    protected override void HitTarget()
    {
        weightGood = true;
    }
}
