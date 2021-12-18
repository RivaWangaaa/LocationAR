using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PocketPetsSceneManager : MonoBehaviour
{
    public abstract void playerTapped(GameObject player);
    public abstract void petTapped(GameObject pet);
}
