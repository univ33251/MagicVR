using UnityEngine.Android;
using UnityEngine;

public class OnOffDialog: MonoBehaviour {
    const int kDialogWidth = 800;
    const int kDialogHeight = 400;
    AndroidJavaObject javaInstance;

    public void setInstance(AndroidJavaObject javaInstance) {
        this.javaInstance = javaInstance;
    }

    void DoMyWindow(int windowID) {
        if (javaInstance != null) {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 50;

            GUI.Label(new Rect(10, 20, kDialogWidth - 20, kDialogHeight - 50), "Press to on/off LED.");
            if (GUI.Button(new Rect(kDialogWidth / 2+15, 30,kDialogWidth/2-30,kDialogHeight-50), "OFF",myButtonStyle)) {
                javaInstance.Call("sendMessage", "Off");
            }
            if (GUI.Button(new Rect(15, 30, kDialogWidth/2-30, kDialogHeight-50), "ON",myButtonStyle)) {
                javaInstance.Call("sendMessage", "On");
            }
        }
    }

    void OnGUI() {
        Rect rect = new Rect((Screen.width / 2) - (kDialogWidth / 2), (Screen.height / 2) - (kDialogHeight / 2), kDialogWidth, kDialogHeight);
        GUI.ModalWindow(0, rect, DoMyWindow, "On/Off Dialog");
    }
}