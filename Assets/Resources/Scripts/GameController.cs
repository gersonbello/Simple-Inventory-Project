using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController _gc;
    public static GameController gc
    {
        get
        {
            if(_gc == null) _gc = FindObjectOfType<GameController>();
            if(_gc == null) _gc = Instantiate(new GameObject()).AddComponent<GameController>();
            return _gc;
        }
    }
}
