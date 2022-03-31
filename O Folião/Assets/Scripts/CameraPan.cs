using UnityEngine;

/// <summary>
/// Class responsible for the camera input.
/// This class is used for camera panning funcionality.
/// </summary>
/// <remarks>
/// @note In order to pan the camera the user must press the right mouse button.
/// </remarks>
public class CameraPan : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;
    private bool pan = true;

    [SerializeField]
    private SpriteRenderer map;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;


    // Update is called once per frame
    private void Update()
    {
        if(pan) PanCamera();
    }


    /// <summary>
    /// Responsible for limiting the cam movement according to the size of the 
    /// map sprite.
    /// </summary>
    private void Awake()
    {
        mapMinX = map.transform.position.x - map.bounds.size.x / 2f;
        mapMaxX = map.transform.position.x + map.bounds.size.x / 2f;

        mapMinY = map.transform.position.y - map.bounds.size.y / 2f;
        mapMaxY = map.transform.position.y + map.bounds.size.y / 2f;
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidht = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidht;
        float maxX = mapMaxX - camWidht;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
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

            cam.transform.position = ClampCamera(cam.transform.position + difference);
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
}
