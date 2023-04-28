using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    public void addPoints(int points)
    {
        score += points;
    }
}
