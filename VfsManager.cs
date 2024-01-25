using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfsManager : MonoBehaviour
{

    public GameObject woodimpact, bloodimpact;
    public static VfsManager instance;



    private void Awake()
    {
        instance = this;
    }
}
