using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreativeModeView : MonoBehaviour
{
    public Transform Pivot;
    public Animator Animator;
    public Camera Camera;
    private static readonly int IsHold = Animator.StringToHash("IsHold");

    public bool IsEnabled = false;

    void Start()
    {
        IsEnabled = PlayerPrefs.GetInt("CreativeMode") == 1;
        
        if(!IsEnabled)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Pivot.position = new Vector3(pos.x, pos.y, pos.z) + Pivot.forward;
        
        if (Input.GetMouseButton(0))
        {
            Animator.SetBool(IsHold, true);
        }
        else
        {
            Animator.SetBool(IsHold, false);
        }
    }
}
