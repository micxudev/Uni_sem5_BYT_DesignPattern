// In case you need some guidance: https://refactoring.guru/design-patterns/adapter
namespace DesignPattern.Adapter
{
    public class EmployeeAdapter : ITarget
    {
        private readonly BillingSystem thirdPartyBillingSystem = new();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            var rows = employeesArray.GetLength(0);

            var listEmployee = new List<Employee>(rows);

            for (var i = 0; i < rows; i++)
            {
                var id = int.Parse(employeesArray[i, 0]);
                var name = employeesArray[i, 1];
                var designation = employeesArray[i, 2];
                var salary = decimal.Parse(employeesArray[i, 3]);

                var employee = new Employee(id, name, designation, salary);

                listEmployee.Add(employee);
            }

            thirdPartyBillingSystem.ProcessSalary(listEmployee);
        }
    }
}