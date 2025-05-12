using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed = 3.0f;
    public float smoothing = 5.0f; // Smoothing factor for camera movement
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // 2. Convert to world position
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

        // 3. Set the camera position (with smoothing)
        if(((worldPoint.x <= 0) && (worldPoint.x >= Screen.width * -1.5f))){
            transform.position = new Vector3 (Mathf.Lerp(transform.position.x, worldPoint.x, smoothing * Time.deltaTime),transform.position.y, transform.position.z);
        }
        if(((worldPoint.y <= 0) && (worldPoint.y >= Screen.height * -1.5f))){
            transform.position = new Vector3 (transform.position.x, Mathf.Lerp(transform.position.y, worldPoint.y, smoothing * Time.deltaTime), transform.position.z);
        }
    
    }

    
}
