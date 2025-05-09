using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraVelocity = Vector3.zero;
    public float aimTime = 0.2f;
    public GameObject cameraTarget;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cameraTarget = GameObject.Find("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log(Mouse.current.position);
        gameObject.transform.position = Vector3.SmoothDamp(transform.position, new Vector3(cameraTarget.transform.position.x, cameraTarget.transform.position.y, -2), ref cameraVelocity, aimTime);
    }
}
