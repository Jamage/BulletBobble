using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    public static T GetRandomEnum<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        int num = (int)UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(num);
    }

    public static IEnumerator MovementTransition(Transform start, Transform end, float timespan = 1f) {
        float time = 0;
        while (time < timespan) {
            Vector3.Lerp(start, end, (time += Time.deltaTime) / timespan);
        }
    }
}
