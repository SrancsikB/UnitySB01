using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    [SerializeField] Collider2D collider;

    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sizeY = cam.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(sizeY * cam.aspect, sizeY);
        Vector2 cameraCenter = cam.transform.position;
        Rect cameraRect = new Rect(cameraCenter - (cameraSize / 2), cameraSize);

        Bounds objectBound = collider.bounds;
        //Rect objectRect = new Rect(objectBound.min, objectBound.center);
        Rect objectRect = new Rect(objectBound.min, objectBound.extents);

        if (!cameraRect.Overlaps(objectRect))
        {
            //Teleport

            if (cameraRect.xMax < objectRect.xMin)
                transform.position = new Vector2(cameraRect.xMin + objectRect.size.x / 2, transform.position.y);
            else if (cameraRect.xMin > objectRect.xMax)
                transform.position = new Vector2(cameraRect.xMax - objectRect.size.x / 2, transform.position.y);

            if (cameraRect.yMax < objectRect.yMin)
                transform.position = new Vector2(transform.position.x, cameraRect.yMin + objectRect.size.y / 2);
            else if (cameraRect.yMin > objectRect.yMax)
                transform.position = new Vector2(transform.position.x, cameraRect.yMax - objectRect.size.y / 2);

            
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);


    }
}
