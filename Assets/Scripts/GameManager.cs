using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject question;
    public Sprite normal_sprite;
    public Sprite wrong_sprite;
    public Sprite correct_sprite;

    public GameObject answer1;
    public GameObject answer2;
    public GameObject player;
    public CanvasGroup gameOver;

    private bool animatorClickTrigger;
    private int correct_indic;
    private int question_indic=0;
    private Animator m_animator = null;
    private AnimatorClipInfo[] clipInfo;
    private string[] questions={"Try to ___ a healthy weight - this will help you to avoid health problems.",
	"Engage in ___ training - exercises like running and cycling raise your heart rate and improve circulation.",
	"Follow a(n) ___ diet with lots of fruit and vegetables.",
	"Be sure to ___ foods from all of the main food groups regularly.",
	"You should eat at least five ___ of fruit and vegetables a day.",
	"A healthy mind makes a healthy body. Look after your ___ health.",
	"Try to get approximately eight hours of ___ a night",
	"You should ___ the use of devices before you go to bed."};
    
    private string[] correct_answers={"maintain",
    "cardio",
    "balanced",
    "consume",
    "servings",
    "mental",
    "sleep",
    "limit"};

    private string[] wrong_answers={"remove",
    "strength",
    "active",
    "eliminate",
    "drinks",
    "stressful",
    "bedtime",
    "apply"};

    // Start is called before the first frame update
    void Start()
    {
        m_animator = player.GetComponent<Animator>();
        setUpNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        clipInfo = m_animator.GetCurrentAnimatorClipInfo(0); 
        if(getAnimatorClickTrigger()){
             if(clipInfo[0].clip.name.Equals("player_normal")){
                setUpNewQuestion();
                //Debug.Log(getAnimatorClickTrigger());
            }
        }
        if(answer1.GetComponent<Answer_click>().getButtonClick()){
            if(correct_indic==0){
                answer1.GetComponentInChildren<Image>().sprite=answer1.GetComponent<Answer_click>().correct_sprite;
                question.GetComponentInChildren<Image>().sprite = correct_sprite;
                m_animator.Play("player_wright");
            }else{
                answer1.GetComponentInChildren<Image>().sprite=answer1.GetComponent<Answer_click>().wrong_sprite;
                question.GetComponentInChildren<Image>().sprite = wrong_sprite;
                m_animator.Play("player_wrong");
            }
            answer1.GetComponent<Answer_click>().setButtonLock(true);
            answer2.GetComponent<Answer_click>().setButtonLock(true);
            setAnimatorClickTrigger(true);
        }
        if(answer2.GetComponent<Answer_click>().getButtonClick()){
            if(correct_indic==1){
                answer2.GetComponentInChildren<Image>().sprite=answer2.GetComponent<Answer_click>().correct_sprite;
                question.GetComponentInChildren<Image>().sprite = correct_sprite;
                m_animator.Play("player_wright");
            }else{
                answer2.GetComponentInChildren<Image>().sprite=answer2.GetComponent<Answer_click>().wrong_sprite;
                question.GetComponentInChildren<Image>().sprite = wrong_sprite;
                m_animator.Play("player_wrong");
            }
            answer1.GetComponent<Answer_click>().setButtonLock(true);
            answer2.GetComponent<Answer_click>().setButtonLock(true);
            setAnimatorClickTrigger(true);
        }
    }

    public void setUpNewQuestion(){
        setAnimatorClickTrigger(false);
        answer1.GetComponent<Answer_click>().init();
        answer2.GetComponent<Answer_click>().init();
        Debug.Log(getAnimatorClickTrigger());
        if(question_indic>=questions.Length){
            gameOver.alpha = 1f;
            gameOver.interactable = true;
            m_animator.Play("player_normal");
        }else{
            gameOver.alpha = 0f;
            gameOver.interactable = false;
            answer1.GetComponent<Answer_click>().setButtonLock(false);
            answer2.GetComponent<Answer_click>().setButtonLock(false);
            question.GetComponentInChildren<Image>().sprite = normal_sprite;
            question.GetComponentInChildren<TextMeshProUGUI>().text=questions[question_indic];
            correct_indic=Random.Range(0, 2);
            if(correct_indic==0){
                answer1.GetComponentInChildren<TextMeshProUGUI>().text=correct_answers[question_indic];
                answer2.GetComponentInChildren<TextMeshProUGUI>().text=wrong_answers[question_indic];
                question_indic++;
            }
            else if(correct_indic==1){
                answer2.GetComponentInChildren<TextMeshProUGUI>().text=correct_answers[question_indic];
                answer1.GetComponentInChildren<TextMeshProUGUI>().text=wrong_answers[question_indic];
                question_indic++;
            }
        }
    }

    public void restart(){
        question_indic=0;
        setUpNewQuestion();
    }
    public bool getAnimatorClickTrigger(){
        return animatorClickTrigger;
    }
    public void setAnimatorClickTrigger(bool mode){
        animatorClickTrigger = mode;
    }

  

}
