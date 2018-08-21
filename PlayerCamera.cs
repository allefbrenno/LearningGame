using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public float smoothSpeed = 0.125f;
    public Transform player;
    public Vector3 offset;

    private void FixedUpdate()
    {

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
        
    }
}


