using UnityEngine;

public class AsteriodManager : MonoBehaviour
{
    [SerializeField] Asteroid[] startAsteroids;
    [SerializeField] float distanceFromSpaceShip;


    void Start()
    {
        CameraManager cameraManager = FindAnyObjectByType<CameraManager>();
        SpaceShipController spaceShipController = FindAnyObjectByType<SpaceShipController>();
        Vector3 spaceShipPoint = spaceShipController.transform.position;

        foreach (Asteroid item in startAsteroids)
        {
            Vector3 position = Vector3.zero;
            int testCount = 10;
            for (int i = 0; i < testCount; i++)
            {
                position = cameraManager.GetRandomPositionInCamera();
                if (Vector3.Distance(position, spaceShipPoint) >= distanceFromSpaceShip)
                {
                    break;
                }

                if (i == testCount - 1)
                {
                    Debug.LogWarning("No valid asteriod position found");
                }
            }



            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            Asteroid newAseroid=Instantiate(item, position, rotation);

           

        }
    }

}
