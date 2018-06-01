using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Classes
{
    class ContaCorrente : Conta
    {
        public double LimiteFixo { get; set; }
        public double LimiteAtual { get; set; }


        public ContaCorrente(int numero, int agencia, string titular, double limite) : base(numero, agencia, titular)
        {
            this.LimiteFixo = limite;
            LimiteAtual = limite;
        }


        public ContaCorrente() : base() { }


        public override void Saca(double valor)
        {
            bool podeSacar = valor <= this.Saldo && valor > 0;   // Se for possível descontar tudo do saldo, desconta do saldo.
            if (podeSacar)                        
            {
                this.Saldo -= valor;

            }
            else                                         //Se não for possível descontar tudo do saldo (saldo < saque) ...
            {
                podeSacar = (valor <= this.Saldo + this.LimiteAtual) && valor > 0;
                if ((podeSacar))                        //Desconta do saldo e o restante desconta do limite.
                {
                    valor -= this.Saldo;                //Subtrai o pouco saldo no valor a ser sacado.
                    this.Saldo = 0;                     //Zera o saldo
                    this.LimiteAtual -= valor;               //Desconta o restante do saque no limite. (limite é atualizado)

                }
                else                                    //Caso o saque seja maior que o saldo disponível + limite.
                {
                    Console.WriteLine();
                    Console.WriteLine("Não foi possível realizar o saque.");
                    Console.ReadLine();
                } 

            }   

        }


        public override void Deposita(double valor)
        {
            bool podeDepositar = valor > 0;                 //Não deposita valor negativo
            if (podeDepositar)
            {
                if (this.LimiteAtual.Equals(this.LimiteFixo))         // Se igual, o limite não foi alterado. Adiciona no saldo.
                {
                    this.Saldo += valor;
                }
                else                                             // Se diferente (limite foi alterado), complementa o limite e o resto adiciona ao saldo.
                {
                    
                    double complemento = this.LimiteFixo - this.LimiteAtual;        //Diferença para complementar o limite.
                    if (valor <= complemento)                                       //Valor é suficiente apenas para complementar o limite.
                        this.LimiteAtual += valor;                                  //Atualiza o limite.

                    else                                                            //O valor depositado complementa o limite a inda sobra para ser adicionado ao saldo.
                    {
                        this.LimiteAtual += complemento;                                     //Complementa o limite.
                        valor -= complemento;
                        this.Saldo += valor;                                            // A diferença adiciona ao saldo.
                    }
                }

            }
            else
            {
                Console.WriteLine("Valor de depósito inválido.");     // Se for passado um negativo, o programa não aceita.
                Console.ReadLine();
            }
        }


        
        //deve ser descontado do saldo restante um valor equivalente a 3% do valor transferido.
        public override void Transfere(Conta destino, double valorTransferido)
        {
            double valorDisponivel = this.Saldo + this.LimiteAtual;
            double saldoRestante = valorDisponivel - valorTransferido;
            double taxaDeTransf = 0.03 * valorTransferido;

            bool podeTransferir = ((saldoRestante >= taxaDeTransf) && valorTransferido > 0);   // Se, após a transferência, o que sobrar for maior ou igual à taxa.

            if (podeTransferir)
            {
                if (valorTransferido + taxaDeTransf <= this.Saldo) //Se for possível descontar o valor + a taxa apenas do saldo, transfira!.
                {
                    this.Saldo -= valorTransferido + taxaDeTransf;
                    destino.Deposita(valorTransferido);

                }
                else
                {
                    destino.Deposita(valorTransferido);             //Deposita na conta destino
                    valorTransferido -= this.Saldo;                //Subtrai o pouco saldo no valor a ser transferido.
                    this.Saldo = 0;                                //Zera o saldo             
                    this.LimiteAtual -= valorTransferido + taxaDeTransf;          //Desconta o restante do valor a ser transferido no limite. (limite é atualizado)

                }
            }
            else                                    //Valor a ser transferido maior que o saldo disponível + limite ou se for valor negativo ou nulo.
            {
                Console.WriteLine();
                Console.WriteLine("Não foi possível realizar a transferência.");
      
            }

            

        }

    }
}
