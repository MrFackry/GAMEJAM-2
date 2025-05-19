using UnityEngine;

public class GamePause : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
