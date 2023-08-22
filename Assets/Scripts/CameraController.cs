using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float smoothFactor;
    public Vector3 minValues, maxValue;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        player = PlayerChange.GetCurPlayer().transform;
        Vector3 targetPosition = player.position + offset;
        if (PlayerChange.GetCurPlayerIndex() != 0)
        {
            targetPosition = player.position + new Vector3(offset.x, 0, offset.z);
        }
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
            targetPosition.z
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
