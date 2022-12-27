using Combat_System;
using System.Drawing;

namespace CombatSystem
{
    internal class CombatSystem
    {
        static void Main(string[] args)
        {
            // ABILITY AP COST
            int atkCost = 5;
            int defCost = 3;
            int healCost = 5;

            // INPUT ERROR MESSAGE
            string invalid = "Invalid entry.";

            // HIT MARKER
            int hitRoll = 0;

            // DAMAGE
            int damage = 0;

            // ATTACK AND HEAL COUNTERS
            int atkCount = 0;
            int healCount = 0;

            // HOLDS ORIGINAL DEF VALUE FOR DEFEND ACTION
            int origPlayerDef = 0;
            int origAIDef = 0;

            // INITIALIZES PLAYER STATS
            int hp = 0;
            int maxHP = 0;
            bool alive = false;
            int mp = 0;
            int maxMP = 0;
            int ap = 0;
            int maxAP = 0;
            int atk = 0;
            double crit = 4.95;
            int def = 0;
            int con = 5;
            int str = 5;
            int dex = 5;
            int intel = 5;
            int wis = 5;
            int pots = 2;

            // INITIALIZES AI STATS
            int ai_hp = 0;
            int ai_maxHP = 0;
            bool ai_alive = false;
            int ai_mp = 0;
            int ai_maxMP = 0;
            int ai_ap = 0;
            int ai_maxAP = 0;
            int ai_atk = 0;
            double ai_crit = 4.95;
            int ai_def = 0;
            int ai_con = 5;
            int ai_str = 5;
            int ai_dex = 5;
            int ai_intel = 5;
            int ai_wis = 5;
            int ai_pots = 2;

            string choice = "UNDEFINED"; // INITIALIZES VARIABLE TO HOLD PLAYER CHOICE
            string aiTurn = "UNDEFINED"; // INITIALIZES VARIABLE TO HOLD AI CHOICE

            Player Player1 = new Player(); // CREATES PLAYER GAME OBJ

            Console.Write("ENTER YOUR NAME: ");
            string userName = Console.ReadLine(); // ACCEPTS USER INPUT
            Player1.Name = userName;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Greetings, " + Player1.Name + "!");
            Console.WriteLine(" ");
            Console.WriteLine("GENERATING CHARACTER STATS...");
            Console.WriteLine(" ");

            // SETS PLAYER STATS
            con = getStats(2, 8);
            Player1.CON = con;
            str = getStats(2, 6);
            Player1.STR = str;
            dex = getStats(2, 6);
            Player1.DEX = dex;
            intel = getStats(2, 6);
            Player1.INTEL = intel;
            wis = getStats(2, 6);
            Player1.WIS = wis;

            // PLAYER ATTRIBUTE CALCS
            Player1.MaxHP = calcAttribute(con, 0);
            Player1.MaxMP = calcAttribute(intel, 0);
            Player1.MaxAP = calcAttribute(dex, 0);
            Player1.ATK = calcAttribute(str, 0);
            Player1.DEF = calcAC(con, dex, str);
            Player1.HP = Player1.MaxHP;
            Player1.MP = Player1.MaxMP;
            Player1.AP = Player1.MaxAP;

            // DISPLAYS STATS
            showStats(Player1.Name, Player1.HP, Player1.MP, Player1.AP, Player1.ATK, Player1.DEF, Player1.CON, Player1.STR, Player1.DEX, Player1.INTEL, Player1.WIS);

            Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? "); // USER INPUT PROMPT
            choice = Console.ReadLine(); // ACCEPTS USER INPUT
            choice = choice.Trim(); // TRIMS WHITE SPACE
            foreach (char c in choice)
            {
                char.ToLower(c);
            }
            // IF USER DOES NOT SELECT TO CONTINUE
            if (choice != "c")
            {
                // LOOP REITERATES UNTIL USER CHOOSES TO CONTINUE
                while (choice != "c")
                {
                    // IF USER CHOOSES TO RE-ROLL STATS
                    if (choice == "r")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("RE-ROLLING CHARACTER STATS");
                        Console.WriteLine(" ");

                        // SETS PLAYER STATS
                        con = getStats(2, 8);
                        Player1.CON = con;
                        str = getStats(2, 6);
                        Player1.STR = str;
                        dex = getStats(2, 6);
                        Player1.DEX = dex;
                        intel = getStats(2, 6);
                        Player1.INTEL = intel;
                        wis = getStats(2, 6);
                        Player1.WIS = wis;

                        // PLAYER ATTRIBUTE CALCS
                        Player1.MaxHP = calcAttribute(con, 0);
                        Player1.MaxMP = calcAttribute(intel, 0);
                        Player1.MaxAP = calcAttribute(dex, 0);
                        Player1.ATK = calcAttribute(str, 0);
                        Player1.DEF = calcAC(con, dex, str);
                        Player1.HP = Player1.MaxHP;
                        Player1.MP = Player1.MaxMP;
                        Player1.AP = Player1.MaxAP;

                        // DISPLAYS PLAYER STATS
                        showStats(Player1.Name, Player1.HP, Player1.MP, Player1.AP, Player1.ATK, Player1.DEF, Player1.CON, Player1.STR, Player1.DEX, Player1.INTEL, Player1.WIS);

                        Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? "); // USER INPUT PROMPT
                        choice = Console.ReadLine(); // ACCEPTS USER INPUT
                        choice = choice.Trim(); // TRIMS WHITE SPACE
                        foreach (char c in choice)
                        {
                            char.ToLower(c);
                        }
                        Console.WriteLine(" ");

                    }
                    else
                    {
                        Console.WriteLine(invalid); // ERROR MESSAGE
                        Console.WriteLine(" ");
                        Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? "); // USER INPUT PROMPT
                        choice = Console.ReadLine(); // ACCEPTS USER INPUT
                        choice = choice.Trim(); // TRIMS WHITE SPACE
                        foreach (char c in choice)
                        {
                            char.ToLower(c);
                        }
                        Console.WriteLine(" ");
                    }

                }

            }
            Console.WriteLine(" ");
            Console.WriteLine("GENERATING AI PLAYER...");
            Console.WriteLine(" ");

