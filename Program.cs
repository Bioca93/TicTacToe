using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace TicTacToeFINAL
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Olá! Este é o jogo do galo, com o nome original TIC TAC TOE.");
            Console.WriteLine();
            string[] players = ApresentacaoDoJogo();
            TicTacToe(players);

        }

        public static string[] ApresentacaoDoJogo()
        {
            bool definePlayers = false;

            Console.WriteLine("Qual o nome do jogador 1?");
            string jogador1 = Console.ReadLine();
            Console.WriteLine("Qual o nome do jogador 2?");
            string jogador2 = Console.ReadLine();

            string[] players = { jogador1, jogador2 };


            do
            {
                Console.WriteLine(jogador1 + " escolha entre X e O: ");
                char escolha = char.ToUpper(Console.ReadLine()[0]);

                if (!(escolha is 'X' or 'O'))
                {
                    Console.WriteLine("Opção inválida");
                }
                else
                {
                    players = ChoosePlayer(escolha, players);
                    definePlayers = true;
                }

            } while (!definePlayers);

          //  Console.WriteLine("O jogador " + players[0] + " é o primeiro a jogar porque escolheu a letra X");


            Console.WriteLine();
            Console.WriteLine("Estão preparados?");

            Console.WriteLine("Vamos jogar!");

            Console.ReadKey();
            Console.Clear();

            return players;

        }

        public static void TicTacToe(string[] players)
        {
            int i;
            char jogador = 'X';
            
            char[,] quadro = InicioJogo();

            int jogadas = 0;
            
            do
            {
                
                if (jogadas % 2 == 0)
                {
                    i = 0;
                }
                else
                {
                    i = 1;
                }

                Console.Clear();
                Imprimir(quadro);

                Console.WriteLine("É a vez do jogador " + players[i] + " jogar.\n");

                int[] posicoes = VerificaJogada(quadro);
                Jogar(posicoes, quadro, jogador);
                jogador = TrocaVez(jogador);

                jogadas++;


            } while (!Vitoria(quadro) && jogadas != 9);

            if (jogadas == 9)
            {
                Console.WriteLine("Empate!");
                Repetir(players);
            }
            else
            {
                Console.Clear();
                Imprimir(quadro);
                Console.WriteLine($"O jogador " + players[i] + " ganhou! Parabéns!");
                Repetir(players);
            }

        }
        public static string[] ChoosePlayer(char jogador, string[] players)
        {
            if (jogador == 'O')
            {
                string temp = players[0];
                players[0] = players[1];
                players[1] = temp;
            }
            return players;
        }
        public static void Jogar(int[] posicoes, char[,] quadro, char jogador)
        {
            quadro[posicoes[0], posicoes[1]] = jogador;

        }

        public static char TrocaVez(char trocaJogador)
        {
            if (trocaJogador == 'X')
                return 'O';
            else
                return 'X';
        }


        public static int[] PosicoesJogadas()
        {
            Console.Write("Introduza o número da linha que pretende jogar: ");
            int linha = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduza o número da coluna que pretende jogar: ");
            int coluna = Convert.ToInt32(Console.ReadLine());

            return new int[] { linha, coluna };

        }

        public static int[] VerificaJogada(char[,] quadro)
        {
            int[] posicoes = PosicoesJogadas();
            while (!(posicoes[0] >= 0 && posicoes[0] <= 2 && posicoes[1] >= 0 && posicoes[1] <= 2 && quadro[posicoes[0], posicoes[1]] == ' '))
            {
                Console.WriteLine("Jogada Invalida");
                posicoes = PosicoesJogadas();
            }
            return posicoes;
        }
        public static bool Vitoria(char[,] quadro)
        {

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if (quadro[0, coluna] == quadro[1, coluna] && quadro[1, coluna] == quadro[2, coluna] && quadro[0, coluna] != ' ')
                    {
                        return true;
                    }
                }
            }
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if (quadro[linha, 0] == quadro[linha, 1] && quadro[linha, 1] == quadro[linha, 2] && quadro[linha, 0] != ' ')
                    {
                        return true;
                    }
                }
            }
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if ((quadro[1, 1] == quadro[0, 0] && quadro[2, 2] == quadro[1, 1] && quadro[1, 1] != ' ') || (quadro[1, 1] == quadro[2, 0] && quadro[1, 1] == quadro[0, 2] && quadro[1, 1] != ' '))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public static void Repetir(string [] players)
        {
            Console.WriteLine();
            Console.WriteLine("Deseja repetir o jogo?");
            Console.WriteLine("1. Para repetir. \n 2. Para sair.");
            int repeticao = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (repeticao)
            {
                case 1:
                    TicTacToe(players);
                    break;

                case 2:
                    Console.WriteLine("FIM!!! \n Obrigad@ pela participação!");
                    break; 
            }
        }

        public static char[,] InicioJogo()
        {
            char[,] quadro = new char[3, 3];
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    quadro[linha, coluna] = ' ';
                }
            }
            return quadro;
        }

       public static void Imprimir(char[,] quadro)
        {
            Console.WriteLine("  | 0 | 1 | 2 |");
            for (int linha = 0; linha < 3; linha++)
            {
                Console.Write(linha + " | ");
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write(quadro[linha, coluna]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

      
    }
}
