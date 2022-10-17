using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Series : MonoBehaviour
{
    // Start is called before the first frame update

    public float[] TimeSubSolution;//第一个数据没用但是得插
    public int[] ButtonSeriesSolution;

    public float[] playerTimeSub;
    public int[] playerButtonSeries;

    private int currIndex;
    public int maxButtonPress;
    private float LastPressTime;
    private float playerPoints;

    public Text QualifiedText;
    public Text ScoreText;

    public void PressButton(int num)
    {
        playerButtonSeries[currIndex] = num;

        playerTimeSub[currIndex] = Time.time - LastPressTime;

        LastPressTime = Time.time;

        

        //DEBUG INFORMATION
        /*Debug.Log("In PressButton():");
        Debug.Log("playerTimeSub[currIndex]:");
        Debug.Log(playerButtonSeries[currIndex]);
        Debug.Log("LastPressTime:");
        Debug.Log(LastPressTime);*/

        currIndex++;

        /*if (currIndex < maxButtonPress)
        {
            currIndex++;
        }
        else
        {
            CheckSolution();
            currIndex = 0;
            LastPressTime = 0;
        }*/

        if (currIndex == maxButtonPress)
        {
            if (CheckSolution())
            {
                QualifiedText.text = "Qualified";
                ScoreText.text = "Your Score:" + playerPoints.ToString();
            }
            else
            {
                QualifiedText.text = "Failed";
                ScoreText.text = "Your Score:" + playerPoints.ToString();
            }
            currIndex = 0;
            LastPressTime = 0;
            playerPoints = 0;
            
        }

        
    }

    public void Reset()
    {
        currIndex = 0;
        QualifiedText.text = "Reset Completed";
        ScoreText.text = "";
        playerPoints = 0;
    }

    private bool CheckSolution()
    {
        /*Debug.Log("In CheckSolution:");*/
        const float MAXSCORE = 100;
        const float QUALIFYSCORE = 80;
        float pointsPerButton = (MAXSCORE / 2) / maxButtonPress;
        float pointsPerTimeSub = (MAXSCORE / 2) / (maxButtonPress-1);
        
        for(int i = 0; i < maxButtonPress; i++)
        {
            if (playerButtonSeries[i] == ButtonSeriesSolution[i])
            {
                playerPoints += pointsPerButton;
                if (i > 0)
                {
                    float pointsProportion = 0;
                    if (playerTimeSub[i] >= 2 * TimeSubSolution[i])
                    {
                        pointsProportion = 0;
                    }
                    else
                    {
                        float timeSub = playerTimeSub[i] - TimeSubSolution[i];
                        timeSub = timeSub >= 0 ? timeSub : (-timeSub);
                        pointsProportion = 1 - timeSub / TimeSubSolution[i];
                    }
                    playerPoints += pointsPerTimeSub * pointsProportion;
                }
                
            }

            Debug.Log("In index "+i.ToString()+" :");

            Debug.Log("playerPoints: " + playerPoints.ToString());

        }

        if (playerPoints >= QUALIFYSCORE)
        {
            Debug.Log("QUALIFIED!");
            return true;
        }
        else
        {
            Debug.Log("FAILED!");
            return false;
        }
    }



    void start()
    {
        currIndex = 0;
        LastPressTime = 0;
    }

    public void TestTime()
    {
        Debug.Log(Time.time);
    }

}
