using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeywordID : MonoBehaviour
{

    public TMP_InputField inputField; // Reference to the TextMeshProUGUI input field
    public TextMeshProUGUI outputText; // Reference to the TextMeshProUGUI component that will display the output

    public GameObject stressButton;
    public GameObject depressionButton;
    public GameObject phobiaButton;
    public GameObject hotlineButton;
    public GameObject gamesButton;



    public GameObject resetButton;
    public bool restCheck;

    public int conversationStage;


    private void Start()
    {
        stressButton.SetActive(false);
        depressionButton.SetActive(false);
        phobiaButton.SetActive(false);
        gamesButton.SetActive(false);

        conversationStage = 1;

        restCheck = false;
    }

    private void Update()
    {
        if (restCheck == true)
        {
            ResetConversation();
        }
    }

    private void ResetConversation()
    {
        stressButton.SetActive(false);
        depressionButton.SetActive(false);
        phobiaButton.SetActive(false);
        gamesButton.SetActive(false); 

        conversationStage = 1;

        restCheck = false;
    }


    // Define the keywords and responses as a dictionary
    private Dictionary<string, string> GeneralkeywordResponses = new Dictionary<string, string>()
    {
        //Introductions
        {"hello", "Hi there, how are you today?"},
        {"hi", "Hi there, how are you today?"},
        {"talk", "Okay, what would you like to talk about?"},
        {"question", "Okay, what would you like to ask me?"},

        //Negtive user
        {"bad", "I'm sorry to hear about that, would you like to talk more about what is going on?"},
        {"not good", "I'm sorry to hear about that, would you like to talk more about what is going on?"},
        {"not well", "I'm sorry to hear about that, would you like to talk more about what is going on?"},
        {"sad", "I'm sorry to hear about that, would you like to talk more about what is going on?"},

        //Neutral user
        {"not sure", "Would you like to try and talk about what is going on, or describe the situation to me?"},
        {"i don't know", "Would you like to try and talk about what is going on, or describe the situation to me?"},
        
        //Postive user
        {"good", "I'm happy to hear about that, remember to keep an eye on your mental health"},
        {"okay", "I'm happy to hear about that, remember to keep an eye on your mental health"},
        {"postive", "I'm happy to hear about that, remember to keep an eye on your mental health"},

        //Closed responce user
        {"yes", "That's okay, what do you want to do?"},
        {"no", "That's okay, what do you want to do?"},

        //Ending
        {"see you later", "See you later!"},
        {"goodbye", "See you later!"},
        {"thanks", "You're welcome!"},
        {"thank you", "You're welcome!"}
    };

    private Dictionary<string, string> StresskeywordResponses = new Dictionary<string, string>()
    {
        {"stress", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"anger", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"pressure", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"anxiety", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"worry", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"worrying", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"nervous", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"suffering", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"suffer", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"hate", "I'm sorry you are feeling this way, perhaps this resource might help you"}
    };

    private Dictionary<string, string> DepressionkeywordResponses = new Dictionary<string, string>()
    {
        {"depression", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"depressed", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"gloomy", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"miserable", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"weak", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"unhappy", "I'm sorry you are feeling this way, perhaps this resource might help you"}
    };

    private Dictionary<string, string> PhobiaskeywordResponses = new Dictionary<string, string>()
    {
        {"phobia", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"fear", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"dread", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"horror", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"terror", "I'm sorry you are feeling this way, perhaps this resource might help you"},
        {"scard", "I'm sorry you are feeling this way, perhaps this resource might help you"}
    };

    private Dictionary<string, string> RandomkeywordResponses = new Dictionary<string, string>()
    {
        {"do you like cheese?", "I like cream cheese, a lot"},
        {"who are you", "I am a local chat bot on your phone, ready to guide and talk to you on this app, as best as I can"},
        {"what are you", "I am a local chat bot on your phone, ready to guide and talk to you on this app, as best as I can"},
        {"game", "I have games that might help you to relax and have some fun if you're interested"},
        {"this resource wasn't helpful", "I'm sorry to hear that, perhaps you could give some feedback to the developer so that they can improve me"},
        {"i am hurting myself", "I would recommend you telling someone you turst or love and consider contacting a support hotline"},
        {"sucicidal", "I cannot provide personal support on this subject. Please tell someone you trust or love and contact a support hotline as soon as possilbe"},
        {"kill myself", "I cannot provide personal support on this subject. Please tell someone you trust or love and contact a support hotline as soon as possilbe"}
    };

    // Called when the user presses the Enter key in the text box
    public void OnSubmit()
    {
        // Get the entered text from the input field
        string enteredText = inputField.text.ToLower();

        // Search for the keywords in the entered text
        foreach (string keyword in GeneralkeywordResponses.Keys)
        {
            if (enteredText.Contains(keyword))
            {
                // Output the corresponding response
                string response = GeneralkeywordResponses[keyword];
                Debug.Log(response);
                outputText.SetText(response);
                return;
            }
        }

        foreach (string keyword in StresskeywordResponses.Keys)
        {
            if (enteredText.Contains(keyword))
            {
                // Output the corresponding response
                string response = StresskeywordResponses[keyword];
                Debug.Log(response);
                outputText.SetText(response);
                stressButton.SetActive(true);
                depressionButton.SetActive(false);
                phobiaButton.SetActive(false);
                return;
            }
        }

        foreach (string keyword in DepressionkeywordResponses.Keys)
        {
            if (enteredText.Contains(keyword))
            {
                // Output the corresponding response
                string response = DepressionkeywordResponses[keyword];
                Debug.Log(response);
                while (enteredText.Contains(keyword))
                {
                    outputText.SetText(response);
                    stressButton.SetActive(false);
                    depressionButton.SetActive(true);
                    phobiaButton.SetActive(false);
                }
                return;
            }
        }

        foreach (string keyword in PhobiaskeywordResponses.Keys)
        {
            if (enteredText.Contains(keyword))
            {
                // Output the corresponding response
                string response = PhobiaskeywordResponses[keyword];
                Debug.Log(response);
                outputText.SetText(response);
                stressButton.SetActive(false);
                depressionButton.SetActive(false);
                phobiaButton.SetActive(true);
                return;
            }
        }

        foreach (string keyword in RandomkeywordResponses.Keys)
        {
            if (enteredText.Contains(keyword))
            {
                // Output the corresponding response
                string response = RandomkeywordResponses[keyword];
                Debug.Log(response);
                outputText.SetText(response);
                return;
            }
        }

        // If no keyword is found, output a default response
        Debug.Log("I apologise, but my ability to commutate is limited, perhaps you might find help in different parts of the app?");
        outputText.text = "I apologise, but my ability to commutate is limited, perhaps you might find help in different parts of the app?";
    }



}
