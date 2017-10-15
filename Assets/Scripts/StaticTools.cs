using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Common methods used in different places in the game.
/// </summary>
class StaticTools
{
    /// <summary>
    /// Remaps a value from one range to another.
    /// </summary>
    /// <param name="value">The value you want to remap</param>
    /// <param name="from1">Starting value of the actual range</param>
    /// <param name="to1">Ending value of the actual range</param>
    /// <param name="from2">Starting value of the new range</param>
    /// <param name="to2">Starting value of the new range</param>
    /// <returns>The value remapped in the new range</returns>
    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    /// <summary>
    /// Deep copies a Vector3 object
    /// </summary>
    /// <param name="v">Actual Vector3 object</param>
    /// <returns>Deep-copied Vector3 obbject</returns>
    public static Vector3 CloneVector3(Vector3 v)
    {
        Vector3 newVector3 = new Vector3(v.x, v.y, v.z);
        return newVector3;
    }

    /// <summary>
    /// Deep copies a Vector2 object
    /// </summary>
    /// <param name="v">Actual Vector2 object</param>
    /// <returns>Deep-copied Vector2 obbject</returns>
    public static Vector3 CloneVector2(Vector2 v)
    {
        Vector2 newVector2 = new Vector2(v.x, v.y);
        return newVector2;
    }

    /// <summary>
    /// Deep copies a Quaternion object
    /// </summary>
    /// <param name="q">Actual Quaternion object</param>
    /// <returns>Deep-copied Quaternion object</returns>
    public static Quaternion CloneQuaternion(Quaternion q)
    {
        Vector3 eulerAngles = q.eulerAngles;
        Quaternion newQuaternion = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        return newQuaternion;
    }

    /// <summary>
    /// Returns the time passed since game started in milliseconds.
    /// </summary>
    /// <returns>The time passed since game started in milliseconds.</returns>
    public static long GetCurrentTimeMillis()
    {
        return (long)(Time.time*1000);
    }

    public static IEnumerator NotifyCollectible(GameObject instance, int maxDistance)
    {
        float initY = instance.transform.position.y;
        float stepDist = 0.1f;
        float stepTime = 0.01f;
        while (instance.transform.position.y < initY + maxDistance)
        {
            Vector3 pos = instance.transform.position;
            pos.y += stepDist;
            instance.transform.position = pos;
            yield return new WaitForSeconds(stepTime);
        }
        Object.Destroy(instance);
    }
}
