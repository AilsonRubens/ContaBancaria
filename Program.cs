using ContaBancaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    class Program
    {

        static void InfoCC(ContaCorrente c)
        {
            
            Console.WriteLine("Agência: {0}", c.Agencia);
            Console.WriteLine("Número: {0}", c.Numero);
            Console.WriteLine("Titular: {0}", c.Titular);
            Console.WriteLine("Saldo: {0}", c.Saldo);
            Console.WriteLine("Limite disponível: {0}", c.LimiteAtual);
            Console.WriteLine();
        }

        static void InfoCP(ContaPoupanca c)
        {
            Console.WriteLine("Agência: {0}", c.Agencia);
            Console.WriteLine("Número: {0}", c.Numero);
            Console.WriteLine("Titular: {0}", c.Titular);
            Console.WriteLine("Saldo: {0}", c.Saldo);
            Console.WriteLine();
        }


        static void Main(string[] args)
        {

            double valor=0;

            ContaCorrente cc1 = new ContaCorrente(111, 111, "TitularCC1", 1000.0);
            ContaCorrente cc2 = new ContaCorrente(222, 222, "TitularCC2", 1000.0);
            ContaPoupanca cp1 = new ContaPoupanca(333, 333, "TitularCP1");
            ContaPoupanca cp2 = new ContaPoupanca(444, 444, "TitularCP2");



            Console.WriteLine("########    TESTES COM CONTAS POUPANÇAS    ########");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("DADOS DA CONTA 1:");
            InfoCP(cp1);
            Console.WriteLine("DADOS DA CONTA 2:");
            InfoCP(cp2);

            Console.WriteLine();

            Console.WriteLine("TESTANDO DEPÓSITO:");
            valor = 500;
            Console.WriteLine("Depositando {0} reais na conta de {1}...", valor, cp1.Titular);
            cp1.Deposita(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cp1.Titular, cp1.Saldo);
            Console.WriteLine("Depositando {0} reais na conta de {1}...", valor, cp2.Titular);
            cp2.Deposita(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cp2.Titular, cp2.Saldo);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TESTANDO SAQUES:");
            valor = 300;
            Console.WriteLine("Sacando {0} reais da conta de {1}...", valor, cp1.Titular);
            cp1.Saca(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cp1.Titular, cp1.Saldo);
            Console.WriteLine("Sacando {0} reais da conta de {1}...", valor, cp2.Titular);
            cp2.Saca(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cp2.Titular, cp2.Saldo);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TESTANDO TRANSFERÊNCIAS:");
            valor = 100;
            Console.WriteLine("Transferindo {0} reais de {1} para {2}...", valor, cp1.Titular, cp2.Titular);
            cp1.Transfere(cp2, valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cp1.Titular, cp1.Saldo);
            Console.WriteLine("Novo saldo de {0}: {1}", cp2.Titular, cp2.Saldo);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("APLICANDO RENDIMENTOS:");
            Console.WriteLine("Aplicando rendimento de 5% na conta de {0}...", cp1.Titular);
            cp1.aplicaRendimento();
            Console.WriteLine("Saldo de {0} após rendimento: {1} reais", cp1.Titular, cp1.Saldo);
            Console.WriteLine("Aplicando rendimento de 5% na conta de {0}...", cp2.Titular);
            cp2.aplicaRendimento();
            Console.WriteLine("Saldo de {0} após rendimento: {1} reais", cp2.Titular, cp2.Saldo);
            Console.WriteLine();


            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("########    TESTES COM CONTAS CORRENTES    ########");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("DADOS DA CONTA 1:");
            InfoCC(cc1);
            Console.WriteLine("DADOS DA CONTA 2:");
            InfoCC(cc2);

            valor = 500;
            Console.WriteLine("Depositando {0} reais na conta de {1}...", valor, cc1.Titular);
            cc1.Deposita(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cc1.Titular, cc1.Saldo);
            Console.WriteLine();
            Console.WriteLine("Depositando {0} reais na conta de {1}...", valor, cc2.Titular);
            cc2.Deposita(valor);
            Console.WriteLine("Novo saldo de {0}: {1}", cc2.Titular, cc2.Saldo);

            Console.WriteLine();
            Console.WriteLine();

            //Transferência descontada apenas do saldo.
            Console.WriteLine("DESCONTANDO TRANSFERÊNCIA APENAS DO SALDO:");
            valor = 100;
            Console.WriteLine("Transferindo {0} reais de {1} para {2} ...", valor, cc1.Titular, cc2.Titular);
            cc1.Transfere(cc2, valor);
            Console.WriteLine("Saldo de {0} após transferência: {1} reais. Limite disponível: {2} reais.", cc1.Titular, cc1.Saldo, cc1.LimiteAtual);
            Console.WriteLine("Saldo de {0} após receber transferência: {1} reais. Limite disponível: {2}", cc2.Titular, cc2.Saldo, cc2.LimiteAtual);

            Console.WriteLine();
            Console.WriteLine();

            //Transferência descontada do saldo e do limite. O saldo vai zerar e o limite será liquidado.
            Console.WriteLine("DESCONTANDO TRANSFERÊNCIA DO SALDO E DO LIMITE:");
            valor = 500;
            Console.WriteLine("Transferindo {0} reais de {1} para {2} ...", valor, cc1.Titular, cc2.Titular);
            cc1.Transfere(cc2, valor);
            Console.WriteLine("Saldo de {0} após transferência: {1} reais", cc1.Titular, cc1.Saldo);
            Console.WriteLine("Limite disponível de {0} após transferência: {1} reais", cc1.Titular, cc1.LimiteAtual);
            Console.WriteLine("Saldo de {0} após receber transferência: {1} reais", cc2.Titular, cc2.Saldo);

            Console.WriteLine();
            Console.WriteLine();

            //Tentando transferir valor superior ao valor dispónível (saldo + limite) + taxa.
            Console.WriteLine("TENTANDO TRANSFERIR VALOR SUPERIOR AO VALOR DISPÓNÍVEL (SALDO + LIMITE):");
            valor = 900;
            Console.WriteLine("Transferindo {0} reais de {1} para {2} ...", valor, cc1.Titular, cc2.Titular);
            cc1.Transfere(cc2, valor);
            Console.WriteLine("Saldo de {0} após transferência: {1} reais", cc1.Titular, cc1.Saldo);
            Console.WriteLine("Limite disponível de {0} após transferência: {1} reais", cc1.Titular, cc1.LimiteAtual);
            Console.WriteLine("Saldo de {0} após receber transferência: {1} reais", cc2.Titular, cc2.Saldo);


            Console.WriteLine();
            Console.WriteLine();

            valor = 1000;
            Console.WriteLine("TESTANDO O SAQUE.");
            Console.WriteLine("Saldo atual de {0}: {1} reais. ", cc2.Titular, cc2.Saldo);
            Console.WriteLine("Sacando {0} reais de {1}... ", valor, cc2.Titular);
            cc2.Saca(valor);
            Console.WriteLine("Novo saldo: {0} ", cc2.Saldo);


            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("DADOS DA CONTA 1:");
            InfoCC(cc1);
            Console.WriteLine("DADOS DA CONTA 2:");
            InfoCC(cc2);
            Console.WriteLine();

            
            Console.WriteLine("TESTANDO DEPÓSITO COM LIMITE INCOMPLETO");
            valor = 100;
            Console.WriteLine("Depositando {0} reais na conta de {1}... ", valor, cc1.Titular);
            cc1.Deposita(valor);
            Console.WriteLine("Saldo de {0} após depósito: {1} reais", cc1.Titular, cc1.Saldo);
            Console.WriteLine("Limite disponível de {0} após depósito: {1} reais", cc1.Titular, cc1.LimiteAtual);
            

            Console.WriteLine();

            Console.WriteLine("TESTANDO DEPÓSITO COM LIMITE INCOMPLETO");
            valor = 100;
            Console.WriteLine("Depositando {0} reais na conta de {1}... ", valor, cc1.Titular);
            cc1.Deposita(valor);
            Console.WriteLine("Saldo de {0} após depósito: {1} reais", cc1.Titular, cc1.Saldo);
            Console.WriteLine("Limite disponível de {0} após depósito: {1} reais", cc1.Titular, cc1.LimiteAtual);


            Console.WriteLine();
            Console.WriteLine();


            //Transferência entre conta corrente e conta poupança.
            Console.WriteLine("Testando transferência entre contas corrente e poupança:");
            InfoCC(cc1);
            InfoCP(cp1);
            valor = 50;
            Console.WriteLine("Transferindo {0} reais de {1} para {2} ...", valor, cc1.Titular, cp1.Titular);
            cc1.Transfere(cp1, valor);
            Console.WriteLine("Saldo de {0} após transferência: {1} reais. Limite disponível: {2} reais.", cc1.Titular, cc1.Saldo, cc1.LimiteAtual);
            Console.WriteLine("Saldo de {0} após receber transferência: {1} reais.", cp1.Titular, cp1.Saldo);


            Console.ReadLine();

        }
    }
}



