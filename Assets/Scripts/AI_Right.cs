using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AI_Right : Agent
{
    [SerializeField] private Transform targetTransform;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(targetTransform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {  
        float moveY = actions.ContinuousActions[0];

        float moveSpeed = 8f;
        transform.position += new Vector3(0.0f, moveY, 0.0f) * Time.deltaTime * moveSpeed;
    }

    // public override void Heuristic(in ActionBuffers actionsOut)
    // {
    //     ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
    //     continuousActions[0] = Input.GetAxisRaw("Vertical");
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball)) {
            // Debug.Log("+2 right ball");
            AddReward(+2f);
        }
    }

    public void Punishment()
    {
        Debug.Log("OK");
        AddReward(-2f);
    }
}