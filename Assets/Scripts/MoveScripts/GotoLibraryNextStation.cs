using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLibraryNextStation : MonoBehaviour
{
    public void GoPlace()
    {
        SceneManager.LoadScene("Library(F6)_1_next_Scene");
    }
}
