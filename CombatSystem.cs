using Combat_System;
using System.Drawing;
using System.Collections.Generic;


namespace CombatSystem
{
    internal class CombatSystem
    {
        static void Main(string[] args)
        {
            // ABILITY AP COST
            int atkCost = 0;
            int defCost = 2;
            int healCost = 3;

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

            // HOLDS HEALED AMOUNT
            int healAmount = 0;

            // INITIALIZES PLAYER STATS
            int hp = 0;
            int maxHP = 0;
            bool alive = false;
            int mp = 0;
            int maxMP = 0;
            int ap = 0;
            int maxAP = 0;
            int atk = 0;
            int weaponDmg = 5;
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
            int ai_weaponDmg = 5;
            double ai_crit = 4.95;
            int ai_def = 0;
            int ai_con = 5;
            int ai_str = 5;
            int ai_dex = 5;
            int ai_intel = 5;
            int ai_wis = 5;
            int ai_pots = 2;
            

            // INITIALIZES WEAPONS
            Fists Fists = new Fists();
            Fists.Name = "Fists";
            Knife Knife = new Knife();
            Knife.Name = "Knife";
            Sword Sword = new Sword();
            Sword.Name = "Sword";
            Axe Axe = new Axe();
            Axe.Name = "Axe";
            Warhammer Warhammer = new Warhammer();
            Warhammer.Name = "Warhammer";


            string choice = "UNDEFINED"; // INITIALIZES VARIABLE TO HOLD PLAYER CHOICE
            int choice2 = 0; // DECLARES VARIABLE TO HOLD SPECIALIZED INT CHOICES
            string aiTurn = "UNDEFINED"; // INITIALIZES VARIABLE TO HOLD AI CHOICE

            Player Player1 = new Player(); // CREATES PLAYER GAME OBJ

            showLogo(); // GAME TITLE HEADER
            Console.WriteLine("//==================================================================================//\n\n");
            showWelcomeMsg(); // WELCOME BLURB

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
            showStats(Player1.Name, Player1.HP, Player1.MP, Player1.AP, Player1.ATK, Player1.DEF, Player1.CON, Player1.STR, Player1.DEX, Player1.INTEL, Player1.WIS, Player1.WeaponName);

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
                        showStats(Player1.Name, Player1.HP, Player1.MP, Player1.AP, Player1.ATK, Player1.DEF, Player1.CON, Player1.STR, Player1.DEX, Player1.INTEL, Player1.WIS, Player1.WeaponName);

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

            NPC AIPlayer = new NPC(); // CREATES AI GAME OBJ

            // SETS AI NAME
            string npcName = "Enemy"; 
            AIPlayer.Name = npcName;

            Console.WriteLine("--- SIMULATING DICE ROLLS FOR " + AIPlayer.Name + " STATS...");
            Console.WriteLine("");

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

            // SETS AI WEAPON & ATK COST
            int aiWeapon = getEnemyWeapon();
            if (aiWeapon == 1)
            {
                AIPlayer.WeaponName = Fists.Name;
                AIPlayer.WeaponDMG = Fists.Dmg;
                AIPlayer.AtkCost = Fists.AtkCost;
            }
            else if (aiWeapon == 2)
            {
                AIPlayer.WeaponName = Knife.Name;
                AIPlayer.WeaponDMG = Knife.Dmg;
                AIPlayer.AtkCost = Knife.AtkCost;
            }
            else if (aiWeapon == 3)
            {
                AIPlayer.WeaponName = Sword.Name;
                AIPlayer.WeaponDMG = Sword.Dmg;
                AIPlayer.AtkCost = Sword.AtkCost;
            }
            else if (aiWeapon == 4)
            {
                AIPlayer.WeaponName = Axe.Name;
                AIPlayer.WeaponDMG = Axe.Dmg;
                AIPlayer.AtkCost = Axe.AtkCost;
            }
            else if (aiWeapon == 5)
            {
                AIPlayer.WeaponName = Warhammer.Name;
                AIPlayer.WeaponDMG = Warhammer.Dmg;
                AIPlayer.AtkCost = Warhammer.AtkCost;
            }
            // DISPLAYS AI STATS
            showStats(AIPlayer.Name, AIPlayer.HP, AIPlayer.MP, AIPlayer.AP, AIPlayer.ATK, AIPlayer.DEF, AIPlayer.CON, AIPlayer.STR, AIPlayer.DEX, AIPlayer.INTEL, AIPlayer.WIS, AIPlayer.WeaponName);

            // WEAPON CHOICE DIALOG
            Console.WriteLine("CHOOSE YOUR WEAPON: ");
            Console.WriteLine("");
            showWeapons();
            Console.WriteLine("");
            Console.Write("CHOICE: ");
            choice = Console.ReadLine();
            int.TryParse(choice, out choice2);

            if (choice2 < 1 && choice2 > 5)
            {
                while (choice2 < 1 && choice2 > 5)
                {
                    // WEAPON CHOICE DIALOG
                    Console.WriteLine(invalid);
                    Console.WriteLine("");
                    Console.WriteLine("CHOOSE YOUR WEAPON: ");
                    Console.WriteLine("");
                    showWeapons();
                    Console.WriteLine("");
                    Console.Write("CHOICE: ");
                    choice = Console.ReadLine();
                    int.TryParse(choice, out choice2);
                }
            }
            else if (choice2 >= 1 && choice2 <= 5 )
            {
                if (choice2 == 1)
                {
                    Player1.WeaponName = Fists.Name;
                    Player1.WeaponDMG = Fists.Dmg;
                    Player1.AtkCost = Fists.AtkCost;
                }
                else if (choice2 == 2)
                {
                    Player1.WeaponName = Knife.Name;
                    Player1.WeaponDMG = Knife.Dmg;
                    Player1.AtkCost = Knife.AtkCost;
                }
                else if (choice2 == 3)
                {
                    Player1.WeaponName = Sword.Name;
                    Player1.WeaponDMG = Sword.Dmg;
                    Player1.AtkCost = Sword.AtkCost;
                }
                else if (choice2 == 4)
                {
                    Player1.WeaponName= Axe.Name;
                    Player1.WeaponDMG= Axe.Dmg;
                    Player1.AtkCost = Axe.AtkCost;
                }
                else if (choice2 == 5)
                {
                    Player1.WeaponName = Warhammer.Name;
                    Player1.WeaponDMG = Warhammer.Dmg;
                    Player1.AtkCost = Warhammer.AtkCost;
                }
            }
            Console.WriteLine("YOU'VE EQUIPPED YOUR " + Player1.WeaponName);
            Console.WriteLine("");

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
                        while (Player1.Init == AIPlayer.Init)
                        {
                            Console.WriteLine("INITIATIVE ROLL DRAW! RE-ROLLING INITIATIVE... ");
                            Console.WriteLine(" ");
                            Player1.Init = diceRoll(1, 20);
                            Console.WriteLine("--- " + Player1.Name + " rolled " + Player1.Init);
                            AIPlayer.Init = diceRoll(1, 20);
                            Console.WriteLine("--- " + AIPlayer.Name + " rolled " + AIPlayer.Init);
                            Console.WriteLine(" ");
                        }
                    }

