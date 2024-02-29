
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Answer_click : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite normal_sprite;
    public Sprite hover_sprite;
    public Sprite wrong_sprite;
    public Sprite correct_sprite;
    private bool button_click;
    private bool button_lock;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!button_lock){
            setButtonClick(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         if(!button_lock){
            gameObject.GetComponentInChildren<Image>().sprite=hover_sprite;
         }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         if(!button_lock){
            gameObject.GetComponentInChildren<Image>().sprite=normal_sprite;
         }
    }

    public void init(){
        setButtonClick(false);
        gameObject.GetComponentInChildren<Image>().sprite=normal_sprite;
    }

    public void setButtonClick(bool mode){
        button_click=mode;
    }

    public bool getButtonClick(){
        return button_click;
    }
    public void setButtonLock(bool mode){
        button_lock=mode;
    }

    public bool getButtonLock(){
        return button_lock;
    }
}
