using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public StageManager instance;
    public static int enemykill = 0;

    [field:SerializeField]
    public static int stageLevel = 1;

    private void Awake()
    {
        instance = this;
    }
}
