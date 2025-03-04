using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float moveDelay = 10;
    [SerializeField] float shootDelay = 5;
    [SerializeField] float smoothTime = 1;

    [SerializeField] Projectile projectile;


    private void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }


    float moveTimer;
    float shootTimer = 0;
    Vector3 targetPosition;
    

    CameraManager cameraManager;
    SpaceShipController spaceShipController;
    private void Start()
    {
        cameraManager = FindAnyObjectByType<CameraManager>();
        spaceShipController = FindAnyObjectByType<SpaceShipController>();
        MoveToNext();
    }

    void Update()
    {
        moveTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        if (moveTimer > moveDelay)
        {
            MoveToNext();
            moveTimer -= moveDelay;//Kerekítés
        }

        if (shootTimer > shootDelay)
        {
            Shoot();
            shootTimer -= shootDelay;//Kerekítés
        }

        Vector2 v = rigidBody.linearVelocity;

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        rigidBody.position = Vector2.SmoothDamp(transform.position, targetPosition, ref v, smoothTime, float.MaxValue, Time.deltaTime);
        rigidBody.linearVelocity = v;
    }

    void MoveToNext()
    {

        Rect cameraRect = cameraManager.GetCameraRect();
        targetPosition = cameraManager.GetRandomPositionInCamera();
      

        //System.Random random = new(1234); //seed
       // random.NextDouble();
    }


    void Shoot()
    {
        if (spaceShipController == null) return;
        Vector3 spacesipPoint = spaceShipController.transform.position;
        Vector3 selfPoint = transform.position;

        Vector3 direction = spacesipPoint - selfPoint;
        direction.Normalize();

        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        angleDeg -= 90;

        //float angleDeg2 = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion projectileRotation = Quaternion.Euler(0, 0, angleDeg);



        Projectile newProjectile = Instantiate(projectile, transform.position, projectileRotation);
        newProjectile.SetStartVelocity(Vector3.zero);
    }
    /*
     * 
    [SerializeField] float moveDelay = 10;
    [SerializeField] float shootDelay = 5;
    [SerializeField] float smoothTime = 1;

    [SerializeField] Projectile projectile;

    float moveTimer;
    float shootTimer = 0;
    Vector3 targetPosition;
    Vector3 velocity;

    CameraManager cameraManager;
    SpaceShipController spaceShipController;
    private void Start()
    {
        cameraManager = FindAnyObjectByType<CameraManager>();
        spaceShipController = FindAnyObjectByType<SpaceShipController>();
        MoveToNext();
    }

    void Update()
    {
        moveTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        if (moveTimer > moveDelay)
        {
            MoveToNext();
            moveTimer -= moveDelay;//Kerekítés
        }

        if (shootTimer > shootDelay)
        {
            Shoot();
            shootTimer -= shootDelay;//Kerekítés
        }


        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, float.MaxValue, Time.deltaTime);
    }

    void MoveToNext()
    {

        Rect cameraRect = cameraManager.GetCameraRect();
        targetPosition = cameraManager.GetRandomPositionInCamera();
      

        //System.Random random = new(1234); //seed
       // random.NextDouble();
    }


    void Shoot()
    {
        if (spaceShipController == null) return;
        Vector3 spacesipPoint = spaceShipController.transform.position;
        Vector3 selfPoint = transform.position;

        Vector3 direction = spacesipPoint - selfPoint;
        direction.Normalize();

        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        angleDeg -= 90;

        //float angleDeg2 = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion projectileRotation = Quaternion.Euler(0, 0, angleDeg);



        Projectile newProjectile = Instantiate(projectile, transform.position, projectileRotation);
        newProjectile.SetStartVelocity(Vector3.zero);
    }
     */
}
