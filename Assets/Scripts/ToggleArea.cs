using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;


public class ToggleArea : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playableDirector.Play();
            GameManager.instance.gameMode = GameManager.GameMode.GamePlay;
        }
    }

    private void Start()
    {
        //Debug.Log("999 " + Persistence(999));
        //Debug.Log("12 " + Persistence(12));
    }


    public static bool IsIsogram(string str)
    {
        Dictionary<char, int> d = new Dictionary<char, int>();
        foreach (char c in str)
        {
            char c1;
            c1 = char.ToUpper(c);
            if (d.ContainsKey(c1) == false)
            {
                d.Add(c1, 1);
            }
            else
            {
                d[c1] += 1;
            }

            if (char.IsLetter(c1) == false)
            {
                return false;
            }
        }
        foreach (KeyValuePair<char, int> kv in d)
        {
            if (kv.Value > 1)
            {
                return false;
            }
        }
        return true;
    }

    public static int Persistence(long n)           //39
    {

        int result = 0;    
        
        if (n<=9)
        {
            return result;
        }

        while (n>9)                                                            
        {
            long temp = 1;
            
            while (n > 9)
            {
                temp *= n % 10;
                n /= 10;
            }
            n *= temp;             
            result++;                                   
        }
        
        return result;
    }


}
