using UnityEngine;

public class CameraUtils
{
    static Camera camera;

    public static Camera main
    {
        get
        {
            return camera == null ? getCamera() : camera;
        }
    }

    static Camera getCamera()
    {
        camera = Camera.main;
#if UNITY_EDITOR
        if(camera == null)
        {
            camera = new GameObject().AddComponent<Camera>();
            camera.orthographic = true;
        }
#endif
        return camera;
    }

    public static void SetCameraSize(Camera camera)
    {
        float ratio = (float)Screen.width / Screen.height;
        float fov = Mathf.Pow(ratio - 0.6666f, 2) * 275 + 54;
        camera.fieldOfView = fov;
    }
}
