using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Classes
{
    class ContaPoupanca : Conta
    {


        public ContaPoupanca(int numero, int agencia, string titular) : base(numero, agencia, titular)
        {
        }

        public ContaPoupanca():base(){}         //Construtor vazio.

        
        public void aplicaRendimento()
        {
            double taxaDeRendimento = 0.05;                    //Taxa de rendimento de 5%.

            double rendimento = this.Saldo * taxaDeRendimento;  //Calcula o rendimento sobre o saldo.
            this.Saldo += rendimento;                           //Atualiza o saldo somando-o ao rendimento.
        }
    }

}
