using UnityEngine;

/// <summary>
/// Class responsible for the camera setup.
/// This class is used for camera resizing.
/// </summary>
public class CameraSettings
{
    private Camera cam = Camera.main;
    /// <summary>
    /// Function responsible for resizing the camera depending on the map.
    /// </summary>
    /// <param name="rows">Number of rows.</param>
    /// <param name="cols">Number of collums.</param>
    public void ResizeCamera(int rows, int cols)
    {
        //If the map is more vertical
        if (rows > cols/2)
            cam.orthographicSize = rows/2;
        else //If the map is more horizontal
            cam.orthographicSize = cols/1.5f;

        //Recenters map for the camera
        GameObject map = GameObject.Find("Map");
        map.transform.position = map.transform.position - new Vector3 (rows/2 + 0.5f, cols/2-0.5f);
    }

    /// <summary>
    /// Function responsible for activating the camera movement.
    /// </summary>
    public void ActivatePan()
    {
        cam.GetComponent<CameraPan>().enabled = true;
    }
}
