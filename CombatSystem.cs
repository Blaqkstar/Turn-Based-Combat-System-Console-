using Combat_System;

namespace CombatSystem
{
    internal class CombatSystem
    {
        static void Main(string[] args)
        {
            // ability AP cost
            int atkCost = 3;
            int defCost = 3;
            int healCost = 5;

            // error message
            string invalid = "Invalid entry.";

            // hit marker
            int hitRoll = 0;

            // initializes player stats
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
            int con = 0;
            int str = 0;
            int dex = 0;
            int intel = 0;
            int pots = 2;
            int wis = 0;

            // initializes AIPlayer stats
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
            int ai_con = 0;
            int ai_str = 0;
            int ai_dex = 0;
            int ai_intel = 0;
            int ai_wis = 0;
            int ai_pots = 2;

            // creates Player1 obj
            Player Player1 = new Player();
            Console.Write("ENTER YOUR NAME: ");
            string userName = Console.ReadLine();
            Player1.Name = userName;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Greetings, " + Player1.Name + "!");
            Console.WriteLine(" ");
            Console.WriteLine("GENERATING CHARACTER STATS...");
            Console.WriteLine(" ");

            // sets Player1 stats
            con = getStats(2, 6);
            Player1.CON = con;
            //Thread.Sleep(120);
            str = getStats(2, 6);
            Player1.STR = str;
            //Thread.Sleep(120);
            dex = getStats(2, 6);
            Player1.DEX = dex;
            //Thread.Sleep(120);
            intel = getStats(2, 6);
            Player1.INTEL = intel;
            //Thread.Sleep(120);
            wis = getStats(2, 6);
            Player1.WIS = wis;
            //Thread.Sleep(120);

            // calculates Player1 attributes
            Player1.MaxHP = calcAttribute(con, 2);
            Player1.MaxMP = calcAttribute(intel, 2);
            Player1.MaxAP = calcAttribute(dex, 2);
            Player1.HP = Player1.MaxHP;
            Player1.MP = Player1.MaxMP;
            Player1.AP = Player1.MaxAP;
            // displays Player1 attributes
            Console.WriteLine(Player1.Name + " STATS:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("HP: " + Player1.HP);
            Console.WriteLine("MP: " + Player1.MP);
            Console.WriteLine("AP: " + Player1.AP);
            Player1.ATK = calcAttribute(str, 3);
            Console.WriteLine("ATK: " + Player1.ATK);
            Player1.DEF = calcAC(con, dex, str);
            Console.WriteLine("DEF: " + Player1.DEF);
            Console.WriteLine(" ");
            Console.WriteLine("CON: " + con);
            Console.WriteLine("STR: " + str);
            Console.WriteLine("DEX: " + dex);
            Console.WriteLine("INT: " + intel);
            Console.WriteLine("WIS: " + wis);
            Console.WriteLine("-----------------------");
            Console.WriteLine(" ");
            // collects user input to re-roll or continue
            Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? ");
            string choice = "UNASSIGNED";
            choice = Console.ReadLine();
            // formats user choice
            choice = choice.Trim();
            foreach (char c in choice)
            {
                char.ToLower(c);
            }
            if (choice != "c")
            {
                while (choice != "c")
                {
                    if (choice == "r")
                    {
                        while (choice == "r")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("RE-ROLLING CHARACTER STATS");
                            Console.WriteLine(" ");
                            // sets Player1 stats
                            con = getStats(2, 6);
                            Player1.CON = con;
                            //Thread.Sleep(120);
                            str = getStats(2, 6);
                            Player1.STR = str;
                            //Thread.Sleep(120);
                            dex = getStats(2, 6);
                            Player1.DEX = dex;
                            //Thread.Sleep(120);
                            intel = getStats(2, 6);
                            Player1.INTEL = intel;
                            //Thread.Sleep(120);
                            wis = getStats(2, 6);
                            Player1.WIS = wis;
                            //Thread.Sleep(120);

                            // calculates Player1 attributes
                            Player1.MaxHP = calcAttribute(con, 2);
                            Player1.MaxMP = calcAttribute(intel, 2);
                            Player1.MaxAP = calcAttribute(dex, 2);
                            Player1.HP = Player1.MaxHP;
                            Player1.MP = Player1.MaxMP;
                            Player1.AP = Player1.MaxAP;

                            Console.WriteLine(Player1.Name + " STATS:");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("HP: " + Player1.HP);
                            Console.WriteLine("MP: " + Player1.MP);
                            Player1.AP = calcAttribute(dex, 2);
                            Console.WriteLine("AP: " + Player1.AP);
                            Player1.ATK = calcAttribute(str, 3);
                            Console.WriteLine("ATK: " + Player1.ATK);
                            Player1.DEF = calcAC(con, dex, str);
                            Console.WriteLine("DEF: " + Player1.DEF);
                            Console.WriteLine(" ");
                            Console.WriteLine("CON: " + con);
                            Console.WriteLine("STR: " + str);
                            Console.WriteLine("DEX: " + dex);
                            Console.WriteLine("INT: " + intel);
                            Console.WriteLine("WIS: " + wis);
                            Console.WriteLine("-----------------------");
                            Console.WriteLine(" ");
                            Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? ");
                            choice = Console.ReadLine();
                            choice = choice.Trim();
                            foreach (char c in choice)
                            {
                                char.ToLower(c);
                            }
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        Console.WriteLine(invalid);
                        Console.WriteLine(" ");
                        Console.Write("WOULD YOU LIKE TO CONTINUE (C) OR RE-ROLL (R)? ");
                        choice = Console.ReadLine();
                    }

                }

            }
            Console.WriteLine(" ");
            Console.WriteLine("GENERATING AI PLAYER...");
            Console.WriteLine(" ");

            // creates AIPlayer obj
            NPC AIPlayer = new NPC();
            string npcName = "Enemy";
            AIPlayer.Name = npcName;
            Console.WriteLine("SIMULATING DICE ROLLS FOR " + AIPlayer.Name + " STATS...");

            // sets AIPlayer stats
            ai_con = getStats(2, 10);
            AIPlayer.CON = ai_con;
            //Thread.Sleep(120);
            ai_str = getStats(2, 6);
            AIPlayer.STR = ai_str;
            //Thread.Sleep(120);
            ai_dex = getStats(2, 6);
            AIPlayer.DEX = ai_dex;
            //Thread.Sleep(120);
            ai_intel = getStats(2, 6);
            AIPlayer.INTEL = ai_intel;
            //Thread.Sleep(120);
            ai_wis = getStats(2, 6);
            AIPlayer.WIS = ai_wis;

            // calculates AIPlayer attributes
            AIPlayer.MaxHP = calcAttribute(ai_con, 2);
            AIPlayer.MaxMP = calcAttribute(ai_intel, 2);
            AIPlayer.MaxAP = calcAttribute(ai_dex, 2);
            AIPlayer.HP = AIPlayer.MaxHP;
            AIPlayer.MP = AIPlayer.MaxMP;
            AIPlayer.AP = AIPlayer.MaxAP;


            Console.WriteLine(AIPlayer.Name + " STATS:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("HP: " + AIPlayer.HP);
            Console.WriteLine("MP: " + AIPlayer.MP);
            Console.WriteLine("AP: " + AIPlayer.AP);
            AIPlayer.ATK = calcAttribute(ai_str, 3);
            Console.WriteLine("ATK: " + AIPlayer.ATK);
            AIPlayer.DEF = calcAC(ai_con, ai_dex, ai_str);
            Console.WriteLine("DEF: " + AIPlayer.DEF);
            Console.WriteLine(" ");
            Console.WriteLine("CON: " + ai_con);
            Console.WriteLine("STR: " + ai_str);
            Console.WriteLine("DEX: " + ai_dex);
            Console.WriteLine("INT: " + ai_intel);
            Console.WriteLine("WIS: " + ai_wis);
            Console.WriteLine("-----------------------");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            // COMBAT START DIALOG
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
            else
            {
                Player1.Alive = true;
                AIPlayer.Alive = true;
                Console.WriteLine("< < < BEGINNING COMBAT SEQUENCE > > >");
                Console.WriteLine(" ");
                Console.WriteLine("ROLLING INITIATIVE...");
                Player1.Init = diceRoll(1, 20);
                Console.WriteLine(Player1.Name + " rolled " + Player1.Init);
                AIPlayer.Init = diceRoll(1, 20);
                Console.WriteLine(AIPlayer.Name + " rolled " + AIPlayer.Init);
                Console.WriteLine(" ");

                // IF INIT ROLL ENDS IN DRAW
                if (Player1.Init == AIPlayer.Init)
                {
                    Console.WriteLine("INITIATIVE ROLL DRAW! RE-ROLLING INITIATIVE... ");
                    Console.WriteLine(" ");
                    Player1.Init = diceRoll(1, 20);
                    Console.WriteLine(Player1.Name + " rolled " + Player1.Init);
                    AIPlayer.Init = diceRoll(1, 20);
                    Console.WriteLine(AIPlayer.Name + " rolled " + AIPlayer.Init);
                    Console.WriteLine(" ");
                }

                // IF PLAYER WINS INIT ROLL
                if (Player1.Init > AIPlayer.Init)
                {
                    while (Player1.Alive == true && AIPlayer.Alive == true)
                    {
                        Console.WriteLine(Player1.Name + "'s TURN");
                        Console.WriteLine(" ");
                        Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                        Console.WriteLine(Player1.Name + " AP: " + Player1.AP);
                        Console.WriteLine(" ");
                        Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                        choice = Console.ReadLine();
                        choice = choice.Trim();
                        foreach (char c in choice)
                        {
                            char.ToLower(c);
                        }
                        while (choice != "e")
                        {
                            while (Player1.AP > 0)
                            {
                                // IF PLAYER CHOOSES TO ATTACK
                                if (choice == "a")
                                {
                                    // roll for hit
                                    Console.WriteLine(Player1.Name + " ROLLS FOR HIT...");
                                    hitRoll = rollHit();
                                    Console.WriteLine(Player1.Name + " ROLLED " + hitRoll);
                                    if (hitRoll >= AIPlayer.DEF)
                                    {
                                        AIPlayer.HP = AIPlayer.HP - Player1.ATK;
                                        Console.WriteLine(Player1.Name + " HITS " + AIPlayer.Name + " FOR " + Player1.ATK + " DAMAGE!");

                                        // checks target status
                                        AIPlayer.Alive = isAlive(AIPlayer.HP);
                                        if (AIPlayer.Alive = false)
                                        {
                                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Player1.Name + "'S ATTACK MISSES!");
                                    }
                                    // calculates remaining AP
                                    Player1.AP -= atkCost;
                                }
                                // IF PLAYER CHOOSES TO DEFEND
                                else if (choice == "d")
                                {
                                    useDefend(Player1.DEF);
                                    Player1.AP -= defCost;
                                }
                                // IF PLAYER CHOOSES TO HEAL
                                else if (choice == "h")
                                {
                                    usePotion(Player1.HP, Player1.MaxHP, Player1.Pots);
                                }
                                else
                                {
                                    Console.WriteLine(invalid);
                                }
                                // displays remaining AP and accepts user input for further actions, if possible
                                Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                                Console.WriteLine(" ");
                                Console.Write("YOU HAVE " + Player1.AP + " ACTION POINTS REMAINING. ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                                choice = Console.ReadLine();
                                choice = choice.Trim();
                                foreach (char c in choice)
                                {
                                    char.ToLower(c);
                                }
                            }
                        }
                        if (Player1.Alive == true && AIPlayer.Alive == false)
                        {
                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                        }
                        else if (Player1.Alive == false && AIPlayer.Alive == true)
                        {
                            Console.WriteLine("YOU LOSE!");
                        }

                        // AIPlayer turn
                        while (AIPlayer.AP > atkCost)
                        {
                            string aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots,
                            Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP);
                            if (aiTurn == "a")
                            {
                                // roll for hit
                                Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                hitRoll = rollHit();
                                Console.WriteLine(AIPlayer.Name + " ROLLED " + hitRoll);
                                if (hitRoll >= Player1.DEF)
                                {
                                    Player1.HP = Player1.HP - AIPlayer.ATK;
                                    Console.WriteLine(Player1.Name + " HITS " + AIPlayer.Name + " FOR " + Player1.ATK + " DAMAGE!");

                                    // checks target status
                                    Player1.Alive = isAlive(Player1.HP);
                                    if (Player1.Alive = false)
                                    {
                                        Console.WriteLine("YOU LOSE!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(AIPlayer.Name + "'S ATTACK MISSES!");
                                }
                                AIPlayer.AP = AIPlayer.AP - atkCost;
                            }
                            else if (choice == "d")
                            {
                                useDefend(AIPlayer.DEF);
                                AIPlayer.AP = AIPlayer.AP - defCost;
                            }
                            else if (choice == "h")
                            {
                                if (AIPlayer.Pots > 0)
                                {
                                    usePotion(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.Pots);
                                    AIPlayer.Pots--;
                                }
                                else
                                {
                                    Console.WriteLine(AIPlayer.Name + " REACHED FOR A POTION, BUT THEY WERE ALL OUT!");
                                }
                                AIPlayer.AP = AIPlayer.AP - healCost;
                            }
                            // displays remaining AP and accepts user input for further actions, if possible
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                            Console.WriteLine(Player1.Name + " AP: " + Player1.AP);
                        }

                    }
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
                // IF AI WINS INIT ROLL
                else if (AIPlayer.Init > AIPlayer.Init)
                {
                    if (Player1.Alive == true && AIPlayer.Alive == true)
                    {
                        // AIPlayer turn
                        while (AIPlayer.AP > atkCost)
                        {
                            string aiTurn = aiChoice(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.ATK, AIPlayer.DEF, AIPlayer.MP, AIPlayer.AP, AIPlayer.Pots,
                            Player1.HP, Player1.MaxHP, Player1.ATK, Player1.DEF, Player1.MP);
                            if (aiTurn == "a")
                            {
                                // roll for hit
                                Console.WriteLine(AIPlayer.Name + " ROLLS FOR HIT...");
                                hitRoll = rollHit();
                                Console.WriteLine(AIPlayer.Name + " ROLLED " + hitRoll);
                                if (hitRoll >= Player1.DEF)
                                {
                                    Player1.HP = Player1.HP - AIPlayer.ATK;
                                    Console.WriteLine(Player1.Name + " HITS " + AIPlayer.Name + " FOR " + Player1.ATK + " DAMAGE!");

                                    // checks target status
                                    Player1.Alive = isAlive(Player1.HP);
                                    if (Player1.Alive = false)
                                    {
                                        Console.WriteLine("YOU LOSE!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(AIPlayer.Name + "'S ATTACK MISSES!");
                                }
                                AIPlayer.AP = AIPlayer.AP - atkCost;
                            }
                            else if (choice == "d")
                            {
                                useDefend(AIPlayer.DEF);
                                AIPlayer.AP = AIPlayer.AP - defCost;
                            }
                            else if (choice == "h")
                            {
                                if (AIPlayer.Pots > 0)
                                {
                                    usePotion(AIPlayer.HP, AIPlayer.MaxHP, AIPlayer.Pots);
                                    AIPlayer.Pots--;
                                }
                                else
                                {
                                    Console.WriteLine(AIPlayer.Name + " REACHED FOR A POTION, BUT THEY WERE ALL OUT!");
                                }
                                AIPlayer.AP = AIPlayer.AP - healCost;
                            }
                            // displays remaining AP and accepts user input for further actions, if possible
                            Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                            Console.WriteLine(Player1.Name + " AP: " + Player1.AP);
                        }
                        Console.WriteLine(Player1.Name + "'s TURN");
                        Console.WriteLine(" ");
                        Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                        Console.WriteLine(Player1.Name + " AP: " + Player1.AP);
                        Console.WriteLine(" ");
                        Console.Write("ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                        choice = Console.ReadLine();
                        choice = choice.Trim();
                        foreach (char c in choice)
                        {
                            char.ToLower(c);
                        }
                        while (choice != "e")
                        {
                            while (Player1.AP > 0)
                            {
                                // IF PLAYER CHOOSES TO ATTACK
                                if (choice == "a")
                                {
                                    // roll for hit
                                    Console.WriteLine(Player1.Name + " ROLLS FOR HIT...");
                                    hitRoll = rollHit();
                                    Console.WriteLine(Player1.Name + " ROLLED " + hitRoll);
                                    if (hitRoll >= AIPlayer.DEF)
                                    {
                                        AIPlayer.HP = AIPlayer.HP - Player1.ATK;
                                        Console.WriteLine(Player1.Name + " HITS " + AIPlayer.Name + " FOR " + Player1.ATK + " DAMAGE!");

                                        // checks target status
                                        AIPlayer.Alive = isAlive(AIPlayer.HP);
                                        if (AIPlayer.Alive = false)
                                        {
                                            Console.WriteLine("Congratulations, " + Player1.Name + "! You win!");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Player1.Name + "'S ATTACK MISSES!");
                                    }
                                    // calculates remaining AP
                                    Player1.AP -= atkCost;
                                }
                                // IF PLAYER CHOOSES TO DEFEND
                                else if (choice == "d")
                                {
                                    useDefend(Player1.DEF);
                                    Player1.AP -= defCost;
                                }
                                // IF PLAYER CHOOSES TO HEAL
                                else if (choice == "h")
                                {
                                    usePotion(Player1.HP, Player1.MaxHP, Player1.Pots);
                                }
                                else
                                {
                                    Console.WriteLine(invalid);
                                }
                                // displays remaining AP and accepts user input for further actions, if possible
                                Console.WriteLine(Player1.Name + " HP: " + Player1.HP + "  |  " + AIPlayer.Name + " HP: " + AIPlayer.HP);
                                Console.WriteLine(" ");
                                Console.Write("YOU HAVE " + Player1.AP + " ACTION POINTS REMAINING. ATTACK (A), DEFEND (D), HEAL (H), OR END TURN (E)? ");
                                choice = Console.ReadLine();
                                choice = choice.Trim();
                                foreach (char c in choice)
                                {
                                    char.ToLower(c);
                                }
                            }
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



                }
            }

            // methods

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

            static int calcAttribute(int stat, int modifier)
            {
                int output = 0;
                int result = stat / modifier;
                output = result * 10;
                return output;
            }

            static int calcAC(int con, int dex, int str)
            {
                int ac = (con / 2) + (dex / 4) + (str / 4);
                return ac;
            }

            static string aiChoice(int aiHP, int aiMaxHP, int aiATK, int aiDEF, int aiMP, int aiAP, int aiPots,
                    int playerHP, int playerMaxHP, int playerATK, int playerDEF, int playerMP)
            {
                string choice = "UNDEFINED";

                if (aiAP > 0)
                {
                    if (aiHP <= (aiMaxHP / 4))
                    {
                        if (aiHP > playerHP)
                        {
                            choice = "a";
                        }
                        if (aiPots > 0)
                        {
                            choice = "h";
                        }
                        if (aiPots < 1)
                        {
                            choice = "d";
                        }
                    }
                    else if (aiHP > (aiMaxHP / 4) && aiHP < (aiMaxHP / 2))
                    {
                        if (aiPots > 0)
                        {
                            choice = "p";
                        }
                        else if (aiPots < 1)
                        {
                            choice = "d";
                        }
                        else choice = "a";
                    }
                    else if (aiHP > (aiMaxHP / 2) && aiHP <= aiMaxHP)
                    {
                        choice = "a";
                    }

                }
                else choice = "e";

                return choice;
            }

            static bool isAlive(int hp)
            {
                bool isAlive;
                if (hp > 0)
                {
                    isAlive = true;
                }
                else isAlive = false;

                return isAlive;
            }

            static int usePotion(int hp, int maxHP, int pot)
            {
                pot = hp * (hp / 5);
                hp = hp + pot;
                if (hp > maxHP)
                {
                    hp = maxHP;
                }
                return hp;
            }

            static int useAttack(int atk, int targetHP, int targetDef)
            {
                targetHP = (targetHP + targetDef) - atk;
                return targetHP;
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

            static int useDefend(int def)
            {
                int buff = def + (def / 3);
                return buff;
            }
        }
    }
}