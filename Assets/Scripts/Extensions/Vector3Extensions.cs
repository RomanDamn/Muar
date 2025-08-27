using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static bool GetIsEnoughClose(Vector3 start, Vector3 end, float movingAccuracy)
    {
        return GetSqrDistance(start, end) <= movingAccuracy * movingAccuracy;
    }

    public static float GetSqrDistance(Vector3 start, Vector3 end)
    {
        return (end - start).sqrMagnitude;
    }
}
