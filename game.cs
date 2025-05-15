using System;

namespace Aprendendo
{
    internal class Program
    {
        static int Damage(int vida, int dano)
        {
            return (vida - dano);
        }

        static void Main(string[] args)
        {
            int health = 15;
            int power = 3;

            int eneh = 15;
            int enep = 3;

            int haki = 2;
            int hakic = 0;
            string choose = "";

            Random rng = new Random(); // Gerador de números aleatórios

            // Função local pra verificar se o ataque acerta
            bool AcertouAtaque()
            {
                return rng.Next(0, 100) < 75; // Se for maior que 75 = true, se nao false
            }

            while (health > 0 && eneh > 0)
            {
                Console.Clear();
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("SUA VIDA/PODER: " + health + "/" + power);
                Console.WriteLine("VIDA INIMIGO: " + eneh);
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("O que você vai fazer? (atacar / defender / haki)");
                choose = Console.ReadLine();

                if (choose == "atacar" || choose == "Atacar")
                {
                    if (AcertouAtaque())
                    {
                        eneh = Damage(eneh, power);
                        Console.WriteLine("Você desferiu um golpe com sua espada e atingiu o oponente!");
                    }
                    else
                    {
                        Console.WriteLine("Você errou o ataque!");
                    }
                }
                else if (choose == "defender")
                {
                    Console.WriteLine("Você bloqueia o ataque do oponente!");
                }
                else if (choose == "haki")
                {
                    if (hakic == 1)
                    {
                        Console.WriteLine("Você já utilizou o Haki!");
                    }
                    else
                    {
                        power += haki;
                        Console.WriteLine("Você sente sua força de vontade emanar do seu corpo e se materializar em um revestimento escuro por toda sua lâmina!");
                        hakic += 1;
                    }

                }
                else
                {
                    Console.WriteLine("Comando inválido!");
                }

                // Inimigo ataca se ainda estiver vivo e jogador não defendeu
                if (eneh > 0 && choose != "defender")
                {
                    if (AcertouAtaque())
                    {
                        health = Damage(health, enep);
                        Console.WriteLine("O inimigo te acertou!");
                    }
                    else
                    {
                        Console.WriteLine("O inimigo tentou te atacar, mas errou!");
                    }
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }

            Console.Clear();
            if (health <= 0 && eneh <= 0)
            {
                Console.WriteLine("EMOCINANTE! Os dois grandes piratas caíram em batalha.");
            }
            else if (health <= 0)
            {
                Console.WriteLine("Você foi derrotado...");
            }
            else
            {
                Console.WriteLine("INCRIVEL! Você venceu a batalha.");
            }

            Console.ReadLine();
        }
    }
}
