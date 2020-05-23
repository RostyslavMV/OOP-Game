using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange;
    private CameraMovement camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camera.minPosition.x += cameraMinChange.x;
            camera.minPosition.y += cameraMinChange.y;
            camera.maxPosition.x += cameraMaxChange.x;
            camera.maxPosition.y += cameraMaxChange.y;
            other.transform.position += playerChange;
        }
    }
}
