using UnityEngine;

/// <summary>
/// Class responsible for the camera input.
/// This class is used for camera panning and zoom funcionality.
/// </summary>
/// <remarks>
/// @note In order to pan the camera the user must press the right mouse button.
/// @note In order to zoom the camera the user must press the buttons in the top left corner.
/// </remarks>
public class CameraPan : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;
    private bool pan = true;


    // Update is called once per frame
    private void Update()
    {
        if(pan) PanCamera();
    }

    /// <summary>
    /// Function responsible for the panning of the camera.
    /// To use the camera movement press the right mouse button.
    /// </summary>
    private void PanCamera()
    {
        // If right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Saves mouse coordinates
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        // If mouse button is held
        if (Input.GetMouseButton(1))
        {
            // Updates camera position according to mouse movement
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }
    /// <summary>
    /// Function responsible for enabling or disabling the camera movement.
    /// </summary>
    public void EnablePan()
    {
        if (pan) pan = false;
        else pan = true;
    }

    /// <summary>
    /// Function responsible for zooming in the camera.
    /// Zooms in the camera by 10%
    /// </summary>
    public void ZoomIn()
    {
        cam.orthographicSize = cam.orthographicSize / 1.1f;
    }
    /// <summary>
    /// Function responsible for zooming out the camera.
    /// Zooms out the camera by 10%
    /// </summary>
    public void ZoomOut()
    {
        cam.orthographicSize = cam.orthographicSize * 1.1f;
    }
}
