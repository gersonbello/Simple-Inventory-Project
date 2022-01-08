using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController _gc;

    public List<Vector2> applicationResolutions = new List<Vector2>();

    public AnimationCurve popUpAnimationCurve;
    public AnimationCurve popInAnimationCurve;
    public AnimationCurve popOutAnimationCurve;

    AudioSource _audiosource;
    public AudioSource audioSource 
    { 
        get
        {
            if (_audiosource == null)
                _audiosource = GetComponent<AudioSource>();
            return _audiosource;
        } 
    }

    int currentResolution;

    private void Awake()
    {
        Screen.SetResolution((int)applicationResolutions[0].x, (int)applicationResolutions[0].y, FullScreenMode.FullScreenWindow);
    }
    public static GameController gc
    {
        get
        {
            if(_gc == null) _gc = FindObjectOfType<GameController>();
            if(_gc == null) _gc = Instantiate(new GameObject()).AddComponent<GameController>();
            return _gc;
        }
    }

    public void ChangeResolution()
    {
        currentResolution++;
        currentResolution = (int)Mathf.Repeat(currentResolution, applicationResolutions.Count);
        Screen.SetResolution((int)applicationResolutions[currentResolution].x, (int)applicationResolutions[currentResolution].y, Screen.fullScreenMode);
        
    }
}
