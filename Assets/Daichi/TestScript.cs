using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class TestScript : MonoBehaviour
{

    GameObject dialog;
    AndroidJavaObject cls;
    void Start()
    {
        
        #if UNITY_ANDROID
        AndroidJavaClass nativeDialog = new AndroidJavaClass("com.jp.ray.mybluetooth.NativeToast");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        context.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            nativeDialog.CallStatic(
                "showToast",
                context,
                "testMessage"
            );
        }));
        Debug.Log("start class");
        cls = new AndroidJavaObject("com.jp.ray.mybluetooth.Blue","ESP32Test2");
        Debug.Log("devides:"+cls.Call<string>("getAllDevices"));

        if (!Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_CONNECT")) {
            Debug.Log("request");
            Permission.RequestUserPermission("android.permission.BLUETOOTH_CONNEC");
        } else {
            Debug.Log("connect");
            cls.Call<bool>("connect");
            cls.Call("sendMessage", "On");
            dialog = new GameObject();
            //OnOffDialog c = dialog.AddComponent<OnOffDialog>();
            //c.setInstance(cls);
        }
        #else
        Debug.Log("not supported");
        #endif
    }

    bool sendOn = false;

    void Update() {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1) {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];
            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                if (!sendOn) {
                    sendOn = true;
                    cls.Call("sendMessage", "On");
                }
            } else if(sendOn) {
                sendOn = false;
                cls.Call("sendMessage", "Off");
            }
        }
    }


}