            NPC AIPlayer = new NPC(); // CREATES AI GAME OBJ

            // SETS AI NAME
            string npcName = "Enemy"; 
            AIPlayer.Name = npcName;

            Console.WriteLine("SIMULATING DICE ROLLS FOR " + AIPlayer.Name + " STATS...");

            // SETS AI STATS
            ai_con = getStats(2, 8);
            AIPlayer.CON = ai_con;
            ai_str = getStats(2, 6);
            AIPlayer.STR = ai_str;
            ai_dex = getStats(2, 6);
            AIPlayer.DEX = ai_dex;
            ai_intel = getStats(2, 6);
            AIPlayer.INTEL = ai_intel;
            ai_wis = getStats(2, 6);
            AIPlayer.WIS = ai_wis;

            // AI ATTRIBUTE CALCS
            AIPlayer.MaxHP = calcAttribute(ai_con, 0);
            AIPlayer.MaxMP = calcAttribute(ai_intel, 0);
            AIPlayer.MaxAP = calcAttribute(ai_dex, 0);
            AIPlayer.ATK = calcAttribute(ai_str, 0);
            AIPlayer.DEF = calcAC(ai_con, ai_dex, ai_str);
            AIPlayer.HP = AIPlayer.MaxHP;
            AIPlayer.MP = AIPlayer.MaxMP;
            AIPlayer.AP = AIPlayer.MaxAP;

            // DISPLAYS AI STATS
            showStats(AIPlayer.Name, AIPlayer.HP, AIPlayer.MP, AIPlayer.AP, AIPlayer.ATK, AIPlayer.DEF, AIPlayer.CON, AIPlayer.STR, AIPlayer.DEX, AIPlayer.INTEL, AIPlayer.WIS);

            // -------------------------------- [ COMBAT START DIALOG ] -----------------------------------------------------------------------------------------

