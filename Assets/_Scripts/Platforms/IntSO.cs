using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Int Variable")]
public class IntSO : ScriptableObject
{

    [SerializeField] public int value = 0;

    void Start()
    {
        value = 0;
    }
    
    
}
