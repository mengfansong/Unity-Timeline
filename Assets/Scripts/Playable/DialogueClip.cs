using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;




public class DialogueClip : PlayableAsset
{

    public DialogueBehavior template = new DialogueBehavior();

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        //throw new System.NotImplementedException();
        var playable = ScriptPlayable<DialogueBehavior>.Create(graph,template);
        return playable;
    }

    
}
