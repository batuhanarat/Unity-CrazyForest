using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButton2 : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private AudioClip _compressClip,_uncompressClip;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _source.PlayOneShot(_compressClip);    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _source.PlayOneShot(_uncompressClip);     }
}