            Console.Write("START COMBAT? ENTER YES (Y) OR NO (N): ");
            choice = Console.ReadLine();
            Console.WriteLine(" ");
            foreach (char c in choice)
            {
                char.ToLower(c);
            }
            if (choice != "y")
            {
                while (choice != "y")
                {
                    if (choice == "n")
                    {
                        Console.Write("THIS WILL EXIT THE PROGRAM. START COMBAT? ENTER YES (Y) OR NO (N): ");
                        choice = Console.ReadLine();
                        if (choice != "y")
                        {
                            Environment.Exit(0);
                        }
                        else continue;
                    }
                    else if (choice != "y" && choice != "n")
                    {
                        Console.WriteLine(invalid);
                        Console.WriteLine(" ");
                        Console.Write("START COMBAT? ENTER YES (Y) OR NO (N): ");
                        choice = Console.ReadLine();
                    }

                }
            }
            else if (choice == "y")
            {
                while (choice == "y")
                {
                    // INITIALIZES BOTH FIGHTERS AS ALIVE
                    Player1.Alive = true;
                    AIPlayer.Alive = true;

                    Console.WriteLine("< < < BEGINNING COMBAT SEQUENCE > > >");
                    Console.WriteLine(" ");
                    Console.WriteLine("ROLLING INITIATIVE...");
                    Player1.Init = diceRoll(1, 20);
                    Console.WriteLine("--- " + Player1.Name + " rolled " + Player1.Init);
                    AIPlayer.Init = diceRoll(1, 20);
                    Console.WriteLine("--- " + AIPlayer.Name + " rolled " + AIPlayer.Init);
                    Console.WriteLine(" ");

                    // IF INIT ROLL ENDS IN DRAW
                    if (Player1.Init == AIPlayer.Init)
                    {
                        Console.WriteLine("INITIATIVE ROLL DRAW! RE-ROLLING INITIATIVE... ");
                        Console.WriteLine(" ");
                        Player1.Init = diceRoll(1, 20);
                        Console.WriteLine("--- " + Player1.Name + " rolled " + Player1.Init);
                        AIPlayer.Init = diceRoll(1, 20);
                        Console.WriteLine("--- " + AIPlayer.Name + " rolled " + AIPlayer.Init);
                        Console.WriteLine(" ");
                    }

                    // -------------------------------- [ IF PLAYER WINS INIT ROLL ] -----------------------------------------------------------------------------------------

                    if (Player1.Init > AIPlayer.Init)
                    {
                        origPlayerDef = Player1.DEF; // HOLDS PLAYER ORIGINAL DEF VALUE
                        origAIDef = AIPlayer.DEF; // HOLDS AI ORIGINAL DEF VALUE

                        Console.WriteLine(Player1.Name + " GOES FIRST... ");
                        Console.WriteLine(" ");

                        // THIS LOOP CONTAINS PLAYER AND AI TURNS
                        while (Player1.Alive == true && AIPlayer.Alive == true)
                        {
                            // -------------------------------- [ PLAYER TURN START ]

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            Player1.DEF = origPlayerDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE PLAYER HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT TURTLING.

                            Console.WriteLine("---------- " + Player1.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            Player1.AP = Player1.MaxAP; // REFRESHES AP AT THE START OF EACH TURN
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                            Console.WriteLine(AIPlayer.Name + " HP: " + AIPlayer.HP);
                            Console.WriteLine(" ");
                            Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? "); // USER INPUT PROMPT
                            choice = Console.ReadLine(); // ACCEPTS USER INPUT
                            choice = choice.Trim(); // TRIMS WHITE SPACE
                            Console.WriteLine(" ");
                            foreach (char c in choice)
                            {
                                char.ToLower(c);
                            }
                            while (Player1.AP > 0)
                            {
                                if (choice != "e")
                                {
                                    // IF PLAYER CHOOSES TO ATTACK
                                    if (choice == "a")
                                    {
                                        if (atkCount < 1)
                                        {
                                            // HIT ROLL
                                            Console.WriteLine(Player1.Name + " ROLLS FOR HIT...");
                                            hitRoll = rollHit();
                                            Console.WriteLine("--- " + Player1.Name + " ROLLED " + hitRoll);

                                            // IF SUCCESSFUL
                                            if (hitRoll >= AIPlayer.DEF)
                                            {
                                                damage = getDamage(Player1.ATK, AIPlayer.DEF);
                                                AIPlayer.HP = AIPlayer.HP - damage;
                                                Console.WriteLine("--- " + Player1.Name + " HITS " + AIPlayer.Name + " FOR " + damage + " DAMAGE!");
                                                Console.WriteLine(" ");
                                            }
                                            else
                                            {
                                                Console.WriteLine("--- " + Player1.Name + "'s ATTACK MISSES!");
                                                Console.WriteLine(" ");
                                            }
                                            // CALCULATES REMAINING AP
                                            Player1.AP = Player1.AP - atkCost;
                                            atkCount++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("YOU CAN ONLY ATTACK ONCE PER ROUND!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                                            Console.WriteLine("REMAINING POTIONS: " + Player1.Pots);
                                            Console.WriteLine(AIPlayer.Name + " HP: " + AIPlayer.HP);
                                            Console.WriteLine(" ");
                                            Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? "); // USER INPUT PROMPT
                                            choice = Console.ReadLine(); // ACCEPTS USER INPUT
                                            choice = choice.Trim(); // TRIMS WHITE SPACE
                                            Console.WriteLine(" ");
                                            foreach (char c in choice)
                                            {
                                                char.ToLower(c);
                                            }
                                        }
                                    }
                                    // IF PLAYER CHOOSES TO DEFEND
                                    else if (choice == "d")
                                    {
                                        Player1.DEF = Player1.DEF + useDefend(Player1.DEF);
                                        Console.WriteLine("--- " + Player1.Name + " RAISES THEIR SHIELD, PREPARING FOR " + AIPlayer.Name + "'s NEXT ATTACK!");
                                        Console.WriteLine("--- DEFENSE INCREASES BY: " + (Player1.DEF - origPlayerDef));
                                        Console.WriteLine("--- " + Player1.Name + "'s DEFENSE: " + Player1.DEF);
                                        Console.WriteLine(" ");
                                        Player1.AP = Player1.AP - defCost;
                                        choice = "e";
                                        break;
                                    }
                                    // IF PLAYER CHOOSES TO HEAL
                                    else if (choice == "h")
                                    {
                                        if (Player1.Pots > 0)
                                        {
                                            if (healCount < 1)
                                            {
                                                Player1.HP = usePotion(Player1.HP, Player1.MaxHP);
                                                Player1.Pots = Player1.Pots - 1;
                                                Console.WriteLine("--- " + Player1.Name + " DRINKS A POTION FROM THEIR BELT!");
                                                Console.WriteLine("--- REMAINING POTIONS: " + Player1.Pots);
                                                Console.WriteLine(" ");
                                                Player1.AP = Player1.AP - healCost;
                                                healCount++;
                                            }
                                            else
                                            {
                                                Console.WriteLine("YOU CAN ONLY HEAL ONCE PER ROUND!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(Player1.Name + " REACHED FOR A POTION, BUT THEIR BELT WAS EMPTY!");
                                            Player1.AP = Player1.AP - (healCost / 2);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(invalid);
                                    }

                                    // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                    AIPlayer.Alive = isAlive(AIPlayer.HP);
                                    if (AIPlayer.Alive == false)
                                    {
                                        break;
                                    }

                                    // DISPLAYS PLAYER AND AI REMAINING HP
                                    Console.WriteLine("----------");
                                    showStat(Player1.Name, "HP", Player1.HP);
                                    showStat(AIPlayer.Name, "HP", AIPlayer.HP);
                                    Console.WriteLine("----------");
                                    Console.WriteLine(" ");

                                    if (Player1.AP > 0)
                                    {
                                        Console.Write("YOU HAVE " + Player1.AP + " ACTION POINTS REMAINING. ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                                        choice = Console.ReadLine();
                                        Console.WriteLine(" ");
                                        choice = choice.Trim();
                                        foreach (char c in choice)
                                        {
                                            char.ToLower(c);
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine(Player1.Name + "'s TURN ENDS...");
                            Console.WriteLine(" ");

                            // -------------------------------- [ AI TURN START ]

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            AIPlayer.DEF = origAIDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE AI HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT FOXHOLING.

                            Console.WriteLine("---------- " + AIPlayer.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            AIPlayer.AP = AIPlayer.MaxAP; // REFILLS AP AT THE START OF EACH TURN

                            while (AIPlayer.AP > defCost)
                            {
                                // DETERMINES AI CHOICE
                                aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, atkCount, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots, healCount,
                                Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP, atkCost, defCost, healCost);

                                // IF AI CHOOSES TO ATTACK
                                if (aiTurn == "a")
                                {
                                    // HIT ROLL
                                    Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                    hitRoll = rollHit();
                                    Console.WriteLine("--- " + AIPlayer.Name + " ROLLED " + hitRoll);
                                    Console.WriteLine(" ");

                                    // IF SUCCESSFUL
                                    if (hitRoll >= Player1.DEF)
                                    {
                                        damage = getDamage(AIPlayer.ATK, Player1.DEF);
                                        Player1.HP = Player1.HP - damage;
                                        Console.WriteLine("--- " + AIPlayer.Name + " HITS " + Player1.Name + " FOR " + damage + " DAMAGE!");
                                        Console.WriteLine(" ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("--- " + AIPlayer.Name + "'s ATTACK MISSES!");
                                    }
                                    // CALCULATES REMAINING AP
                                    AIPlayer.AP = AIPlayer.AP - atkCost;
                                    atkCount++;
                                }
                                // IF AI CHOOSES TO DEFEND
                                else if (aiTurn == "d")
                                {
                                    AIPlayer.DEF = AIPlayer.DEF + useDefend(AIPlayer.DEF);
                                    Console.WriteLine("--- " + AIPlayer.Name + " RAISES THEIR SHIELD, PREPARING FOR " + Player1.Name + "'s NEXT ATTACK!");
                                    Console.WriteLine("--- DEFENSE INCREASES BY: " + (AIPlayer.DEF - origAIDef));
                                    Console.WriteLine("--- " + AIPlayer.Name + "DEFENSE: " + AIPlayer.DEF);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - defCost;
                                    aiTurn = "e";
                                    break;
                                }
                                // IF AI CHOOSES TO HEAL
                                else if (aiTurn == "h")
                                {
                                    AIPlayer.HP = usePotion(AIPlayer.HP, AIPlayer.MaxHP);
                                    AIPlayer.Pots = AIPlayer.Pots - 1;
                                    Console.WriteLine("--- " + AIPlayer.Name + " DRINKS A POTION FROM THEIR BELT!");
                                    Console.WriteLine("--- REMAINING POTIONS: " + AIPlayer.Pots);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - healCost;
                                    healCount++;
                                }

                                // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                Player1.Alive = isAlive(Player1.HP);
                                if (Player1.Alive == false)
                                {
                                    break;
                                }

                                // DISPLAYS PLAYER AND AI REMAINING HP
                                Console.WriteLine("----------");
                                showStat(Player1.Name, "HP", Player1.HP);
                                showStat(AIPlayer.Name, "HP", AIPlayer.HP);
                                Console.WriteLine("----------");
                                Console.WriteLine(" ");
                            }

                        }
                        Console.WriteLine(AIPlayer.Name + "'s TURN ENDS...");
                        Console.WriteLine(" ");

                        // SHOULD TRIGGER AFTER EITHER AI OR PLAYER HP REACHES 0
                        AIPlayer.Alive = isAlive(AIPlayer.HP);
                        Player1.Alive = isAlive(Player1.HP);
                        if (AIPlayer.Alive == false)
                        {
                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                        }
                        else
                        {
                            Console.WriteLine(AIPlayer.Name + " wins!");
                        }
                    }
                    // -------------------------------- [ IF AI WINS INIT ROLL ] -----------------------------------------------------------------------------------------

                    else if (AIPlayer.Init > Player1.Init)
                    {
                        origPlayerDef = Player1.DEF; // HOLDS PLAYER ORIGINAL DEF VALUE
                        origAIDef = AIPlayer.DEF; // HOLDS AI ORIGINAL DEF VALUE

                        Console.WriteLine(AIPlayer.Name + " GOES FIRST... ");
                        Console.WriteLine(" ");

                        while (Player1.Alive == true && AIPlayer.Alive == true)
                        {
                            // -------------------------------- [ AI TURN START ]

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            AIPlayer.DEF = origAIDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE AI HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT FOXHOLING.

                            Console.WriteLine("---------- " + AIPlayer.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            AIPlayer.AP = AIPlayer.MaxAP; // REFILLS AP AT THE START OF EACH TURN

                            while (AIPlayer.AP > defCost)
                            {
                                // DETERMINES AI CHOICE
                                aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, atkCount, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots, healCount,
                                Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP, atkCost, defCost, healCost);

                                // IF AI CHOOSES TO ATTACK
                                if (aiTurn == "a")
                                {
                                    // HIT ROLL
                                    Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                    hitRoll = rollHit();
                                    Console.WriteLine("--- " + AIPlayer.Name + " ROLLED " + hitRoll);
                                    Console.WriteLine(" ");

                                    // IF SUCCESSFUL
                                    if (hitRoll >= Player1.DEF)
                                    {
                                        damage = getDamage(AIPlayer.ATK, Player1.DEF);
                                        Player1.HP = Player1.HP - damage;
                                        Console.WriteLine("--- " + AIPlayer.Name + " HITS " + Player1.Name + " FOR " + damage + " DAMAGE!");
                                        Console.WriteLine(" ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("--- " + AIPlayer.Name + "'s ATTACK MISSES!");
                                    }
                                    // CALCULATES REMAINING AP
                                    AIPlayer.AP = AIPlayer.AP - atkCost;
                                    atkCount++;
                                }
                                // IF AI CHOOSES TO DEFEND
                                else if (aiTurn == "d")
                                {
                                    AIPlayer.DEF = AIPlayer.DEF + useDefend(AIPlayer.DEF);
                                    Console.WriteLine("--- " + AIPlayer.Name + " RAISES THEIR SHIELD, PREPARING FOR " + Player1.Name + "'s NEXT ATTACK!");
                                    Console.WriteLine("--- DEFENSE INCREASES BY: " + (AIPlayer.DEF - origAIDef));
                                    Console.WriteLine("--- " + AIPlayer.Name + "DEFENSE: " + AIPlayer.DEF);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - defCost;
                                    aiTurn = "e";
                                    break;
                                }
                                // IF AI CHOOSES TO HEAL
                                else if (aiTurn == "h")
                                {
                                    usePotion(AIPlayer.HP, AIPlayer.MaxHP);
                                    AIPlayer.Pots = AIPlayer.Pots - 1;
                                    Console.WriteLine("--- " + AIPlayer.Name + " DRINKS A POTION FROM THEIR BELT!");
                                    Console.WriteLine("--- REMAINING POTIONS: " + AIPlayer.Pots);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - healCost;
                                    healCount++;
                                }

                                // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                Player1.Alive = isAlive(Player1.HP);
                                if (Player1.Alive == false)
                                {
                                    break;
                                }

                                // DISPLAYS PLAYER AND AI REMAINING HP
                                Console.WriteLine("----------");
                                showStat(Player1.Name, "HP", Player1.HP);
                                showStat(AIPlayer.Name, "HP", AIPlayer.HP);
                                Console.WriteLine("----------");
                                Console.WriteLine(" ");
                            }
                            Console.WriteLine(AIPlayer.Name + "'s TURN ENDS...");
                            Console.WriteLine(" ");

                            // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                            Player1.Alive = isAlive(Player1.HP);
                            if (Player1.Alive == false)
                            {
                                break;
                            }

                            // -------------------------------- [ PLAYER TURN START ]

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            Player1.DEF = origPlayerDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE PLAYER HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT FOXHOLING.

                            Console.WriteLine("---------- " + Player1.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            Player1.AP = Player1.MaxAP; // REFRESHES AP AT THE START OF EACH TURN
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                            Console.WriteLine(AIPlayer.Name + " HP: " + AIPlayer.HP);
                            Console.WriteLine(" ");
                            Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? "); // USER INPUT PROMPT
                            choice = Console.ReadLine(); // ACCEPTS USER INPUT
                            choice = choice.Trim(); // TRIMS WHITE SPACE
                            Console.WriteLine(" ");
                            foreach (char c in choice)
                            {
                                char.ToLower(c);
                            }
                            while (Player1.AP > 0)
                            {
                                if (choice != "e")
                                {
                                    // IF PLAYER CHOOSES TO ATTACK
                                    if (choice == "a")
                                    {
                                        if (atkCount < 1)
                                        {
                                            // HIT ROLL
                                            Console.WriteLine(Player1.Name + " ROLLS FOR HIT...");
                                            hitRoll = rollHit();
                                            Console.WriteLine("--- " + Player1.Name + " ROLLED " + hitRoll);

                                            // IF SUCCESSFUL
                                            if (hitRoll >= AIPlayer.DEF)
                                            {
                                                damage = getDamage(Player1.ATK, AIPlayer.DEF);
                                                AIPlayer.HP = AIPlayer.HP - damage;
                                                Console.WriteLine("--- " + Player1.Name + " HITS " + AIPlayer.Name + " FOR " + damage + " DAMAGE!");
                                                Console.WriteLine(" ");
                                            }
                                            else
                                            {
                                                Console.WriteLine("--- " + Player1.Name + "'s ATTACK MISSES!");
                                                Console.WriteLine(" ");
                                            }
                                            // CALCULATES REMAINING AP
                                            Player1.AP = Player1.AP - atkCost;
                                            atkCount++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("YOU CAN ONLY ATTACK ONCE PER ROUND!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                                            Console.WriteLine("REMAINING POTIONS: " + Player1.Pots);
                                            Console.WriteLine(AIPlayer.Name + " HP: " + AIPlayer.HP);
                                            Console.WriteLine(" ");
                                            Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? "); // USER INPUT PROMPT
                                            choice = Console.ReadLine(); // ACCEPTS USER INPUT
                                            choice = choice.Trim(); // TRIMS WHITE SPACE
                                            Console.WriteLine(" ");
                                            foreach (char c in choice)
                                            {
                                                char.ToLower(c);
                                            }
                                        }
                                    }
                                    // IF PLAYER CHOOSES TO DEFEND
                                    else if (choice == "d")
                                    {
                                        Player1.DEF = Player1.DEF + useDefend(Player1.DEF);
                                        Console.WriteLine("--- " + Player1.Name + " RAISES THEIR SHIELD, PREPARING FOR " + AIPlayer.Name + "'s NEXT ATTACK!");
                                        Console.WriteLine("--- DEFENSE INCREASES BY: " + (Player1.DEF - origPlayerDef));
                                        Console.WriteLine("--- " + Player1.Name + "'s DEFENSE: " + Player1.DEF);
                                        Console.WriteLine(" ");
                                        Player1.AP = Player1.AP - defCost;
                                        choice = "e";
                                        break;
                                    }
                                    // IF PLAYER CHOOSES TO HEAL
                                    else if (choice == "h")
                                    {
                                        if (Player1.Pots > 0)
                                        {
                                            if (healCount < 1)
                                            {
                                                usePotion(Player1.HP, Player1.MaxHP);
                                                Player1.Pots = Player1.Pots - 1;
                                                Console.WriteLine("--- " + Player1.Name + " DRINKS A POTION FROM THEIR BELT!");
                                                Console.WriteLine("--- REMAINING POTIONS: " + Player1.Pots);
                                                Console.WriteLine(" ");
                                                Player1.AP = Player1.AP - healCost;
                                                healCount++;
                                            }
                                            else
                                            {
                                                Console.WriteLine("YOU CAN ONLY HEAL ONCE PER ROUND!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(Player1.Name + " REACHED FOR A POTION, BUT THEIR BELT WAS EMPTY!");
                                            Player1.AP = Player1.AP - (healCost / 2);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(invalid);
                                    }

                                    // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                    AIPlayer.Alive = isAlive(AIPlayer.HP);
                                    if (AIPlayer.Alive == false)
                                    {
                                        break;
                                    }

                                    // DISPLAYS PLAYER AND AI REMAINING HP
                                    Console.WriteLine("----------");
                                    showStat(Player1.Name, "HP", Player1.HP);
                                    showStat(AIPlayer.Name, "HP", AIPlayer.HP);
                                    Console.WriteLine("----------");
                                    Console.WriteLine(" ");

                                    if (Player1.AP > 0)
                                    {
                                        Console.Write("YOU HAVE " + Player1.AP + " ACTION POINTS REMAINING. ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                                        choice = Console.ReadLine();
                                        Console.WriteLine(" ");
                                        choice = choice.Trim();
                                        foreach (char c in choice)
                                        {
                                            char.ToLower(c);
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine(Player1.Name + "'s TURN ENDS...");
                            Console.WriteLine(" ");
                        }
                        if (Player1.Alive == true && AIPlayer.Alive == false)
                        {
                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                        }
                        else if (Player1.Alive == false && AIPlayer.Alive == true)
                        {
                            Console.WriteLine("YOU LOSE!");
                        }
                    }
                    Console.Write("PLAY AGAIN? YES (Y) OR NO (N)? ");
                    choice = Console.ReadLine();
                    choice = choice.Trim();
                    foreach (char c in choice)
                    {
                        char.ToLower(c);
                    }
                    if (choice = "n")
                    {
                        Environment.Exit(0);
                    }
                }
                
            }

            // THERE BE METHODS BELOW THIS LINE!

            static int getStats(int rolls, int sides)
            {
                int[] results = new int[rolls];
                int sum = 0;

                for (int i = 0; i < rolls; i++)
                {
                    results[i] = diceRoll(rolls, sides);
                    sum = sum + results[i];
                }
                int output = sum;
                return output;
            }

            static void showStat(string target, string declarator, int stat)
            {
                Console.WriteLine(target + " " + declarator + ": " + stat);
            }

            static void showStats(string targetName, int hp, int mp, int ap, int atk, int def, int con, int str, int dex, int intel, int wis)
            {
                Console.WriteLine(targetName + " STATS:");
                Console.WriteLine("-----------------------");
                Console.WriteLine("HP: " + hp);
                Console.WriteLine("MP: " + mp);
                Console.WriteLine("AP: " + ap);
                Console.WriteLine("ATK: " + atk);
                Console.WriteLine("DEF: " + def);
                Console.WriteLine(" ");
                Console.WriteLine("CON: " + con);
                Console.WriteLine("STR: " + str);
                Console.WriteLine("DEX: " + dex);
                Console.WriteLine("INT: " + intel);
                Console.WriteLine("WIS: " + wis);
                Console.WriteLine("-----------------------");
                Console.WriteLine(" ");
            }

            static int getDamage(int atk, int targetDef)
            {
                int damage = diceRoll(2, 6) + (atk / 7);
                int totalDmg = damage - (targetDef / 5);
                return totalDmg;
            }

            static int diceRoll(int dice, int sides)
            {
                Random Dice = new Random();
                Thread.Sleep(350);
                int roll = Dice.Next(1, sides);
                if (roll == 0)
                {
                    Thread.Sleep(350);
                    roll = Dice.Next(1, sides);
                }
                return roll;
            }

            static int rollHit()
            {
                int roll = diceRoll(1, 20);
                return roll;
            }

            static int calcAttribute(int stat,  int modifier)
            {
                int result = stat + ((stat + modifier) + diceRoll(2, 8));
                return result;
            }

            static int calcAC(int con, int dex, int str)
            {
                int ac = (con / 2) + (dex / 4) + (str / 4);
                return ac;
            }

            static bool isAlive(int hp)
            {
                bool alive;
                if (hp > 0)
                {
                    alive = true;
                }
                else alive = false;

                return alive;
            }

            static int useAttack(int atk, int targetHP, int targetDef)
            {
                targetHP = (targetHP + targetDef) - atk;
                return targetHP;
            }

            static int useDefend(int def)
            {
                int buff = def / 3;
                return buff;
            }

            static int usePotion(int hp, int maxHP)
            {
                int pot = maxHP / 4;
                hp = hp + pot;
                if (hp > maxHP)
                {
                    hp = maxHP;
                }
                return hp;
            }

            static double hitChance(int attackerDex, int targetDex)
            {
                double hitChance = (attackerDex / targetDex) * 100;
                return hitChance;
            }

            static double critChance(int aDex, double aCrit, int tDex)
            {
                double critChance;
                double aCritBase = (aDex / 4) / 3;
                double tCritBase = (tDex / 4) / 3;

                critChance = (aCritBase - tCritBase) + aCrit;
                return critChance;
            }

            // AI BEHAVIORAL ALGORITHM STARTS HERE
            static string aiChoice(int aiHP, int aiMaxHP, int aiATK, int aiATKCount, int aiDEF, int aiMP, int aiAP, int aiPots,
                               int aiHealCount, int playerHP, int playerMaxHP, int playerATK, int playerDEF, int playerMP, int atkCost, int defCost, int healCost)
            {
                string choice = "UNDEFINED";
                int highest = 0;
                int atkWeight = 0;
                int defWeight = 0;
                int healWeight = 0;

                // CHECKS TO ENSURE THERE ARE ENOUGH ACTION POINTS TO EXECUTE AN ACTION
                if (aiAP >= defCost)
                {
                    // IF AI HAS LESS THAN 20% HP
                    if (aiHP < (aiMaxHP / 5))
                    {
                        // IF AI HP IS GREATER THAN PLAYER HP
                        if (aiHP >= playerHP)
                        {
                            // FAVORS OFFENSE IF AI ATK IS GREATER THAN PLAYER DEF
                            if (aiATK > playerDEF)
                            {
                                // IF AI HAS NOT YET ATTACKED
                                if (aiATKCount < 1)
                                {
                                    atkWeight++;
                                }
                                // IF AI HAS ALREADY ATTACKED
                                else if (aiATKCount > 0)
                                {
                                    // AI HAS NOT YET HEALED
                                    if (aiHealCount < 1)
                                    {
                                        healWeight++;
                                    }
                                    // IF AI HAS ALREADY HEALED
                                    else if (aiHealCount > 0)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                            // FAVORS HEALING IF AI ATK IS LESS THAN OR EQUIVALENT TO PLAYER DEF
                            else if (aiATK <= playerDEF)
                            {
                                // IF AI HAS NOT YET HEALED
                                if (aiHealCount < 1)
                                {
                                    healWeight++;
                                }
                                // IF AI HAS ALREADY HEALED
                                else if (aiHealCount > 0)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                        }
                        // FAVORS HEALING IF AI HP IS LESS THAN PLAYER HP
                        else if (aiHP < playerHP)
                        {
                            // IF AI HAS NOT YET HEALED
                            if (aiHealCount < 1)
                            {
                                healWeight++;
                            }
                            // IF AI HAS ALREADY HEALED
                            else if (aiHealCount > 0)
                            {
                                // IF AI CAN ATTACK
                                if (aiATKCount < 1)
                                {
                                    atkWeight++;
                                }
                                // IF AI CANNOT ATTACK
                                else if (aiATKCount > 0)
                                {
                                    defWeight++;
                                }
                            }
                        }
                    }
                    // IF AI HP IS BETWEEN 25% AND 50%
                    if (aiHP >= (aiMaxHP / 5) && aiHP < (aiMaxHP / 2))
                    {
                        // FAVORS HEALING IF AI HP IS GREATER THAN PLAYER HP
                        if (aiHP >= playerHP)
                        {
                            // IF AI CAN HEAL
                            if (aiHealCount < 1)
                            {
                                healWeight++;
                            }
                            // IF AI CANNOT HEAL
                            else if (aiHealCount > 0)
                            {
                                // FAVORS OFFENSE IF AI DEF IS GREATER THAN PLAYER ATK
                                if (aiDEF > playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0)
                                    {
                                        defWeight++;
                                    }
                                }
                                // FAVORS OFFENSE IF AI DEF IS LESS THAN PLAYER ATK
                                else if (aiDEF <= playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                        }
                        // FAVORS HEALING IF AI HP IS LESS THAN PLAYER HP
                        else if (aiHP < playerHP)
                        {
                            // IF AI CAN HEAL
                            if (aiHealCount < 1)
                            {
                                healWeight++;
                            }
                            // IF AI CANNOT HEAL
                            else if (aiHealCount > 0)
                            {
                                // IF AI DEF IS GREATER THAN PLAYER ATK
                                if (aiDEF > playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                        }
                    }
                    // IF AI IS BETWEEN 50% AND 100%
                    if (aiHP >= (aiMaxHP / 2) && aiHP < aiMaxHP)
                    {
                        // IF AI CAN ATTACK
                        if (aiATKCount < 1)
                        {
                            atkWeight++;
                        }
                        // IF AI CANNOT ATTACK
                        else if (aiATKCount > 0)
                        {
                            defWeight++;
                        }
                    }
                    // FAVORS OFFENSE IF AI IS AT FULL HP
                    if (aiAP == aiMaxHP)
                    {
                        // IF AI CAN ATTACK
                        if (aiATKCount < 1)
                        {
                            atkWeight++;
                        }
                        // IF AI CANNOT ATTACK
                        else if (aiATKCount > 0)
                        {
                            defWeight++;
                        }
                    }
                }
                // ASSIGNS HIGHEST WEIGHTED VALUE TO THE VARIABLE "HIGHEST"
                highest = Math.Max(atkWeight, Math.Max(healWeight, defWeight));

                // USES HIGHEST WEIGHTED VALUE TO DETERMINE AI CHOICE
                if (highest == atkWeight)
                {
                    choice = "a";
                }
                else if (highest == defWeight)
                {
                    choice = "d";
                }
                else if (highest == healWeight)
                {
                    choice = "h";
                }
                // IF AI DOES NOT HAVE SUFFICIENT AP TO TAKE ANY ACTION
                else
                {
                    choice = "e";
                }
                return choice;
                
            }
        }
    }
}