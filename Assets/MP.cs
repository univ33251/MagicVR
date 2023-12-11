using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP : MonoBehaviour
{

    public int maxMP;

    private int _mp;
    private int mp
    {
        set {
            _mp = value;
            if (OnChangeHandler != null)
            {
                OnChangeHandler(this, value);
            }
        }
        get => _mp;
    }

    public event EventHandler<int> OnChangeHandler;

    private void OnEnable()
    {
        _mp = maxMP;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMP(int mp)
    {
        if (mp <= maxMP)
        {
            this.mp = mp;
        }
    }

    public int GetMP()
    {
        return mp;
    }

    public void AddMP(int value)
    {
        mp = Math.Min(mp + value, maxMP);
    }

    public void RemoveMP(int value)
    {
        mp = Math.Max(mp - value, 0);
    }

    public int GetMaxMP() { return maxMP; }
    
    public void SetMaxMP(int maxMP)
    {
        this.maxMP = maxMP;
        if (mp > maxMP) { mp = maxMP; }
    }
}
