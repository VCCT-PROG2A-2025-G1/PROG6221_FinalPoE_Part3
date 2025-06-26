using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROG6221_Part3_ST10440987
{
    public class Chatbot
    {
        // ----------------------------------------------------------------------------- //
        // Declaring a dictionary to store the chatbots responses
        Dictionary<Regex, string> responses;

        // Declaring a dictionary to store the chatbots random responses
        Dictionary<Regex, List<string>> randomResponses;

        // Declaring a dictionary to store the chatbots emotion detection responses
        Dictionary<Regex, List<string>> emotionDetection;

        // Declaring a list to store the user's interests and a list of available topics
        List<string> userInterests = new List<string>();
        List<string> availableTopics = new List<string>
        {
            "Phishing Emails",
            "Safe Password Practices",
            "Recognising Suspicious Links/Safe Browsing",
            "Protection of Personal Information",
            "How to Maximise Your Safety Online",
            "Scams",
            "Social Engineering",
            "Privacy",
            "Malware",
            "Ransomware",
            "Firewalls",
            "Anti-Virus Software",
            "Two-Factor Authentication"
        };
        public string name;
        public string lastTopic = null;

        public bool exitConfirmation = false;

        // ----------------------------------------------------------------------------- //
        // Default Constructor for the ChatBot class
        public Chatbot()
        {
            this.ChatbotDictionaries();
        }

        // ----------------------------------------------------------------------------- //
        /* Method to display the chatbot face using ASCII
           Art and plays a welcome message from a .wav file */
        public string ChatBotFace()
        {
            // The @ symbol treats the string as a verbatim string literal, allowing for multi-line strings
            string asciiArt = @"
                    $$$$$$$$$$$$$$$$$$$xxxxxxxxxxxxx$$$$$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$$$xx::xxxxxxxxx::xx$$$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$xxxxx::xxxxxxx::xxxxx$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$xxxx:::xxxxxxxxxxx:::xxxx$$$$$$$$$$$$    
                    $$$$$$$$$$$$$xxx::::::::xxx::::::::xxx$$$$$$$$$$$$    
                    $$$$$$$$$$$$xxx:::::::::::::::::::::xxx$$$$$$$$$$$    
                    $$$$$$$$$$$xxx:::::::::::::::::::::::xxx$$$$$$$$$$    
                    $$$$$$$$$$xxxx:::+$$$$$+:::+$$$$$+:::xxxx$$$$$$$$$    
                    $$$$$$$$$$xxx:::::+XXX+:::::+XXX+:::::xxx$$$$$$$$$    
                    $$$$$$$$$$xxx:::::+XXX+:::::+XXX+:::::xxx$$$$$$$$$    
                    $$$$$$$$$$$xx::::::::::::^::::::::::::xx$$$$$$$$$$    
                    $$$$$$$$$$$$xx::::::::::/_\::::::::::xx$$$$$$$$$$$    
                    $$$$$$$$$$$$$x:::::::::::::::::::::::x$$$$$$$$$$$$    
                    $$$$$$$$$$$$$xx::::+-----------+::::xx$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$xx:::\_________/:::xx$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$$xx:::::::::::::::xx$$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$$$xxx:::::::::::xxx$$$$$$$$$$$$$$$$    
                    $$$$$$$$$$$$$$$$$xxxxxxxxxxxxxxxxx$$$$$$$$$$$$$$$$
            ";
            string appTitle = "Your personal Cyber Security Awareness Bot!";
            string divider = "-------------------------------------------------" +
                "-----------------------------------------------------------------";

            // Plays a welcome message from a .wav file
            SoundPlayer player = new SoundPlayer("C:\\Users\\patri\\OneDrive\\Desktop\\Varsity College 2024\\Second Year\\Programming 2A\\Cyber Security Chatbot Recording.wav");
            player.Play();

            return asciiArt + "\n" + appTitle + "\n" + divider;
        }

        // ----------------------------------------------------------------------------- //
        // Method to ask the user for their name and greet them
        public string Greeting()
        {
            // Displays a personal greeting message using the user's name
            string greeting = @$"
               ______________________
              /                      \
             /   Welcome {this.name.PadRight(10)}   \
            <    to your CyberSecurity |
             \   Awareness Bot        /
              \______________________/";
            string divider = "-------------------------------------------------" +
                "-----------------------------------------------------------------";

            return greeting + "\n" + divider;
        }

        // ----------------------------------------------------------------------------- //
        // Method to initialize the chatbot's responses
        private void ChatbotDictionaries()
        {
            // Initializing the dictionaries with regex patterns and corresponding responses
            this.responses = new Dictionary<Regex, string>
            {
                {new Regex(@"\b(hello|hi|hey)\b", RegexOptions.IgnoreCase), "Hello " + this.name + "! How can I assist you today?" },
                {new Regex(@"\b(how are|how're) (you?|you)\b", RegexOptions.IgnoreCase), "I am doing extremely well thanks " + this.name + ", and you?" },
                {new Regex(@"\b(exist|purpose|what can you do)\b", RegexOptions.IgnoreCase),
                    "I exist because my purpose is to simulate real-life scenarios where users might encounter cyber threats and provide " +
                    "guidance on avoiding common traps. \nIn essence, if you are struggling with anything related to cybersecurity, meaning you are " +
                    "experiencing cyber threats or being hacked or need some advice, i am here to provide guidance on what you can do in the " +
                    "future or provide guidance on what your next steps should be." },
                {new Regex(@"\b(what can i ask you|what do people usually talk (about?|about)|(speciality|specialities)|cover|know|topics|help)\b",
                    RegexOptions.IgnoreCase), "The topics below are my specialities. These are the main cybersecurity topics that i get asked about frequently:" +
                    "\nPhishing Emails\nSafe Password Practices\nRecognising Suspicious Links/Safe Browsing" +
                    "\nProtection of personal information\nHow to maximise your safety online" },
                {new Regex(@"\b(phishing emails|phishing)\b", RegexOptions.IgnoreCase),
                    "Phishing emails are fraudulent emails that appear to be from legitimate sources containing a download link or link to a suspicious website. " +
                    "Or in easier terms, its emails that are sent to people to trick them into revealing personal information such as bank card numbers or ID " +
                    "or Passport Numbers etc.\nPhishing emails, if clicked, can lead to financial loss, identity theft or the compromise of sensitive data." },
                {new Regex(@"\b(password|passwords)\b", RegexOptions.IgnoreCase), "Safe Password Practices involve creating strong and unique passwords " +
                    "that are difficult to crack or guess.\nTo create a strong password, the password should consist of several characters in length, should " +
                    "have a mix of special characters, numbers, lowercase and uppercase characters. Avoid using any personal details in your passwords.\nExample: @htj48engWVS%" },
                {new Regex(@"\b(suspicious links|safe browsing)\b", RegexOptions.IgnoreCase), "To recognise suspicious links, look for an unusual amount " +
                    "of numbers in the URL or look for an unusual amount of hyphens. Also look at the end of the URL, often this is the most important part " +
                    "to determine if its suspicious or not.\nSuspicious links are URLs that may lead to malicious websites or downloads.\nSafe browsing allows " +
                    "users to protect themselves from unsafe websites and applications while online." },
                {new Regex(@"\b(identify|spot|(fake?|fake)|look for|suspicious emails)\b", RegexOptions.IgnoreCase), "To identify phishing emails, look for signs such as " +
                    "poor grammar, generic greetings, and suspicious links. Also look at the email senders domain name, this often is slightly altered or " +
                    "different to the actual email domain. Check if the email is urging you for immediate action such as pay now or there will be legal consequences." },
                {new Regex(@"\b(personal information|protect|secure|safe|stolen|maximise my safelty online|protection)\b", RegexOptions.IgnoreCase), "To protect your personal information, use strong passwords, enable two-factor " +
                    "authentication, and be cautious about sharing sensitive data online. Also update your passwords on a regular basis. You could " +
                    "also start using an anti-virus software. Make sure you're using a firewall to limit the data traffic going in and out of your network." },
                {new Regex(@"\b((two-factor authentication|2FA|two factor authentication)|work)\b", RegexOptions.IgnoreCase), "Two-factor authentication (2FA) is an extra layer of security that " +
                    "requires not only a password and username but also something that is unique to the user, such as a fingerprint or facial scan." },
                {new Regex(@"\b(malware)\b", RegexOptions.IgnoreCase), "Malware is malicious software designed to harm, exploit, or otherwise compromise a computer system.\nThere are different types of " +
                    "malware, these include:\nViruses, Worms, Trojan Horses, Spyware, Ransomware and adware" },
                {new Regex(@"\b(ransomware)\b", RegexOptions.IgnoreCase),
                    "Ransomware is a type of malware that encrypts a user's files and demands payment for the decryption key.\nThis malware can affect " +
                    "businesses and personal reputations, it can have financial loss and loss of sensitive data." },
                {new Regex(@"\b(firewall|firewalls|function of a firewall|how does a firewall (work?|work))\b", RegexOptions.IgnoreCase), "A firewall is a network security " +
                    "device or a gatekeeper that monitors and controls incoming and outgoing network traffic. This device is supposed to prevent certain data " +
                    "from going into the network that could cause a cyber attack or other malicious software." },
                {new Regex(@"\b((anti-virus|antivirus)|software|how (can|do) i protect myself against (malware?|malware))\b", RegexOptions.IgnoreCase),
                    "Antivirus software is a software designed to detect and destroy computer viruses. The software scans files on your computer as well as " +
                    "the computers memory and looks for patterns that may indicate the presence of a malware." },
                {new Regex(@"\b(social engineering|dangerous|use|hackers|hack)\b", RegexOptions.IgnoreCase),
                    "Social engineering is the psychological manipulation technique of people into performing actions or divulging confidential and sensitive " +
                    "information. This technique takes quite a bit of time as the actor/hacker has to gain the trust of the victim before gaining access to " +
                    "their personal information." },
                {new Regex(@"\b(thanks|thank you)\b", RegexOptions.IgnoreCase), "You're welcome " + this.name + "! If you have any more questions, feel free to ask!" },
                {new Regex(@"\b(who are (you?|you)|who am i talking (to?|to)|identify yourself|(whats|what's|what is) your (name?|name)|are you a real 
                    (person?|person))\b", RegexOptions.IgnoreCase), "I am your friendly, helpful chatbot to help you further understand Cyber Security!" },
                {new Regex(@"\b(bye|goodbye|cheers|chow|talk later|see you)\b", RegexOptions.IgnoreCase), "Goodbye " + this.name + "! Stay safe online!" },
                {new Regex(@"\b(scam)\b", RegexOptions.IgnoreCase), "Look for red flags such as spelling errors in URLs or an email senders domain. Emails " +
                "urging you to pay now through a link.\nUse strong passwords as well as two-factor authentication." },
                {new Regex(@"\b(privacy)\b", RegexOptions.IgnoreCase), "Limit your sharing of personal details. Use strong and unique passwords and two-factor " +
                "authentication. Practice safe browsing and use a private network rather than a public network. Use a firewall on your network and use anti-virus " +
                "software to prevent possible malwares on your devices." }
            };

            // Initializing the random responses dictionary with regex patterns and corresponding lists of tips
            this.randomResponses = new Dictionary<Regex, List<string>>
            {
                {new Regex(@"(?=.*\bphishing\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Be cautious of unsolicited emails or messages asking for personal information.",
                        "Hover over links to see the actual URL before clicking.",
                        "Look for spelling and grammatical errors in emails.",
                        "Verify the sender's email address and domain.",
                        "Avoid clicking on links or downloading attachments from unknown sources.",
                        "1 in 3 employees are likely to click on a phishing link within an email",
                        "Being tired is a large factor in clicking on phishing links, so make sure you are well rested.",
                        "Phishing is the most common cyber attack. It is the most common because it is the easiest to do and the easiest to fall for."
                    }
                },
                {new Regex(@"(?=.*\b(password|passwords)\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Use a mix of uppercase and lowercase letters, numbers, and special characters.",
                        "Avoid using easily guessable information like birthdays or names.",
                        "Use a password manager to generate and store complex passwords.",
                        "Change your passwords regularly and avoid reusing them across different accounts.",
                        "Enable two-factor authentication for an extra layer of security.",
                        "Dont use the same password for multiple accounts. This will allow threat actors to get into more of your life.",
                        "Use a passphrase instead of a password. A passphrase is a longer password that is easier to remember but harder to guess.",
                        "Avoid using patterns in your passwords, such as '123456' or 'qwerty'. These are the first passwords that threat actors will try."
                    }
                },
                {new Regex(@"(?=.*\bprotecting my information|personal information\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Be cautious about sharing personal information on social media.",
                        "Use privacy settings to control who can see your information.",
                        "Regularly review and update your privacy settings on all accounts.",
                        "Be mindful of the information you share in public spaces.",
                        "Consider using a VPN for added security when browsing.",
                        "Encrypt your personal data to protect it from unauthorized access.",
                        "Regularly back up your important data as this will help you recover it in case of a cyber attack.",
                        "Disable bluetooth when not in use, as this can be a way for threat actors to gain access to your devices."
                    }
                },
                {new Regex(@"(?=.*\bsafe browsing|suspicious links|suspicious link\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Use a reputable antivirus software to scan for threats.",
                        "Keep your operating system and software up to date.",
                        "Avoid clicking on pop-up ads or suspicious links.",
                        "Use secure websites (look for 'https://' in the URL).",
                        "Be cautious when entering personal information online.",
                        "Only download software from trusted sources and websites.",
                        "Delete your browser cookies and cache regularly to prevent tracking.",
                        "Disable your browser from asking you to save passwords, as this can be a security risk if your device is compromised."
                    }
                },
                {new Regex(@"(?=.*\bsafety online\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Be cautious about sharing personal information online.",
                        "Use strong and unique passwords for each account.",
                        "Enable two-factor authentication whenever possible.",
                        "Be wary of unsolicited messages or friend requests.",
                        "Regularly review your privacy settings on social media.",
                        "Close any accounts that you don't use any longer, as these can be a security risk if they are not monitored.",
                        "Be careful of what you post and where you post it, as this can be used against you by threat actors.",
                        "Use a good, reputable antivirus software to protect your devices from malware and other threats."
                    }
                },
                {new Regex(@"(?=.*\bscam|scams\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Be cautious of deals that seem too good to be true.",
                        "Verify the legitimacy of websites before making purchases.",
                        "Look for reviews and ratings of products or services.",
                        "Avoid sharing personal information with unknown sources.",
                        "Report any suspicious activity to the relevant authorities.",
                        "Be cautious of unsolicited phone calls or emails asking for personal information.",
                        "Never send money or provide personal information to someone you don't know.",
                        "Educate yourself about common scams and how to recognize them."
                    }
                },
                {new Regex(@"(?=.*\bsocial engineering\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Verify the identity of the person or organization before sharing any information.",
                        "Educate yourself about common social engineering tactics.",
                        "Use strong passwords and two-factor authentication to protect your accounts.",
                        "Report any suspicious activity to your IT department or relevant authorities.",
                        "Social media can be a tool for social engineering, so be cautious about what you share online and who you share it with.",
                        "Be aware of phishing attacks that use social engineering tactics to make you reveal sensitive information",
                        "Always question unexpected requests for sensitive information, even if they appear to come from a trusted source.",
                        "Don't just trust someone because they claim to be from a reputable organization. Always verify their identity through official channels."
                    }
                },
                {new Regex(@"(?=.*\bprivacy\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Limit the amount of personal information you share online.",
                        "Use privacy settings on social media platforms to control who can see your information.",
                        "Be cautious about sharing sensitive information in public forums or chats.",
                        "Regularly review and update your privacy settings on all accounts.",
                        "Consider using a VPN to protect your online activities from prying eyes.",
                        "Always read the privacy policies of websites and applications before using them as they might include fine print that they can use against you later.",
                        "Always ask why, how and who when someone asks you for your personal information.",
                        "Consider using a good antivirus software that includes privacy protection features to help safeguard your personal information."
                    }
                },
                {new Regex(@"(?=.*\bmalware\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Keep your operating system and software up to date.",
                        "Use reputable antivirus software to scan for threats.",
                        "Avoid clicking on suspicious links or downloading unknown files.",
                        "Be cautious when using public Wi-Fi networks.",
                        "Regularly back up your important files to prevent data loss.",
                        "Some malwares can remain dormant on your device for a long time, so it is important to regularly scan your devices for malware.",
                        "Be cautious of email attachments, especially from unknown senders, as these can often contain malware.",
                        "There are several different types of malware which include viruses, worms, trojan horses, spyware, ransomware and adware. Each type " +
                        "has its own characteristics and methods of attack."
                    }
                },
                {new Regex(@"(?=.*\bransomware\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Regularly back up your important files to an external drive or cloud storage.",
                        "Keep your operating system and software up to date.",
                        "Avoid clicking on suspicious links or downloading unknown files.",
                        "Use reputable antivirus software to scan for threats.",
                        "Be cautious when using public Wi-Fi networks.",
                        "Ransomware can encrypt your files and demand payment for decryption, so it is important to have a backup of your important files.",
                        "Disable the web so that ransomware can stop executing and allow you to remove the malicious software from your device without decrypting the data.",
                        "Monitor your network for unusual activity, as ransomware often spreads through network connections."
                    }
                },
                {new Regex(@"(?=.*\bfirewall|firewalls\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Ensure your firewall is enabled and properly configured.",
                        "Regularly update your firewall software to protect against new threats.",
                        "Monitor incoming and outgoing network traffic for suspicious activity.",
                        "Use a hardware firewall for added security.",
                        "Educate yourself about common firewall settings and configurations.",
                        "A firewall can help protect your network from unauthorized access and cyber attacks.",
                        "The term firewall was originally used to describe a physical barrier that prevented the spread of fire, and " +
                        "it has since been adapted to describe a digital barrier that prevents the spread of cyber threats.",
                        "Firewalls can be hardware-based or software-based, and they work by filtering network traffic based on predefined rules."
                    }
                },
                {new Regex(@"(?=.*\banti-virus|antivirus|software\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Keep your antivirus software up to date to protect against the latest threats.",
                        "Regularly scan your computer for malware and viruses.",
                        "Avoid clicking on suspicious links or downloading unknown files.",
                        "Be cautious when using public Wi-Fi networks.",
                        "Educate yourself about common antivirus settings and configurations.",
                        "Antivirus software can help protect your computer from malware and viruses by scanning files and programs for known threats.",
                        "Some antivirus software also includes features such as real-time scanning, firewall protection, and email filtering to enhance your security.",
                        "Antivirus software can also help protect your computer from phishing attacks by blocking malicious websites and emails.",
                    }
                },
                {new Regex(@"(?=.*\btwo-factor authentication|2FA|two factor authentication\b)(?=.*\btips\b)", RegexOptions.IgnoreCase), new List<string>
                    {
                        "Enable two-factor authentication on all accounts that support it.",
                        "Use a combination of something you know (password) and something you have (phone or authentication app or fingerprint or facial print).",
                        "Regularly review and update your two-factor authentication settings.",
                        "Be cautious about sharing your two-factor authentication codes with anyone.",
                        "Educate yourself about common two-factor authentication methods and configurations.",
                        "Two-factor authentication adds an extra layer of security to your accounts by requiring a second form of verification in addition to your password.",
                        "Two-factor authentication can help protect your accounts from unauthorized access, even if your password is compromised.",
                        "Two-factor authentication can be implemented using various methods, such as SMS codes, authentication apps, or hardware tokens."
                    }
                }
            };

            // Initializing the emotion detection dictionary with regex patterns and corresponding lists of emotions
            this.emotionDetection = new Dictionary<Regex, List<string>>
            {
                {new Regex(@"worried", RegexOptions.IgnoreCase), new List<string>
                    {
                        "nervous", "concerned", "uneasy", "anxious", "apprehensive"
                    }
                },
                {new Regex(@"frustrated", RegexOptions.IgnoreCase), new List<string>
                    {
                        "annoyed", "irritated", "agitated", "upset", "discouraged"
                    }
                },
                {new Regex(@"curious", RegexOptions.IgnoreCase), new List<string>
                    {
                        "fascinated", "intrigued", "eager to know", "wondering", "keen"
                    }
                }
            };
        }

        // ----------------------------------------------------------------------------- //
        // Method to handle the chatbot conversation which includes user input,
        // responses, and emotion detection and users interests
        public string ChatBotConversation(string userInput)
        {
            // Validating user input to ensure it is not empty
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Chatbot: " + this.name + ", please enter a valid input.";
            }

            if (this.exitConfirmation)
            {
                if (userInput.ToLower() == "yes" || userInput.ToLower() == "y")
                {
                    return "Chatbot: Great! Let's continue our chat.";
                }
                else
                {
                    this.exitConfirmation = false;
                    return "Chatbot: Goodbye " + this.name + "! Please stay safe online.";
                }
            }

            // If the user types 'exit', the chatbot asks them if they want to continue or exit the chat
            else if (userInput == "exit")
            {
                this.exitConfirmation = true;
                return "Chatbot: Thank you for chatting with me, " + this.name + "! Is there anything else you would like to know or ask me?";
            }

            // Updates the lastTopic based on the user input
            foreach (var topic in this.availableTopics)
            {
                if (userInput.Contains(topic.ToLower()))
                {
                    this.lastTopic = topic.ToLower();
                    break;
                }
            }

            if (userInput.Contains("talked"))
            {
                return $"Chatbot: We have talked about the following topics: {string.Join(", ", this.userInterests)}";
            }

            // Checking if the user is interested in a topic or likes a topic
            if (userInput.Contains("interested") || userInput.Contains("like"))
            {
                this.interestsOfUsers(userInput, this.lastTopic);
            }

            // Checking if the user is feeling a certain emotion and responding accordingly
            bool emotionDetected = false;
            foreach (var emotion in this.emotionDetection)
            {
                if (emotion.Key.IsMatch(userInput))
                {
                    emotionDetected = true;
                    return this.toneOfChatbot(this.lastTopic, emotion.Key.ToString());
                }

                foreach (var emotionWord in emotion.Value)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (userInput.Contains(emotionWord))
                    {
                        if (emotion.Key.ToString().ToLower().Contains("worried"))
                        {
                            return this.toneOfChatbot(this.lastTopic, "worried");
                        }
                        else if (emotion.Key.ToString().ToLower().Contains("frustrated"))
                        {
                            return this.toneOfChatbot(this.lastTopic, "frustrated");
                        }
                        else if (emotion.Key.ToString().ToLower().Contains("curious"))
                        {
                            return this.toneOfChatbot(this.lastTopic, "curious");
                        }
                        emotionDetected = true;
                        break;
                    }
                }
            }

            // If an emotion is detected, the chatbot responds and continues to the next iteration
            if (emotionDetected)
            {
                return "";
            }

            // If the user asks for more tips on a specific topic or wants to hear another tip, the chatbot will respond with another random tip
            if (userInput.Contains("more") || userInput.Contains("again") || userInput.Contains("else") || userInput.Contains("different")
                || userInput.Contains("another") && this.lastTopic != null)
            {
                foreach (var response in this.randomResponses)
                {
                    if (response.Key.ToString().ToLower().Contains(this.lastTopic))
                    {
                        Random random = new Random();
                        int index = random.Next(response.Value.Count);
                        return $"Chatbot: Here is a tip:\n{response.Value[index]}";
                    }
                }
            }

            // If the user asks for tips on a specific topic, the chatbot will respond with a random tip from the corresponding list
            if (userInput.Contains("tips"))
            {
                foreach (var randomResponse in this.randomResponses)
                {
                    if (userInput.ToLower() == "tips")
                    {
                        return "Chatbot: Tips for what? I can give tips on the following topics:" +
                            "\nPhishing\nPasswords\nProtecting your information\nSafe browsing\nHow to maximise your safety online\nScams" +
                            "\nSocial engineering\nPrivacy\nMalware\nRansomware\nFirewalls\nAnti-Virus software\nTwo-factor authentication";
                    }

                    if (randomResponse.Key.IsMatch(userInput))
                    {
                        Random random = new Random();
                        int index = random.Next(randomResponse.Value.Count);
                        if (this.userInterests.Contains(this.lastTopic))
                        {
                            this.lastTopic = randomResponse.Key.ToString().ToLower();
                            return $"Chatbot: As someone interested in {this.lastTopic}, here is a tip:\n{randomResponse.Value[index]}";
                        }
                        else
                        {
                            this.lastTopic = randomResponse.Key.ToString().ToLower();
                            return $"Chatbot: Here is a tip for {this.lastTopic}:\n{randomResponse.Value[index]}";
                        }
                    }
                }

                // If no tips were found for the specified topic, the chatbot apologizes
                this.lastTopic = null;
                return "Chatbot: I'm sorry " + this.name + ", I don't have tips for that topic.";
            }

            // Checking if the user input is in the dictionary of responses
            foreach (var response in this.responses)
            {
                if (response.Key.IsMatch(userInput))
                {
                    if (userInput.Contains("phishing"))
                    {
                        this.lastTopic = "phishing";
                    }
                    else if (userInput.Contains("password") || userInput.Contains("passwords"))
                    {
                        this.lastTopic = "password";
                    }
                    else if (userInput.Contains("personal information"))
                    {
                        this.lastTopic = "personal information";
                    }
                    else if (userInput.Contains("safe browsing") || userInput.Contains("suspicious links") || userInput.Contains("suspicious link"))
                    {
                        this.lastTopic = "safe browsing\\suspicious links";
                    }
                    else if (userInput.Contains("safety online"))
                    {
                        this.lastTopic = "safety online";
                    }
                    else if (userInput.Contains("scam") || userInput.Contains("scams"))
                    {
                        this.lastTopic = "scam";
                    }
                    else if (userInput.Contains("social engineering"))
                    {
                        this.lastTopic = "social engineering";
                    }
                    else if (userInput.Contains("privacy"))
                    {
                        this.lastTopic = "privacy";
                    }
                    else if (userInput.Contains("malware"))
                    {
                        this.lastTopic = "malware";
                    }
                    else if (userInput.Contains("ransomware"))
                    {
                        this.lastTopic = "ransomware";
                    }
                    else if (userInput.Contains("firewall") || userInput.Contains("firewalls"))
                    {
                        this.lastTopic = "firewall";
                    }
                    else if (userInput.Contains("anti-virus") || userInput.Contains("antivirus") || userInput.Contains("software"))
                    {
                        this.lastTopic = "anti-virus";
                    }
                    else if (userInput.Contains("two-factor authentication") || userInput.Contains("2FA") || userInput.Contains("two factor authentication"))
                    {
                        this.lastTopic = "two-factor authentication";
                    }
                    else
                    {
                        this.lastTopic = null;
                    }
                    return $"Chatbot: {response.Value}";
                }
            }

            // If no response was found for the user input, the chatbot apologizes
            return "Chatbot: I'm sorry " + this.name + ", i am not sure how to respond to that. Can you please rephrase that";
        }

        // ----------------------------------------------------------------------------- //
        // Method to determine the tone of the chatbot based on the user's emotion
        private string toneOfChatbot(string lastTopic, string emotion)
        {
            if (emotion.ToString().ToLower().Contains("worried"))
            {
                return $"Chatbot: " + this.name + ", I sense that you are feeling worried. This is okay, its a usual feeling when it comes " +
                    $"to Cybersecurity. If you would like me to give you some tips on what you could do to feel more safe online, just " +
                    $"type {this.lastTopic} tips or tips for {this.lastTopic}.";
            }
            else if (emotion.ToString().ToLower().Contains("frustrated"))
            {
                return $"Chatbot: " + this.name + ", I sense that you are feeling frustrated. I know that anything related to Cybersecurity " +
                    $"can be frustrating because its not always easy to implement or use. Please dont feel frustrated, im here to help as " +
                    $"much as i can. If you would like some tips, just type {this.lastTopic} tips or tips for {this.lastTopic}.";
            }
            else if (emotion.ToString().ToLower().Contains("curious"))
            {
                return $"Chatbot: " + this.name + ", I sense that you are feeling a bit curious. That is really awesome. Curiosity never disappoints " +
                    $"in the world of Cybersecurity. If you would like to know more about {this.lastTopic}, just type {this.lastTopic} tips or tips for {this.lastTopic}.";
            }
            else
            {
                return "Thanks for sharing how you feel, " + this.name + ". I am here to help you with any questions or concerns you may have. " +
                    $"If you would like to know more about {this.lastTopic}, just type {this.lastTopic} tips or tips for {this.lastTopic} or just enter a new topic.";
            }
        }

        // ----------------------------------------------------------------------------- //
        // Method to handle the user's interests in specific topics
        private void interestsOfUsers(string userInput, string lastTopic)
        {
            if (!this.userInterests.Contains(this.lastTopic))
            {
                this.userInterests.Add(this.lastTopic);
                Console.WriteLine($"Chatbot: That is really great that you are interested in {this.lastTopic} " + this.name + ". I will remember that for future.");
            }
            else
            {
                Console.WriteLine($"Chatbot: Awesome, I see that you are already interested in {this.lastTopic} " + this.name);
            }
        }
    }
}
// -----------------------------------------------------------...000 END OF FILE 000...------------------------------------------------------------- //
