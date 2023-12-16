using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SerialLib;
using System.IO.Ports;
using System.Management;
using System.Runtime.InteropServices;
using System;

public class BluetoothTest : MonoBehaviour
{
    [DllImport("NativeBluetoothPlugin", CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr GetNumber(string input);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Marshal.PtrToStringAnsi(GetNumber("aaaa")));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
