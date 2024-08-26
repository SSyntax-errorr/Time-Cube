using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonStay : MonoBehaviour
{

    enum playerbtn
    {
        player1, player2, player3
    }
    public Button player1btn, player2btn, player3btn;

    

    private bool p1selected, p2selected, p3selected;

    public Animator p1btnAnim, p2btnAnim, p3btnAnim;

    private void Start()
    {
        if (player1btn == null)
        {
            player1btn = GetComponent<Button>();
        }

        if (player1btn != null)
        {
            player1btn.onClick.AddListener(player1Click);
            player2btn.onClick.AddListener(player2Click);
            player3btn.onClick.AddListener(player3Click);
            p1btnAnim.Play("p1btn");
            p1selected = true;
        }
    }

    void Update()
    {
        if(p1selected){
            player1btn.Select();
            p2btnAnim.Play("New State");
            p3btnAnim.Play("New State");
        } else if (p2selected)
        {
            player2btn.Select();
            
            p1btnAnim.Play("New State");
            p3btnAnim.Play("New State");
        } else if(p3selected){
            player3btn.Select();
            
            p1btnAnim.Play("New State");
            p2btnAnim.Play("New State");
        }

    }



    public void player1Click()
    {
        p1selected = true;
        p2selected = false;
        p3selected = false;
        p1btnAnim.Play("p1btn");
    }

    public void player2Click(){
        p1selected = false;
        p2selected = true;
        p3selected = false;
        p2btnAnim.Play("p2click");
    }

    public void player3Click(){
        p1selected = false;
        p2selected = false;
        p3selected = true;
        p3btnAnim.Play("p3click");
    }



}
