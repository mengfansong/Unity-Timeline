using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;



[System.Serializable]
public class DialogueBehavior : PlayableBehaviour
{
    private PlayableDirector playableDirector;

    public string characterName;
    [TextArea(8,1)] public string dialogueLine;
    public int dialogueSize;

    private bool isClipPlayed;          //这个片段是否播放结束
    public bool requirePause;           //这个片段播放后是否需要暂停
    private bool pauseScheduled;        

    public override void OnPlayableCreate(Playable playable)
    {
        //base.OnPlayableCreate(playable);
        playableDirector = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //base.ProcessFrame(playable, info, playerData);
        if(isClipPlayed==false && info.weight > 0)
        {
            UIManager.UIinstance.SetupDialogue(characterName, dialogueLine, dialogueSize);

            //如果这个片段播放后需要暂停
            if (requirePause)
            {
                pauseScheduled = true;
            }

            isClipPlayed = true;
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        isClipPlayed = false;
        Debug.Log("Clip is stopped");

        //base.OnBehaviourPause(playable, info);
        if (pauseScheduled)
        {
            pauseScheduled = false;
            //暂停timeline播放
            GameManager.instance.PauseTimeline(playableDirector);
        }
        else
        {
            UIManager.UIinstance.ToggleDialogueBox(false);
        }
    }

}
