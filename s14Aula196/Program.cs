using System;
using System.Globalization;
using s14Aula196.Entities;
using s14Aula196.Services;

namespace s14Aula196
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Enter contract data ******");
            Console.Write("Number: ");
            int numbContract = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            String date = Console.ReadLine();
            DateTime dateContract = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(numbContract, dateContract, contractValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);

            Console.WriteLine("Installments: ");

            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }

        }
    }
}
