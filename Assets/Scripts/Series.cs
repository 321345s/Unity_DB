using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Series : MonoBehaviour
{
    // Start is called before the first frame update

    public float[] TimeSubSolution;//第一个数据没用但是得插
    public int[] ButtonSeriesSolution;
    public string nextScene;

    


    public PlayMusic[] ArrPlayMusic;

    public float[] playerTimeSub;
    public int[] playerButtonSeries;

    private int currIndex;
    public int maxButtonPress;
    private float LastPressTime;
    private float playerPoints;

    /*public Text QualifiedText;
    public Text ScoreText;*/


    public  GameObject HiddenButtonNextScene;
    public  GameObject HiddenButtonReset;

    public GameObject Note;
    public GameObject NoteSolution;
    public GameObject SolutionMusic;



    /*public GameObject MusicPlayer0;
    public GameObject MusicPlayer1;
    public GameObject MusicPlayer2;
    public GameObject MusicPlayer3;
    public GameObject MusicPlayer4;
    public GameObject MusicPlayer5;
    public GameObject MusicPlayer6;*/

    public GameObject[] MusicPlayer;
    public GameObject[] PlayMusic;
    public GameObject[] KeyNote;



    private bool isSolutionPlaying;

    public int MaxButtonCount;

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
                /*QualifiedText.text = "Qualified";
                ScoreText.text = "Your Score:" + playerPoints.ToString();*/
                /*Thread.Sleep(1000);*/
                /*SceneManager.LoadScene(nextScene);*/
                /*GameObject gameObject = GameObject.find("MusicPlayer");
                gameObject.playMusic();*/


                /*HiddenButton HB = HiddenButtonNextScene.GetComponent<HiddenButton>();
                HB.SetDisplay();*/

                HiddenButton HBR = HiddenButtonReset.GetComponent<HiddenButton>();
                HBR.SetHidden();

                isSolutionPlaying = true;

                HiddenNote Solution = NoteSolution.GetComponent<HiddenNote>();
                Solution.SetDisplay();

                HiddenNote NT = Note.GetComponent<HiddenNote>();
                CanvasGroup cg = Note.GetComponent<CanvasGroup>();
                if (cg.alpha == 1)
                {
                    NT.SetHidden();
                }
                PlayMusic PM = SolutionMusic.GetComponent<PlayMusic>();
                PM.playMusic();

                for(int i = 0; i < KeyNote.Length; i++)
                {
                    KeyNote[i].GetComponent<HiddenNote>().SetHidden();
                }
                //我为什么不写个数组呢？
                /*Button button0 = MusicPlayer0.GetComponent<Button>();
                button0.interactable = false;
                Button button1 = MusicPlayer1.GetComponent<Button>();
                button1.interactable = false;
                Button button2 = MusicPlayer2.GetComponent<Button>();
                button2.interactable = false;
                Button button3 = MusicPlayer3.GetComponent<Button>();
                button3.interactable = false;
                Button button4 = MusicPlayer4.GetComponent<Button>();
                button4.interactable = false;
                Button button5 = MusicPlayer5.GetComponent<Button>();
                button5.interactable = false;
                Button button6 = MusicPlayer6.GetComponent<Button>();
                button6.interactable = false;*/
                for(int i = 0; i < MusicPlayer.Length; i++)
                {
                    MusicPlayer[i].GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                /*QualifiedText.text = "Failed";
                ScoreText.text = "Your Score:" + playerPoints.ToString();*/
                HiddenNote NT = Note.GetComponent<HiddenNote>();
                NT.SetDisplay();
            }
            currIndex = 0;
            LastPressTime = 0;
            playerPoints = 0;
            
        }

        
    }

    public void Reset()
    {
        currIndex = 0;
        /*QualifiedText.text = "Reset Completed";
        ScoreText.text = "";*/
        playerPoints = 0;
    }

    private bool CheckSolution()
    {
        /*Debug.Log("In CheckSolution:");*/
        const float MAXSCORE = 100;
        const float QUALIFYSCORE = 50;//默认为80为了方便测试改成了50
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

  
    void Update()
    {
        if (isSolutionPlaying)
        {
            PlayMusic PM = SolutionMusic.GetComponent<PlayMusic>();
            if (!PM.music.isPlaying)
            {
                HiddenButton HB = HiddenButtonNextScene.GetComponent<HiddenButton>();
                HB.SetDisplay();
                isSolutionPlaying = false;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.A)&&0<MaxButtonCount)
        {
            PressButton(0);
            PlayMusic[0].GetComponent<PlayMusic>().playMusic();
        }
        if (Input.GetKeyUp(KeyCode.S) && 1 < MaxButtonCount)
        {
            PressButton(1);
            PlayMusic[1].GetComponent<PlayMusic>().playMusic();
        }
        if (Input.GetKeyUp(KeyCode.D) && 2 < MaxButtonCount)
        {
            PressButton(2);
            PlayMusic[2].GetComponent<PlayMusic>().playMusic();
        }
        if (Input.GetKeyUp(KeyCode.J) && 3 < MaxButtonCount)
        {
            PressButton(3);
            PlayMusic[3].GetComponent<PlayMusic>().playMusic();
        }
        if (Input.GetKeyUp(KeyCode.K) && 4 < MaxButtonCount)
        {
            PressButton(4);
            PlayMusic[4].GetComponent<PlayMusic>().playMusic();
        }
        if (Input.GetKeyUp(KeyCode.L) && 5 < MaxButtonCount)
        {
            PressButton(5);
            PlayMusic[5].GetComponent<PlayMusic>().playMusic();
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


//by 321345