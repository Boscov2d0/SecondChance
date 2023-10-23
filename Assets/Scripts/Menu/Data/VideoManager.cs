using UnityEngine;

namespace SecondChanse.Menu.Data
{
    [CreateAssetMenu(fileName = nameof(VideoManager), menuName = "Managers/Menu/VideoManager")]
    public class VideoManager : ScriptableObject
    {
        [HideInInspector] public int ScreenResolutionsWidth;
        [HideInInspector] public int ScreenResolutionsHeight;
        [HideInInspector] public int ScreenResolutionsRefreshRate;
        [HideInInspector] public bool Fullscreen;
    }
}