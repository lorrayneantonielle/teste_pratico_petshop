using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace TesteDTI
{
    class Program
    {
        static void Main(string[] args)
        {

            MensagemInicial();

            bool sair = false;
            while (sair == false)
            {
                //entradas
                Console.WriteLine("Digite qual a data que deseja realizar os banhos ? Ex: dd/mm/aaaa");
                var data = Console.ReadLine();
                var formatData = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Quantos cães pequenos tomarão banho ?");
                int quantCaesPequenos = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantos cães grandes tomarão banho ?");
                int quantCaesGrandes = int.Parse(Console.ReadLine());

                //saídas
                if (quantCaesGrandes == 0 && quantCaesPequenos == 0)
                {
                    Console.WriteLine("Por favor, digite uma quantidade de cães válida (1 ou +), para pelo menos uma das categorias:");
                    Console.WriteLine("");
                }
                else if (quantCaesGrandes < 0 || quantCaesPequenos < 0)
                {
                    Console.WriteLine("Números negativos não são aceitos como quantidades válidas. Por favor, digite uma quantidade de cães válida (1 ou +), para pelo menos uma das categorias:");
                    Console.WriteLine("");
                }
                else
                {
                    if (VerificaFimSemana(formatData) == true)
                    {
                        //pega os valores do fim de semana
                        CaesFimSemana(quantCaesPequenos, quantCaesGrandes);
                        sair = true;
                    }
                    else if (VerificaFimSemana(formatData) == false)
                    {
                        //pega os valores da semana
                        CaesSemana(quantCaesPequenos, quantCaesGrandes);
                        sair = true;
                    }
                }
            }
            
            Console.ReadLine();
        }

        //métodos 
        static bool VerificaFimSemana(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }

        static void CaesSemana(int quantCaesPequenos, int quantCaesGrandes)
        {
            PetShop MeuCaninoFeliz;
            MeuCaninoFeliz = new PetShop();
            MeuCaninoFeliz.caoPequeno = 20;
            MeuCaninoFeliz.caoGrande = 40;
            MeuCaninoFeliz.distancia = 2000;

            int pequenoMCF = quantCaesPequenos * MeuCaninoFeliz.caoPequeno;
            int grandeMCF = quantCaesGrandes * MeuCaninoFeliz.caoGrande;
            int subTotalMCF = pequenoMCF + grandeMCF;

            PetShop VaiRex;
            VaiRex = new PetShop();
            VaiRex.caoPequeno = 15;
            VaiRex.caoGrande = 50;
            VaiRex.distancia = 1700;

            int pequenoSemanaVR = quantCaesPequenos * VaiRex.caoPequeno;
            int grandeSemanaVR = quantCaesGrandes * VaiRex.caoGrande;
            int subTotalVR = grandeSemanaVR + pequenoSemanaVR;

            PetShop ChowChawgas;
            ChowChawgas = new PetShop();
            ChowChawgas.caoPequeno = 30;
            ChowChawgas.caoGrande = 45;
            ChowChawgas.distancia = 800;

            int pequenoCC = quantCaesPequenos * ChowChawgas.caoPequeno;
            int grandeCC = quantCaesGrandes * ChowChawgas.caoGrande;
            int subTotalCC = pequenoCC + grandeCC;



            //verifica qual o petshop mais barato e retorna a msg
            if (subTotalMCF < subTotalVR && subTotalMCF < subTotalCC)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é o mais barato com o valor total dos banhos em R${subTotalMCF},00.");
            }
            else if (subTotalVR < subTotalMCF && subTotalVR < subTotalCC)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é o mais barato com o valor total dos banhos em R${subTotalVR},00.");
            }
            else if (subTotalCC < subTotalVR && subTotalCC < subTotalMCF)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é o mais barato com o valor total dos banhos em R${subTotalCC},00.");
            }
            //verifica se há preços iguais e retorna a msg com o petshop menos distante
            else if (subTotalMCF == subTotalVR << subTotalCC)
            {
                if (MeuCaninoFeliz.distancia < VaiRex.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é mais barato com o valor total dos banhos em R${subTotalMCF},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é mais barato com o valor total dos banhos em R${subTotalVR},00.");
                }

            }
            else if (subTotalMCF == subTotalCC << subTotalVR)
            {
                if (MeuCaninoFeliz.distancia < ChowChawgas.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é mais barato com o valor total dos banhos em R${subTotalMCF},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é mais barato com o valor total dos banhos em R${subTotalCC},00.");
                }
            }
            else if (subTotalVR == subTotalCC << subTotalMCF)
            {
                if (VaiRex.distancia < ChowChawgas.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é mais barato com o valor total dos banhos em R${subTotalVR},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é mais barato com o valor total dos banhos em R${subTotalCC},00.");
                }
            }
           

        }

        static void CaesFimSemana(int quantCaesPequenos, int quantCaesGrandes)
        {
            PetShop MeuCaninoFeliz;
            MeuCaninoFeliz = new PetShop();
            MeuCaninoFeliz.caoPequeno = 24;
            MeuCaninoFeliz.caoGrande = 48;
            MeuCaninoFeliz.distancia = 2000;

            int pequenoMCF = quantCaesPequenos * MeuCaninoFeliz.caoPequeno;
            int grandeMCF = quantCaesGrandes * MeuCaninoFeliz.caoGrande;
            int subTotalMCF = pequenoMCF + grandeMCF;

            PetShop VaiRex;
            VaiRex = new PetShop();
            VaiRex.caoPequeno = 20;
            VaiRex.caoGrande = 55;
            VaiRex.distancia = 1700;

            int pequenoSemanaVR = quantCaesPequenos * VaiRex.caoPequeno;
            int grandeSemanaVR = quantCaesGrandes * VaiRex.caoGrande;
            int subTotalVR = grandeSemanaVR + pequenoSemanaVR;

            PetShop ChowChawgas;
            ChowChawgas = new PetShop();
            ChowChawgas.caoPequeno = 30;
            ChowChawgas.caoGrande = 45;
            ChowChawgas.distancia = 800;

            int pequenoCC = quantCaesPequenos * ChowChawgas.caoPequeno;
            int grandeCC = quantCaesGrandes * ChowChawgas.caoGrande;
            int subTotalCC = pequenoCC + grandeCC;

            //verifica qual o petshop mais barato e retorna a msg
            if (subTotalMCF < subTotalVR && subTotalMCF < subTotalCC)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é o mais barato com o valor total dos banhos em R${subTotalMCF},00.");
            }
            else if (subTotalVR < subTotalMCF && subTotalVR < subTotalCC)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é o mais barato com o valor total dos banhos em R${subTotalVR},00.");
            }
            else if (subTotalCC < subTotalVR && subTotalCC < subTotalMCF)
            {
                Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é o mais barato com o valor total dos banhos em R${subTotalCC},00.");
            }
            //verifica se há preços iguais e retorna a msg com o petshop menos distante
            else if (subTotalMCF == subTotalVR << subTotalCC)
            {
                if (MeuCaninoFeliz.distancia < VaiRex.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é mais barato com o valor total dos banhos em R${subTotalMCF},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é mais barato com o valor total dos banhos em R${subTotalVR},00.");
                }

            }
            else if (subTotalMCF == subTotalCC << subTotalVR)
            {
                if (MeuCaninoFeliz.distancia < ChowChawgas.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Meu Canino Feliz, pois é mais barato com o valor total dos banhos em R${subTotalMCF},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é mais barato com o valor total dos banhos em R${subTotalCC},00.");
                }
            }
            else if (subTotalVR == subTotalCC << subTotalMCF)
            {
                if (VaiRex.distancia < ChowChawgas.distancia)
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o Vai Rex, pois é mais barato com o valor total dos banhos em R${subTotalVR},00.");
                }
                else
                {
                    Console.WriteLine($"O melhor PetShop para cuidar dos seus cãezinhos na data escolhida é o ChowChawgas, pois é mais barato com o valor total dos banhos em R${subTotalCC},00.");
                }
            }

        }

        static void MensagemInicial()
        {
            Console.WriteLine("================================ Bairro do Canil ================================");
            Console.WriteLine("");
            Console.WriteLine("Vamos verificar qual o melhor PetShop para cuidar dos banhos dos seus cãezinhos?");
            Console.WriteLine("");
        }

    }
}
