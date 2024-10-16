using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLobby1F : MonoBehaviour
{
    public void GoPlace()
    {
        SceneManager.LoadScene("Lobby(F1)_next_Scene");
    }
}
