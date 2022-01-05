using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{ 
    public static void DestroyAllChildrean(this Transform parentTransform)
    {
        foreach(Transform t in parentTransform)
        {
            GameObject.Destroy(t.gameObject);
        }
    }
}
