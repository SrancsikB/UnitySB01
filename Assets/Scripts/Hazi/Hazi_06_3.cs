using UnityEngine;
using System.Collections.Generic;

public class Hazi_06_3 : MonoBehaviour
{
    [SerializeField] Vector3 gravity = new Vector3(0, -9.81f, 0);
    [SerializeField] float speed = 5f;
    [SerializeField] float drag = 0.1f;
    [SerializeField] float timeStep = 0.1f;
    [SerializeField] float maxTime = 2f;

    List<Vector3> TrajectoryCalc(Vector3 position, Vector3 velocity, Vector3 gravity, float drag, float timeStep, float maxTime)
    {
        var points = new List<Vector3>();
        timeStep = Mathf.Max(timeStep, 0.001f);
        maxTime = Mathf.Max(maxTime, timeStep);

        for (float t = 0; t < maxTime; t += timeStep)
        {
            points.Add(position);
            position += velocity * timeStep;
            velocity += gravity * timeStep;
            velocity *= 1 - drag * timeStep;
        }

        return points;
    }

    private void OnDrawGizmos()
    {
        List<Vector3> trajectory;
        trajectory = TrajectoryCalc(transform.position, transform.forward * speed, gravity, drag, timeStep, maxTime);
        Gizmos.color = Color.yellow;
        foreach (Vector3 item in trajectory)
        {
            Gizmos.DrawSphere(item, 0.1f);
        }

    }
}
