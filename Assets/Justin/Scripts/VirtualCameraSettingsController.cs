using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraSettingsController : MonoBehaviour
{
    public bool takePicture = false;

    enum Setting
    {
        FStop,
        ISO,
        Shutter,
        Zoom
    }
    [SerializeField]
    Setting setting;
    enum Direction
    {
        Up,
        Down
    }
    [SerializeField]
    Direction change;

    public VirtualCameraController virtualCameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (takePicture)
                virtualCameraController.TakePicture();
            else
            {
                switch (setting)
                {
                    case Setting.FStop:
                        virtualCameraController.AdjustFStop(change == Direction.Up);
                        break;
                    case Setting.ISO:
                        virtualCameraController.AdjustISO(change == Direction.Up);
                        break;
                    case Setting.Shutter:
                        virtualCameraController.AdjustShutterSpeed(change == Direction.Up);
                        break;
                    case Setting.Zoom:
                        virtualCameraController.Zoom(change == Direction.Up);
                        break;
                }
            }
        }
    }
}
