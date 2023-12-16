using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

namespace SerialLib
{
    public class UnitySerial
    {
        SerialPort serial;
        
        public UnitySerial(string portName,int baudrate)
        {
            Init(portName,baudrate);
        }

        void Init(string portName,int baudrate)
        {
            serial = new SerialPort(portName, baudrate, Parity.None, 8, StopBits.One);
            try
            {
                serial.Open();
                serial.DtrEnable = true;
                serial.RtsEnable = true;
                serial.DiscardInBuffer();
                serial.ReadTimeout = 5;

            }
            catch(Exception e)
            {
                Debug.LogException(e);
                serial = null;
                return;
            }
        }

        public void SendMessage(string message)
        {
            serial.WriteLine(message);
        }
    }
}
