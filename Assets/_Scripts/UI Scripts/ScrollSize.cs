using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSize : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.ScrollRect _scrollRect;

    // Start is called before the first frame update
    void Start()
    {
        _scrollRect.verticalNormalizedPosition = 1.0f;

    }

   
}
