using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayableDirector currentPlayableDirector;


    public enum GameMode
    {
        Normal,
        GamePlay,
        DialogueMoment
    }

    public GameMode gameMode;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        gameMode = GameMode.Normal;
        Application.targetFrameRate=30;
    }


    private void Update()
    {
        if (gameMode == GameMode.DialogueMoment)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResumeTimeline();
            }
        }


        
    }

    public void PauseTimeline(PlayableDirector playableDirector)
    {
        currentPlayableDirector = playableDirector;
        gameMode = GameMode.DialogueMoment;
        currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);
        UIManager.UIinstance.ToggleSpacebar(true);
    }

    public void ResumeTimeline()
    {
        //currentPlayableDirector = playableDirector;
        gameMode = GameMode.GamePlay;
        currentPlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
        UIManager.UIinstance.ToggleSpacebar(false);
        UIManager.UIinstance.ToggleDialogueBox(true);
    }

    public void FinishedCG()
    {
        gameMode = GameMode.Normal;
    }

}
