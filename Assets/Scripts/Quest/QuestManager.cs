using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject hive1;
    public GameObject hive2;
    public GameObject hive3;

    // Make QuestNumber public and static
    public static int QuestNumber = 1;

    // Call this function whenever the variable is set to a new value
    void Update()
    {
        if (QuestNumber == 1)
        {
            hive1.SetActive(true);
            hive2.SetActive(false);
            hive3.SetActive(false);
        }
        else if (QuestNumber == 2)
        {
            hive1.SetActive(true);
            hive2.SetActive(false);
            hive3.SetActive(false);
        }
        else if (QuestNumber == 3)
        {
            hive1.SetActive(false);
            hive2.SetActive(true);
            hive3.SetActive(false);
        }
        else if (QuestNumber == 4)
        {
            hive1.SetActive(false);
            hive2.SetActive(false);
            hive3.SetActive(true);
        }
    }
}