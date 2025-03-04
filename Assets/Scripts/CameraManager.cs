using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] Camera cam;
    Rect cameraRect;

    public Rect GetCameraRect()
    {
        return cameraRect;
    }


    public Vector3 GetRandomPositionInCamera()
    {
        float x = Random.Range(cameraRect.xMin, cameraRect.xMax);
        float y = Random.Range(cameraRect.yMin, cameraRect.yMax);

        return  new Vector3(x, y);
    }
    void OnValidate()   
    {
        if (cam==null)
        {
            cam = GetComponent<Camera>();
        }
    }

    void Awake()
    {
        Calc();
    }

    // Update is called once per frame
    void Update()
    {
        Calc();
    }

    void Calc()
    {
        float sizeY = cam.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(sizeY * cam.aspect, sizeY);
        Vector2 cameraCenter = cam.transform.position;
        cameraRect = new Rect(cameraCenter - (cameraSize / 2), cameraSize);
    }
}
