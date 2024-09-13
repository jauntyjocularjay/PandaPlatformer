using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static FractionScale;



[CreateAssetMenu(menuName = "ScriptableObjects/BackgroundData")]
public class BackgroundData : ScriptableObject
{
    public string alias;
    public FractionScale scrollProgress = new(0,512); 



}


