using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MoviieScripts : MonoBehaviour
{
    VideoPlayer videoplayer;

    public List<VideoClip> videos = new List<VideoClip>(); // 비디오들
    public List<float> videosTime = new List<float>(); // 비디오 시간들

    public GameObject restartBtn;

    int videoCnt;
    int videoIdx;

    // Start is called before the first frame update
    void Start()
    {
        int videoIdx = 0;

        videoplayer = GetComponent<VideoPlayer>();
        videoCnt = videos.Count;

        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        for(int i = 0; i < videos.Count; i++) 
        {
            videoplayer.clip = videos[i];
            videoplayer.Play();
            yield return new WaitForSeconds(videosTime[i]);
        }

        restartBtn.SetActive(true);

    }

    public void Restart()
    {
        int videoIdx = 0;

        StartCoroutine(PlayVideo());
    }
}
