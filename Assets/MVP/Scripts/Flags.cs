using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Flags
{
    private static int startScene = 0;
    public static int scene = 0;
    public static int numScenes = 20;
    public static bool reverseSceneOrder = false;
    public static bool orderSet = false;

    public static void SetStartScene(int index)
    {
        startScene = index;
        scene = startScene;
    }

    public static string GetNextScene
    {
        get
        {
            scene += reverseSceneOrder ? -1 : 1;

            if (scene < 1)
                scene = numScenes;
            else if (scene > numScenes)
                scene = 1;

            if (scene == startScene)
                Application.Quit();

            return scene.ToString();
        }
    }
}
