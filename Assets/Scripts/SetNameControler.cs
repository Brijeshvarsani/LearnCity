using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNameControler : MonoBehaviour
{

    public TextMeshProUGUI user_name;

    public TMP_InputField user_inputField;
    public TMP_InputField user_inputField1;
    public TMP_InputField user_inputField2;



    public void setName()

    {  if ( user_inputField.text == "3")
        {
            if (user_inputField1.text == "5")
            {
                if (user_inputField2.text == "11")
                {
                    user_name.text = "CORRECT !";
                }
            }
           
        }
    else
        {
            user_name.text = "Wrong Answer";
        }

        
    }
}
