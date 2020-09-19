using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    [SerializeField] MultipleTargetCamera cam;
    [SerializeField] Animator UIAnim;

    int currSceneIndex;//current Scene Index

    public static GameController instance;

    public bool isDead;

    private void Awake()
    {
        instance = this;
        isDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        levelText.gameObject.SetActive(false);
        currSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LevelWin()
    {
        
            cam.lookAtPlayer = true;
            levelText.gameObject.SetActive(true);

            levelText.text = "Level Won";
            UIAnim.SetTrigger("LevelEnd");


            StartCoroutine(LoadAfterTime(currSceneIndex + 1, 2.8f));

            //TODO change to next level later
            if (currSceneIndex == 3)
            {
                StartCoroutine(LoadAfterTime(1, 2.8f));
            }
        
        
        
    }

    public void RestartLevel()
    {
        if (!isDead)
        {
            cam.lookAtPlayer = true;

            isDead = true;
            levelText.gameObject.SetActive(true);

            levelText.text = "You Died";

            UIAnim.SetTrigger("LevelEnd");
            StartCoroutine(LoadAfterTime(currSceneIndex, 2.8f));
        }
    }

    public IEnumerator LoadAfterTime(int sceneIndex,float delay)
    {
       
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneIndex);
        
    }
    
}
