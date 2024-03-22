using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

}
