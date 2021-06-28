using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class UserInterfaceClass
{
    public enum Showstyle {Transition = 0,SlideUp = 1, Normal = 2, Video = 3};
    public GameObject transitionObject;
    public string UIName;
    public GameObject UIObject;
    public Showstyle style;
    public float posy;
    public float dposy;
}
