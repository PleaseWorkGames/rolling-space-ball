using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[
    RequireComponent(typeof(PlayerController))
]
public class Player : MonoBehaviour {

	
    void OnDestroy() {
       World.reloadScene(); 
    }
}
