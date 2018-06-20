using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PrefabContainer", 
    menuName = "Scene Management/Prefab Container")]

public class AiPrefabsContainer : ScriptableObject {

    public List<GameObject> prefabs;

}
