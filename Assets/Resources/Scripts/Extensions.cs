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

    #region Animations
    public static IEnumerator AnimateScale(this Transform parentTransform, float duration, AnimationCurve animationCurve)
    {
        Vector3 targetSize = parentTransform.transform.localScale;
        parentTransform.transform.localScale = new Vector3();
        Vector3 currentSize = parentTransform.transform.localScale;

        float timer = 0;
        float animTime;

        while (timer <= duration)
        {
            animTime = timer / duration;
            parentTransform.transform.localScale = targetSize * animationCurve.Evaluate(animTime);
            currentSize = parentTransform.transform.localScale;
            timer += Time.deltaTime;
            yield return null;
        }
        parentTransform.transform.localScale = targetSize;
    }

    public static IEnumerator AnimateScale(this Transform parentTransform, float duration, AnimationCurve animationCurve, bool setActive)
    {
        Vector3 targetSize = parentTransform.transform.localScale;
        parentTransform.transform.localScale = new Vector3();
        Vector3 currentSize = parentTransform.transform.localScale;

        float timer = 0;
        float animTime;

        while (timer <= duration)
        {
            animTime = timer / duration;
            parentTransform.transform.localScale = targetSize * animationCurve.Evaluate(animTime);
            currentSize = parentTransform.transform.localScale;
            timer += Time.deltaTime;
            yield return null;
        }
        parentTransform.transform.localScale = targetSize;
        parentTransform.gameObject.SetActive(setActive);
    }
    #endregion
}
