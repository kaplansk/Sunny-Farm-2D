using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public Transform clampMin, clampMax;
    private Camera cam;
    private float halfWidth, halfHeight;
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
        clampMin.SetParent(null);
        clampMax.SetParent(null);

        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize *cam.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
        Vector3 clampedPosition = transform.position;

        clampedPosition.x =Mathf.Clamp(clampedPosition.x, clampMin.position.x +halfWidth, clampMax.position.x -halfWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfHeight, clampMax.position.y -halfHeight);
        transform.position = clampedPosition;



    }
}