                    // -------------------------------- [ IF PLAYER WINS INIT ROLL ] -----------------------------------------------------------------------------------------

                    if (Player1.Init > AIPlayer.Init)
                    {
                        Player1.HP = Player1.MaxHP; // ENSURES THAT PLAYER HP BEGINS AT FULL
                        AIPlayer.HP = AIPlayer.MaxHP; // ENSURES THAT AI HP BEGINS AT FULL
                        Player1.AP = Player1.MaxAP; // ENSURES THAT PLAYER AP BEGINS AT FULL
                        AIPlayer.AP = AIPlayer.MaxAP; // ENSURES THAT AI AP BEGINS AT FULL
                        origPlayerDef = Player1.DEF; // HOLDS PLAYER ORIGINAL DEF VALUE
                        origAIDef = AIPlayer.DEF; // HOLDS AI ORIGINAL DEF VALUE

                        Console.WriteLine(Player1.Name + " GOES FIRST... ");
                        Console.WriteLine(" ");

                        // THIS LOOP CONTAINS PLAYER AND AI TURNS
                        while (Player1.Alive == true && AIPlayer.Alive == true)
                        {
                            // -------------------------------- [ PLAYER TURN START ]

                            // CHECKS PLAYER ALIVE STATUS AT THE BEGINNING OF EACH TURN
                            Player1.Alive = isAlive(Player1.HP);
                            if (Player1.Alive == false)
                            {
                                break;
                            }

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            // DETERMINES atkCost BASED ON THE EQUIPPED WEAPON
                            atkCost = getAtkCost(Player1.AtkCost);

                            // IF AP IS NOT FULL, REGENS PER TURN
                            Player1.AP = apRegen(Player1.AP, Player1.MaxAP, Player1.DEX, Player1.INTEL);

                            Player1.DEF = origPlayerDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE PLAYER HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT TURTLING.
                            AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS AI STATUS AT BEGINNING OF EACH TURN
                            Console.WriteLine("---------- " + Player1.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                            Console.WriteLine(AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT
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
                                        if (Player1.AP >= atkCost)
                                        {
                                            if (atkCount < 1)
                                            {
                                                // HIT ROLL
                                                Console.WriteLine("YOU ROLL FOR HIT...");
                                                hitRoll = rollHit();
                                                Console.WriteLine("--- " + Player1.Name + " ROLLED " + hitRoll);

                                                // IF SUCCESSFUL
                                                if (hitRoll >= AIPlayer.DEF)
                                                {
                                                    getWeaponDamage(Player1.MinDMG, Player1.MaxDMG);
                                                    damage = getDamage(Player1.ATK, Player1.WeaponDMG, AIPlayer.DEF);
                                                    AIPlayer.HP = AIPlayer.HP - damage;
                                                    Console.WriteLine("--- " + Player1.Name + " HITS " + AIPlayer.Name + " FOR " + damage + " DAMAGE!");
                                                    AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS TARGET STATUS
                                                    Console.WriteLine("--- " + AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT

                                                    Console.WriteLine(" ");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("--- " + "YOUR ATTACK MISSES!");
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
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("INSUFFICIENT ACTION POINTS!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP);
                                            Console.WriteLine("REMAINING AP: " + Player1.AP);

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
                                        if (Player1.AP >= defCost)
                                        {
                                            Player1.DEF = Player1.DEF + useDefend(Player1.DEF);
                                            Console.WriteLine("--- " + "YOU RAISE YOUR SHIELD, PREPARING FOR " + AIPlayer.Name + "'s NEXT ATTACK!");
                                            Console.WriteLine("--- DEFENSE INCREASES BY: " + (Player1.DEF - origPlayerDef));
                                            Console.WriteLine("--- " + Player1.Name + "'s DEFENSE: " + Player1.DEF);
                                            Console.WriteLine(" ");
                                            Player1.AP = Player1.AP - defCost;
                                            choice = "e";
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("INSUFFICIENT ACTION POINTS!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP);
                                            Console.WriteLine("REMAINING AP: " + Player1.AP);

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
                                    // IF PLAYER CHOOSES TO HEAL
                                    else if (choice == "h")
                                    {
                                        if (Player1.AP >= healCost)
                                        {
                                            if (Player1.Pots > 0)
                                            {
                                                if (healCount < 1)
                                                {
                                                    healAmount = usePotion(Player1.HP, Player1.MaxHP);
                                                    Player1.HP = Player1.HP + healAmount;
                                                    if (Player1.HP > Player1.MaxHP)
                                                    {
                                                        Player1.HP = Player1.MaxHP;
                                                    }
                                                    Player1.Pots = Player1.Pots - 1;
                                                    Console.WriteLine("--- " + "YOU DRINK A POTION FROM YOUR BELT, HEALING " + healAmount + " HP!");
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
                                                Console.WriteLine("YOU REACH FOR A POTION, BUT FIND YOUR BELT EMPTY!");
                                                Player1.AP = Player1.AP - (healCost / 2);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(invalid);
                                    }

                                    // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                    AIPlayer.Alive = isAlive(AIPlayer.HP);
                                    AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP);
                                    if (AIPlayer.Alive == false)
                                    {
                                        break;
                                    }

                                    // DISPLAYS PLAYER AND AI REMAINING HP
                                    Console.WriteLine("----------");
                                    showStat(Player1.Name, "HP", Player1.HP);
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

                            // CHECKS AI ALIVE STATUS AT THE BEGINNING OF EACH TURN
                            AIPlayer.Alive = isAlive(AIPlayer.HP);
                            if (AIPlayer.Alive == false)
                            {
                                break;
                            }

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            // DETERMINES atkCost BASED ON THE EQUIPPED WEAPON
                            atkCost = getAtkCost(AIPlayer.AtkCost);

                            // IF AP IS NOT FULL, REGENS PER TURN
                            AIPlayer.AP = apRegen(AIPlayer.AP, AIPlayer.MaxAP, AIPlayer.DEX, AIPlayer.INTEL);

                            AIPlayer.DEF = origAIDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE AI HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT TURTLING.

                            Console.WriteLine("---------- " + AIPlayer.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS AI STATUS AT BEGINNING OF EACH TURN

                            while (AIPlayer.AP >= defCost)
                            {
                                // DETERMINES AI CHOICE
                                aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, atkCount, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots, healCount,
                                Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP, atkCost, defCost, healCost);

                                // IF AI CHOOSES TO ATTACK
                                if (aiTurn == "a")
                                {
                                    if (atkCount < 1)
                                    {
                                        // HIT ROLL
                                        Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                        hitRoll = rollHit();
                                        Console.WriteLine("--- " + AIPlayer.Name + " ROLLED " + hitRoll);

                                        // IF SUCCESSFUL
                                        if (hitRoll >= Player1.DEF)
                                        {
                                            damage = getDamage(AIPlayer.ATK, AIPlayer.WeaponDMG, Player1.DEF);
                                            Player1.HP = Player1.HP - damage;
                                            Console.WriteLine("--- " + AIPlayer.Name + " HITS " + Player1.Name + " FOR " + damage + " DAMAGE WITH THEIR " + AIPlayer.WeaponName + "!");
                                            Console.WriteLine(" ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("--- " + AIPlayer.Name + "'s ATTACK MISSES!");
                                            Console.WriteLine(" ");
                                        }
                                        // CALCULATES REMAINING AP
                                        AIPlayer.AP = AIPlayer.AP - atkCost;
                                        atkCount++;
                                    }
                                    else if (atkCount > 0)
                                    {
                                        aiTurn = "d";
                                        break;
                                    }
                                }
                                // IF AI CHOOSES TO DEFEND
                                else if (aiTurn == "d")
                                {
                                    AIPlayer.DEF = AIPlayer.DEF + useDefend(AIPlayer.DEF);
                                    Console.WriteLine("--- " + AIPlayer.Name + " RAISES THEIR SHIELD, PREPARING FOR " + Player1.Name + "'s NEXT ATTACK!");
                                    Console.WriteLine("--- DEFENSE INCREASES BY: " + (AIPlayer.DEF - origAIDef));
                                    Console.WriteLine("--- " + AIPlayer.Name + " DEFENSE: " + AIPlayer.DEF);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - defCost;
                                    aiTurn = "e";
                                    break;
                                }
                                // IF AI CHOOSES TO HEAL
                                else if (aiTurn == "h")
                                {
                                    if (AIPlayer.Pots > 0)
                                    {
                                        healAmount = usePotion(AIPlayer.HP, AIPlayer.MaxHP);
                                        AIPlayer.HP = AIPlayer.HP + healAmount;
                                        if (AIPlayer.HP > AIPlayer.MaxHP)
                                        {
                                            AIPlayer.HP = AIPlayer.MaxHP;
                                        }
                                        AIPlayer.Pots = AIPlayer.Pots - 1;
                                        Console.WriteLine("--- " + AIPlayer.Name + " DRINKS A POTION FROM THEIR BELT!");
                                        Console.WriteLine("--- REMAINING POTIONS: " + AIPlayer.Pots);
                                        AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS TARGET STATUS
                                        Console.WriteLine("--- " + AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT
                                        Console.WriteLine(" ");
                                        AIPlayer.AP = AIPlayer.AP - healCost;
                                        healCount++;
                                    }
                                    else
                                    {
                                        aiTurn = "d";
                                        break;
                                    }
                                }

                                // CHECKS TARGET ALIVE STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                Player1.Alive = isAlive(Player1.HP);
                                if (Player1.Alive == false)
                                {
                                    break;
                                }

                                
                            }
                            // DISPLAYS PLAYER AND AI REMAINING HP
                            Console.WriteLine("----------");
                            showStat(Player1.Name, "HP", Player1.HP);
                            Console.WriteLine("----------");
                            Console.WriteLine(" ");
                        }
                        Console.WriteLine(AIPlayer.Name + "'s TURN ENDS...");
                        Console.WriteLine(" ");

                        // SHOULD TRIGGER AFTER EITHER AI OR PLAYER HP REACHES 0
                        AIPlayer.Alive = isAlive(AIPlayer.HP);
                        Player1.Alive = isAlive(Player1.HP);
                        if (AIPlayer.Alive == false)
                        {
                            Player1.Score++;
                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                        }
                        else
                        {
                            AIPlayer.Score++;
                            Console.WriteLine(AIPlayer.Name + " wins!");
                        }
                    }
                    // -------------------------------- [ IF AI WINS INIT ROLL ] -----------------------------------------------------------------------------------------

                    else if (AIPlayer.Init > Player1.Init)
                    {
                        Player1.HP = Player1.MaxHP; // ENSURES THAT PLAYER HP BEGINS AT FULL
                        AIPlayer.HP = AIPlayer.MaxHP; // ENSURES THAT AI HP BEGINS AT FULL
                        Player1.AP = Player1.MaxAP; // ENSURES THAT PLAYER AP BEGINS AT FULL
                        AIPlayer.AP = AIPlayer.MaxAP; // ENSURES THAT AI AP BEGINS AT FULL
                        origPlayerDef = Player1.DEF; // HOLDS PLAYER ORIGINAL DEF VALUE
                        origAIDef = AIPlayer.DEF; // HOLDS AI ORIGINAL DEF VALUE

                        Console.WriteLine(AIPlayer.Name + " GOES FIRST... ");
                        Console.WriteLine(" ");

                        while (Player1.Alive == true && AIPlayer.Alive == true)
                        {
                            // -------------------------------- [ AI TURN START ]

                            // CHECKS AI ALIVE STATUS AT THE BEGINNING OF EACH TURN
                            AIPlayer.Alive = isAlive(AIPlayer.HP);
                            if (AIPlayer.Alive == false)
                            {
                                break;
                            }

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            // DETERMINES atkCost BASED ON THE EQUIPPED WEAPON
                            atkCost = getAtkCost(AIPlayer.AtkCost);

                            // IF AP IS NOT FULL, REGENS PER TURN
                            AIPlayer.AP = apRegen(AIPlayer.AP, AIPlayer.MaxAP, AIPlayer.DEX, AIPlayer.INTEL);

                            AIPlayer.DEF = origAIDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE AI HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT TURTLING.

                            Console.WriteLine("---------- " + AIPlayer.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS AI STATUS AT BEGINNING OF EACH TURN

                            while (AIPlayer.AP >= defCost)
                            {
                                // DETERMINES AI CHOICE
                                aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, atkCount, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots, healCount,
                                Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP, atkCost, defCost, healCost);

                                // IF AI CHOOSES TO ATTACK
                                if (aiTurn == "a")
                                {
                                    if (atkCount < 1)
                                    {
                                        // HIT ROLL
                                        Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                        hitRoll = rollHit();
                                        Console.WriteLine("--- " + AIPlayer.Name + " ROLLED " + hitRoll);

                                        // IF SUCCESSFUL
                                        if (hitRoll >= Player1.DEF)
                                        {
                                            damage = getDamage(AIPlayer.ATK, AIPlayer.WeaponDMG, Player1.DEF);
                                            Player1.HP = Player1.HP - damage;
                                            Console.WriteLine("--- " + AIPlayer.Name + " HITS " + Player1.Name + " FOR " + damage + " DAMAGE WITH THEIR " + AIPlayer.WeaponName + "!");
                                            Console.WriteLine(" ");
                                        }
                                        else
                                        {
                                            Console.WriteLine("--- " + AIPlayer.Name + "'s ATTACK MISSES!");
                                            Console.WriteLine(" ");
                                        }
                                        // CALCULATES REMAINING AP
                                        AIPlayer.AP = AIPlayer.AP - atkCost;
                                        atkCount++;
                                    }
                                    else if (atkCount > 0)
                                    {
                                        aiTurn = "d";
                                        break;
                                    }
                                }
                                // IF AI CHOOSES TO DEFEND
                                else if (aiTurn == "d")
                                {
                                    AIPlayer.DEF = AIPlayer.DEF + useDefend(AIPlayer.DEF);
                                    Console.WriteLine("--- " + AIPlayer.Name + " RAISES THEIR SHIELD, PREPARING FOR " + Player1.Name + "'s NEXT ATTACK!");
                                    Console.WriteLine("--- DEFENSE INCREASES BY: " + (AIPlayer.DEF - origAIDef));
                                    Console.WriteLine("--- " + AIPlayer.Name + " DEFENSE: " + AIPlayer.DEF);
                                    Console.WriteLine(" ");
                                    AIPlayer.AP = AIPlayer.AP - defCost;
                                    aiTurn = "e";
                                    break;
                                }
                                // IF AI CHOOSES TO HEAL
                                else if (aiTurn == "h")
                                {
                                    if (AIPlayer.Pots > 0)
                                    {
                                        healAmount = usePotion(AIPlayer.HP, AIPlayer.MaxHP);
                                        AIPlayer.HP = AIPlayer.HP + healAmount;
                                        if (AIPlayer.HP > AIPlayer.MaxHP)
                                        {
                                            AIPlayer.HP = AIPlayer.MaxHP;
                                        }
                                        AIPlayer.Pots = AIPlayer.Pots - 1;
                                        Console.WriteLine("--- " + AIPlayer.Name + " DRINKS A POTION FROM THEIR BELT!");
                                        Console.WriteLine("--- REMAINING POTIONS: " + AIPlayer.Pots);
                                        AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS TARGET STATUS
                                        Console.WriteLine("--- " + AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT
                                        Console.WriteLine(" ");
                                        AIPlayer.AP = AIPlayer.AP - healCost;
                                        healCount++;
                                    }
                                    else
                                    {
                                        aiTurn = "d";
                                        break;
                                    }
                                }

                                // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                Player1.Alive = isAlive(Player1.HP);
                                if (Player1.Alive == false)
                                {
                                    break;
                                }


                            }
                            // DISPLAYS PLAYER AND AI REMAINING HP
                            Console.WriteLine("----------");
                            showStat(Player1.Name, "HP", Player1.HP);
                            Console.WriteLine("----------");
                            Console.WriteLine(" ");
                            Console.WriteLine(AIPlayer.Name + "'s TURN ENDS...");
                            Console.WriteLine(" ");

                            // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                            Player1.Alive = isAlive(Player1.HP);
                            if (Player1.Alive == false)
                            {
                                break;
                            }

                            // -------------------------------- [ PLAYER TURN START ]

                            // CHECKS PLAYER ALIVE STATUS AT THE BEGINNING OF EACH TURN
                            Player1.Alive = isAlive(Player1.HP);
                            if (Player1.Alive == false)
                            {
                                break;
                            }

                            // RESETS ATK AND HEAL COUNTER AT THE BEGINNING OF EACH TURN
                            atkCount = 0;
                            healCount = 0;

                            // DETERMINES atkCost BASED ON THE EQUIPPED WEAPON
                            atkCost = getAtkCost(Player1.AtkCost);

                            // IF AP IS NOT FULL, REGENS PER TURN
                            Player1.AP = apRegen(Player1.AP, Player1.MaxAP, Player1.DEX, Player1.INTEL);

                            Player1.DEF = origPlayerDef; // RESETS DEF AT THE BEGINNING OF EACH TURN IN CASE PLAYER HAS PREVIOUSLY DEFENDED. THIS SHOULD ALSO PREVENT TURTLING.
                            AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS AI STATUS AT BEGINNING OF EACH TURN
                            Console.WriteLine("---------- " + Player1.Name + "'s TURN ----------");
                            Console.WriteLine(" ");
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + Player1.Name + " AP: " + Player1.AP);
                            Console.WriteLine(AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT
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
                                        if (Player1.AP >= atkCost)
                                        {
                                            if (atkCount < 1)
                                            {
                                                // HIT ROLL
                                                Console.WriteLine("YOU ROLL FOR HIT...");
                                                hitRoll = rollHit();
                                                Console.WriteLine("--- " + Player1.Name + " ROLLED " + hitRoll);

                                                // IF SUCCESSFUL
                                                if (hitRoll >= AIPlayer.DEF)
                                                {
                                                    getWeaponDamage(Player1.MinDMG, Player1.MaxDMG);
                                                    damage = getDamage(Player1.ATK, Player1.WeaponDMG, AIPlayer.DEF);
                                                    AIPlayer.HP = AIPlayer.HP - damage;
                                                    Console.WriteLine("--- " + Player1.Name + " HITS " + AIPlayer.Name + " FOR " + damage + " DAMAGE!");
                                                    AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP); // CHECKS TARGET STATUS
                                                    Console.WriteLine("--- " + AIPlayer.Name + AIPlayer.Status); // STATUS OUTPUT

                                                    Console.WriteLine(" ");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("--- " + "YOUR ATTACK MISSES!");
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
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("INSUFFICIENT ACTION POINTS!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP);
                                            Console.WriteLine("REMAINING AP: " + Player1.AP);

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
                                        if (Player1.AP >= defCost)
                                        {
                                            Player1.DEF = Player1.DEF + useDefend(Player1.DEF);
                                            Console.WriteLine("--- " + "YOU RAISE YOUR SHIELD, PREPARING FOR " + AIPlayer.Name + "'s NEXT ATTACK!");
                                            Console.WriteLine("--- DEFENSE INCREASES BY: " + (Player1.DEF - origPlayerDef));
                                            Console.WriteLine("--- " + Player1.Name + "'s DEFENSE: " + Player1.DEF);
                                            Console.WriteLine(" ");
                                            Player1.AP = Player1.AP - defCost;
                                            choice = "e";
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("INSUFFICIENT ACTION POINTS!");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP);
                                            Console.WriteLine("REMAINING AP: " + Player1.AP);

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
                                    // IF PLAYER CHOOSES TO HEAL
                                    else if (choice == "h")
                                    {
                                        if (Player1.AP >= healCost)
                                        {
                                            if (Player1.Pots > 0)
                                            {
                                                if (healCount < 1)
                                                {
                                                    healAmount = usePotion(Player1.HP, Player1.MaxHP);
                                                    Player1.HP = Player1.HP + healAmount;
                                                    if (Player1.HP > Player1.MaxHP)
                                                    {
                                                        Player1.HP = Player1.MaxHP;
                                                    }
                                                    Player1.Pots = Player1.Pots - 1;
                                                    Console.WriteLine("--- " + "YOU DRINK A POTION FROM YOUR BELT, HEALING " + healAmount + " HP!");
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
                                                Console.WriteLine("YOU REACH FOR A POTION, BUT FIND YOUR BELT EMPTY!");
                                                Player1.AP = Player1.AP - (healCost / 2);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(invalid);
                                    }

                                    // CHECKS TARGET STATUS AND EXITS LOOP IF TARGET IS NO LONGER ALIVE
                                    AIPlayer.Alive = isAlive(AIPlayer.HP);
                                    AIPlayer.Status = getStatus(AIPlayer.HP, AIPlayer.MaxHP);
                                    if (AIPlayer.Alive == false)
                                    {
                                        break;
                                    }

                                    // DISPLAYS PLAYER AND AI REMAINING HP
                                    Console.WriteLine("----------");
                                    showStat(Player1.Name, "HP", Player1.HP);
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
                            Player1.Score++;
                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                        }
                        else if (Player1.Alive == false && AIPlayer.Alive == true)
                        {
                            AIPlayer.Score++;
                            Console.WriteLine("YOU LOSE!");
                            Console.WriteLine("");
                        }
                    }
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(Player1.Name + " SCORE: " + Player1.Score + "\t"+ AIPlayer.Name + " SCORE: " + AIPlayer.Score);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("");
                    Console.Write("PLAY AGAIN? YES (Y) OR NO (N)? ");
                    choice = Console.ReadLine();
                    choice = choice.Trim();
                    foreach (char c in choice)
                    {
                        char.ToLower(c);
                    }
                    if (choice == "n")
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

            static void showLogo()
            {
                string logo =
                "                                     ____                               \n" +
                "|``````.         |         |        |                   |               \n" +
                "|       |        |         |        |______             |               \n" +
                "|       |        |         |        |                   |               \n" +
                "|......'         `._______.'        |___________        |_______        \n" +
                "                                                                        \n" +
                "                             (C) Blaqkstar 2022. All Rights Reserved\n\n";

                Console.WriteLine(logo);
            }

            static void showWelcomeMsg()
            {
                string msg =
                "Hello there! Thanks for checking out DUEL! This is a simple project that I am using to learn more about coding while\n" +
                "on winter break from my software engineering degree. Updates and bug fixes will go out as I can get them done,\n" +
                "but since the DUEL dev team is just me, I wouldn't expect them to be all that regular. I hope you enjoy the game!\n\n" +
                "o7\n\n" +
                "Regards,\n" +
                "Blaqkstar\n\n\n";

                Console.WriteLine(msg);
            }

            static void showStats(string targetName, int hp, int mp, int ap, int atk, int def, int con, int str, int dex, int intel, int wis, string weapon)
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
                Console.WriteLine(" ");
                Console.WriteLine("WEAPON: " + weapon);
                Console.WriteLine("-----------------------");
                Console.WriteLine(" ");
            }

            void showWeapons()
            {
                int minDmg = 0;
                int maxDmg = 0;
                int atkCost = 0;


                Console.WriteLine("FISTS (1)\tKNIFE (2)\tSWORD (3)\tAXE (4)\t\tWARHAMMER (5)");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("MIN DMG: " + Fists.MinDmg + "\tMIN DMG: " + Knife.MinDmg + "\tMIN DMG: " + Sword.MinDmg + "\tMIN DMG: " + Axe.MinDmg + "\tMIN DMG: " + Warhammer.MinDmg);
                Console.WriteLine("MAX DMG: " + Fists.MaxDmg + "\tMAX DMG: " + Knife.MaxDmg + "\tMAX DMG: " + Sword.MaxDmg + "\tMAX DMG: " + Axe.MaxDmg + "\tMAX DMG: " + Warhammer.MaxDmg);
                Console.WriteLine("ATK COST: " + Fists.AtkCost + "\tATK COST: " + Knife.AtkCost + "\tATK COST: " + Sword.AtkCost + "\tATK COST: " + Axe.AtkCost + "\tATK COST: " + Warhammer.AtkCost);
                Console.WriteLine(" ");
            }

            static int getDamage(int atk, int weaponDmg, int targetDef)
            {
                int damage = diceRoll(2, 6) + (weaponDmg + atk / 3);
                int totalDmg = damage - (targetDef / 5);
                return totalDmg;
            }

            int getWeaponDamage(int minDmg, int maxDmg)
            {
                int damage = 0;
                Random rand = new Random();
                damage = rand.Next(minDmg, maxDmg);

                return damage;
            }

            int getAtkCost(int weaponAtkCost)
            {
                int atkCost = weaponAtkCost;

                return atkCost;
            }

            static int getEnemyWeapon()
            {
                int weapon = diceRoll(1, 5);
                
                return weapon;
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

            static int apRegen(int ap, int maxAP, int dex, int intel)
            {
                int regen = (dex / 5) + (intel / 5) + diceRoll(1, 6);
                
                if (ap < maxAP)
                {
                    ap = ap + regen;
                }
                if (ap > maxAP)
                {
                    ap = maxAP;
                }

                return ap;
            }

            static string getStatus(int hp, int maxHP)
            {
                string status = "UNDEFINED";
                string healthy = " IS FRESH AND ENERGIZED. THEY ARE READY TO FIGHT.";
                string slightlyHurt = " IS A LITTLE BRUISED.";
                string hurt = " IS BLEEDING FROM THEIR WOUNDS AND EXTREMELY ANGRY.";
                string faltering = " IS BLEEDING HEAVILY AND LIMPING.";
                string lastBreath = " IS FADING QUICKLY. STRIKE NOW!";
                string dead = " IS DEAD.";

                // ASSIGNS A STATUS BASED ON REMAINING HP
                if (hp == maxHP)
                {
                    status = healthy;
                }
                else if (hp < maxHP && hp >= (maxHP * 0.75))
                {
                    status = slightlyHurt;
                }
                else if (hp < (maxHP * 0.75) && hp >= (maxHP * 0.50))
                {
                    status = hurt;
                }
                else if (hp < (maxHP * 0.50) && hp >= (maxHP * 0.05))
                {
                    status = faltering;
                }
                else if (hp < (maxHP * 0.05) && hp > 0)
                {
                    status = lastBreath;
                }
                else if (hp <= 0)
                {
                    status = dead;
                }

                return status;
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

            /*static int useAttack(int minDmg, int maxDmg, int targetHP, int targetDef)
            {
                int atk = getWeaponDamage()
                targetHP = (targetHP + targetDef) - atk;
                return targetHP;
            }*/

            static int useDefend(int def)
            {
                int buff = def / 3;
                return buff;
            }

            static int usePotion(int hp, int maxHP)
            {
                int pot = maxHP / 3;
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

            


            // ===================================================>>> AI BEHAVIORAL ALGORITHM STARTS HERE
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
                                if (aiATKCount < 1 && aiAP >= atkCost)
                                {
                                    atkWeight++;
                                }
                                // IF AI HAS ALREADY ATTACKED
                                else if (aiATKCount > 0 || aiAP < atkCost)
                                {
                                    // AI HAS NOT YET HEALED
                                    if (aiHealCount < 1 && aiPots > 0)
                                    {
                                        healWeight++;
                                    }
                                    // IF AI HAS ALREADY HEALED
                                    else if (aiHealCount > 0 || aiPots < 1)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                            // FAVORS HEALING IF AI ATK IS LESS THAN OR EQUIVALENT TO PLAYER DEF
                            else if (aiATK <= playerDEF)
                            {
                                // IF AI HAS NOT YET HEALED
                                if (aiHealCount < 1 && aiPots > 0)
                                {
                                    healWeight++;
                                }
                                // IF AI HAS ALREADY HEALED
                                else if (aiHealCount > 0 || aiPots < 1)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1 && aiAP >= atkCost)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0 || aiAP < atkCost)
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
                            if (aiHealCount < 1 && aiPots > 0)
                            {
                                healWeight++;
                            }
                            // IF AI HAS ALREADY HEALED
                            else if (aiHealCount > 0 || aiPots < 1)
                            {
                                // IF AI CAN ATTACK
                                if (aiATKCount < 1 && aiAP >= atkCost)
                                {
                                    atkWeight++;
                                }
                                // IF AI CANNOT ATTACK
                                else if (aiATKCount > 0 || aiAP < atkCost)
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
                            if (aiHealCount < 1 && aiPots > 0)
                            {
                                healWeight++;
                            }
                            // IF AI CANNOT HEAL
                            else if (aiHealCount > 0 || aiPots < 1)
                            {
                                // FAVORS OFFENSE IF AI DEF IS GREATER THAN PLAYER ATK
                                if (aiDEF > playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1 && aiAP >= atkCost)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0 || aiAP < atkCost)
                                    {
                                        defWeight++;
                                    }
                                }
                                // FAVORS OFFENSE IF AI DEF IS LESS THAN PLAYER ATK
                                else if (aiDEF <= playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1 && aiAP >= atkCost)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0 || aiAP < atkCost)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                        }
                        // FAVORS HEALING IF AI HP IS LESS THAN HALF OF PLAYER HP
                        else if (aiHP < (playerHP / 2))
                        {
                            // IF AI CAN HEAL
                            if (aiHealCount < 1 && aiAP >= atkCost)
                            {
                                healWeight++;
                            }
                            // IF AI CANNOT HEAL
                            else if (aiHealCount > 0 || aiAP < atkCost)
                            {
                                // IF AI DEF IS GREATER THAN PLAYER ATK
                                if (aiDEF > playerATK)
                                {
                                    // IF AI CAN ATTACK
                                    if (aiATKCount < 1 && aiAP >= atkCost)
                                    {
                                        atkWeight++;
                                    }
                                    // IF AI CANNOT ATTACK
                                    else if (aiATKCount > 0 || aiAP < atkCost)
                                    {
                                        defWeight++;
                                    }
                                }
                            }
                        }
                    }
                    // IF AI HP IS BETWEEN 50% AND 100%
                    if (aiHP >= (aiMaxHP / 2) && aiHP < aiMaxHP)
                    {
                        // IF AI CAN ATTACK
                        if (aiATKCount < 1 && aiAP >= atkCost)
                        {
                            atkWeight++;
                        }
                        // IF AI CANNOT ATTACK
                        else if (aiATKCount > 0 || aiAP < atkCost)
                        {
                            defWeight++;
                        }
                    }
                    // FAVORS OFFENSE IF AI IS AT FULL HP
                    if (aiAP == aiMaxHP)
                    {
                        // IF AI CAN ATTACK
                        if (aiATKCount < 1 && aiAP >= atkCost)
                        {
                            atkWeight++;
                        }
                        // IF AI CANNOT ATTACK
                        else if (aiATKCount > 0 || aiAP < atkCost)
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