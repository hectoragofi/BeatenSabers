using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject songController;
    public SongC songControll;

    public GameObject realPlot;
    public GameObject proccessedPlot;

    public AudioClip[] clips;

    public int songToPlay = 1;
    void Start()
    {
        songController.SetActive(false);
        realPlot.SetActive(false);
        proccessedPlot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(int songNum)
    {
        songController.SetActive(true);

        songControll.songClip[0] = clips[songNum];

        realPlot.SetActive(true);
        proccessedPlot.SetActive(true);
    }
}
