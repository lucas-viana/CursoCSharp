using ExercicioInterface.Entities;
using ExercicioInterface.Services;
using System.Globalization;

Console.WriteLine("Enter contract data");

Console.Write("Number: ");
string numberContract = Console.ReadLine();

Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",CultureInfo.InvariantCulture);

Console.Write("Contract value: ");
double contractValue = double.Parse(Console.ReadLine());

Console.Write("Enter number of installments: ");
int installments = int.Parse(Console.ReadLine());

contractValue /= installments;

Contract contract = new Contract(numberContract, date, contractValue);
ContractService contractService = new ContractService(new PaypalService());

contractService.ProcessContract(contract, installments);

