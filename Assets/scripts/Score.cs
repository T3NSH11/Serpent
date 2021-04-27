using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score;
    public float Hscore;
    public GameObject Scoreobj;
    public GameObject HSobj;
    public GameObject playerobj;
    const string scorekey = "Hscore";
    void Start()
    {
        Loadprefs();
    }

    void Update()
    {
        if(playerobj)
        {
            score += Time.deltaTime * 15;
        }

        int scoreval = (int) score;
        int Hscoreval = (int) Hscore;
        Scoreobj.GetComponent<TMPro.TextMeshProUGUI>().text = scoreval.ToString();
        HSobj.GetComponent<TMPro.TextMeshProUGUI>().text = Hscoreval.ToString();

        if (score > Hscore)
        {
            Hscore = score;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Saveprefs();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnApplicationQuit()
    {
        Saveprefs();
    }

    public void Loadprefs()
    {
        var savedscore = PlayerPrefs.GetFloat(scorekey, Hscore);
        Hscore = savedscore;

    }

    public void Saveprefs()
    {
        PlayerPrefs.SetFloat(scorekey, Hscore);
        PlayerPrefs.Save();
    }
} 
