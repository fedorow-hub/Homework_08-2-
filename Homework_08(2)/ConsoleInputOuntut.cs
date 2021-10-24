using System;
using System.Collections.Generic;

namespace Homework_08_2_
{
    class ConsoleInputOuntut
    {
        public ConsoleInputOuntut()
        {

        }
        /// <summary>
        /// создание первого департамента
        /// </summary>
        /// <returns></returns>
        public Department DepartmentCreate()
        {
            Department tempDepartment = new Department();
            Console.WriteLine("Для создания первого департамента введите его название");
            string name = Console.ReadLine();
            DateTime dateCreate;
            Console.WriteLine("Введите дату создания первого департамента в формате год/месяц/день");
            bool isInt = DateTime.TryParse(Console.ReadLine(), out dateCreate);
            while (!isInt)
            {
                Console.WriteLine("Введите корректную дату в формате год/месяц/день");
                isInt = DateTime.TryParse(Console.ReadLine(), out dateCreate);
            }
            int count;
            Console.WriteLine("Введите количество сотрудников первого департамента");
            isInt = Int32.TryParse(Console.ReadLine(), out count);
            while (!isInt || count < 0)
            {
                Console.WriteLine("недопустимое значение,введите положительное целое число");
                isInt = Int32.TryParse(Console.ReadLine(), out count);
            }
            return tempDepartment = new Department(name, dateCreate, count, 1);
        }        

        /// <summary>
        /// Главное меню
        /// </summary>
        /// <returns></returns>
        public int UserChoise()
        {
            Console.ReadLine();
            Console.WriteLine("Выберите пункт меню для дальнейших действий, нажав соответствующую цифру:");
            Console.WriteLine();
            Console.WriteLine("1 - Добавление департамента");
            Console.WriteLine("2 - Редактирование названия департамента");
            Console.WriteLine("3 - Удаление департамента");
            Console.WriteLine("4 - Добавление сотрудника");
            Console.WriteLine("5 - Редактирование данных сотрудника");
            Console.WriteLine("6 - Удаление сотрудника");
            Console.WriteLine("7 - Сортировка сотрудников");
            Console.WriteLine("8 - Отображение структуры в консоли");
            Console.WriteLine("9 - Выход с сохранением изменений");

            int value; //переменная для обработки пользовательского ввода

            bool isInt = Int32.TryParse(Console.ReadLine(), out value);
            while (!isInt || value < 1 || value > 9)
            {
                Console.WriteLine("недопустимое значение,введите число  от 1 до 9");
                isInt = Int32.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }

        /// <summary>
        /// выводит в консоль все имеющиеся департаменты в соответствии с их вложенностью
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="trim"></param>
        public void PrintDep(Department dep, string trim = "  ")
        {
            if (dep.Id == 1)
            {
                Console.WriteLine($"{trim}{dep.Name,10} {"ID №"}{dep.Id}");
            }
            foreach (var item in dep.departments)
            {
                Console.WriteLine($"{trim + "    "}{item.Name,10} {"ID №"}{item.Id}");
                if (item.departments.Count > 0)
                {
                    PrintDep(item, trim + "    ");
                }
            }
        }

        /// <summary>
        /// выводит в консоль все имеющиеся департаменты в соответствии с их вложенностью
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="trim"></param>
        public void PrintDepartment(Department dep, string trim = "  ")
        {
            Console.WriteLine("В следующие департаменты доступно добавление:");

            PrintDep(dep, trim = "  ");
        }

        /// <summary>
        /// метод получения названия добавляемого департамента
        /// </summary>
        /// <returns></returns>
        public string GetNameDepartnent()
        {
            string name;
            Console.WriteLine("Введите название добавляемого департамента");
            name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Метод получения даты добавляемого департамента
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeCreate()
        {
            DateTime dateCreate;
            Console.WriteLine("Введите дату создания добавляемого департамента в формате год/месяц/день");
            bool isInt = DateTime.TryParse(Console.ReadLine(), out dateCreate);
            while (!isInt)
            {
                Console.WriteLine("Введите корректную дату в формате год/месяц/день");
                isInt = DateTime.TryParse(Console.ReadLine(), out dateCreate);
            }
            return dateCreate;
        }

        /// <summary>
        /// Метод получения количества работников в добавляемом департаменте
        /// </summary>
        /// <returns></returns>
        public int GetCountWorks()
        {
            int count;
            Console.WriteLine("Введите количество сотрудников добавляемого департамента");
            bool isInt = Int32.TryParse(Console.ReadLine(), out count);
            while (!isInt || count < 0)
            {
                Console.WriteLine("недопустимое значение,введите положительное целое число");
                isInt = Int32.TryParse(Console.ReadLine(), out count);
            }
            return count;
        }        

        /// <summary>
        /// Метод получения ID родительского департамента
        /// </summary>
        /// <returns></returns>
        public int GetIdParentDep()
        {
            int id;
            Console.WriteLine("Ведите ID департамента, в который добавляется департамент:");
            bool isInt = Int32.TryParse(Console.ReadLine(), out id);
            while (!isInt || id < 0)
            {
                Console.WriteLine("недопустимое значение,введите положительное целое число");
                isInt = Int32.TryParse(Console.ReadLine(), out id);
            }
            return id;
        }        
       
        /// <summary>
        /// вывод в консоль всей информации о входящих в структуру организации департаментов и работников
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="trim"></param>
        public void PrintOrganisation(Department dep, string trim = "")
        {
            if (dep.Id == 1)
            {
                Console.WriteLine($"{trim} Департамент: {dep.Name}; ID: {dep.Id, 5};  " +
                    $"Дата создания: {dep.TimeOfCreate, 5}; Количество работников: {dep.Count}");
                Console.WriteLine($"{" "}{trim}{"Данные сотрудника:"}" +
                        $"{"Имя",10} {"Фамилия",13} {"Возраст",13} " +
                        $"{"Зарплата",13} {"Департамент",18} {"Проектов",10}");
                for (int i = 0; i < dep.Count; i++)
                {
                    Console.WriteLine($"{"",18}{" "}{trim}" +
                        $"{dep.workers[i].Firstname,10}" +
                        $"{dep.workers[i].Lastname,14}" +
                        $"{dep.workers[i].Age,14}" +
                        $"{dep.workers[i].Salary,14}" +
                        $"{dep.workers[i].Department,19}" +
                        $"{dep.workers[i].Quantity,11}");
                }
            }            
            foreach (var item in dep.departments)
            {
                Console.WriteLine($"{trim + "    "} Департамент: {item.Name, 5}; ID: {item.Id,5};  " +
                    $"Дата создания: {item.TimeOfCreate, 5}; Количество работников: {item.Count}");
                if (item.Count > 0)
                {
                    Console.WriteLine($"{" "}{trim + "    "}{"Данные сотрудника:"}" +
                        $"{"Имя",10} {"Фамилия",13} {"Возраст",13} " +
                        $"{"Зарплата",13} {"Департамент",18} {"Проектов",10}");
                    for (int i = 0; i < item.Count; i++)
                    {
                        Console.WriteLine($"{"",18}{" "}{trim + "    "}" +
                            $"{item.workers[i].Firstname, 10}" +
                            $"{item.workers[i].Lastname, 14}" +
                            $"{item.workers[i].Age, 14}" +
                            $"{item.workers[i].Salary, 14}" +
                            $"{item.workers[i].Department, 19}" +
                            $"{item.workers[i].Quantity, 11}");
                    }                    
                }
                if (item.departments.Count > 0)
                {
                    PrintOrganisation(item, trim + "    ");
                }
            }
        }
        
        /// <summary>
        /// выбор департамента для редактирования или удаления
        /// </summary>
        /// <param name="dep"></param>
        public int ChoiseDepartmentForEdit(Department dep)
        {
            Console.WriteLine("Доступные для редактирования и удаления департаменты:");

            PrintDep(dep);

            Console.WriteLine("Введите ID департамента, который необходимо редактировать или удалить");
            int idDep;
            bool isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            while (!isInt || idDep < 0 || idDep > dep.AmountDep(dep))
            {
                Console.WriteLine($"введите положительное целое число от 1 до {dep.AmountDep(dep)}");
                isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            }
            return idDep;
        }

        /// <summary>
        /// Метод редактирования наименования департамента
        /// </summary>
        /// <param name="department"></param>
        public void EditDepartment(Department department)
        {
            Console.WriteLine("Введите новое название департамента");
            department.Name = Console.ReadLine(); 
        }

        /// <summary>
        /// выбор департамента для добавления сотрудника
        /// </summary>
        /// <param name="dep"></param>
        public int ChoiseDepartmentForAddWorker(Department dep)
        {
            Console.WriteLine("Доступные для добавления, сотрудников департаменты:");

            PrintDepartment(dep);

            Console.WriteLine("Введите ID департамента, в который необходимо добавить сотрудника");
            int idDep;
            bool isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            while (!isInt || idDep < 0 || idDep > dep.AmountDep(dep))
            {
                Console.WriteLine($"введите положительное целое число от 1 до {dep.AmountDep(dep)}");
                isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            }
            return idDep;
        }

        /// <summary>
        /// Метод заполнения полей очередного добавляемого сотрудника
        /// </summary>
        /// <returns></returns>
        public (string, string, byte, int, byte) FillFildsWorker()
        {
            Console.WriteLine("Введите имя сотрудника:");

            string firstName = Console.ReadLine();

            Console.WriteLine("Ведите фамилию сотрудника:");

            string lastName = Console.ReadLine();

            Random random = new Random();

            byte age = (byte)random.Next(18, 65);

            int salary = (int)random.Next(20000, 200000);

            byte quantity = (byte)random.Next(1, 5);

            var tuple = (firstName, lastName, age, salary, quantity);

            return tuple;
        }

        /// <summary>
        /// выбор департамента для редактирования или удаления сотрудника
        /// </summary>
        /// <param name="dep"></param>
        public int ChoiseDepartmentForEditRemoveWorker(Department dep)
        {      
            PrintOrganisation(dep);

            Console.WriteLine("Введите ID департамента для редактирования или удаления сотрудника");
            
            int idDep;
            bool isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            while (!isInt || idDep < 0 || idDep > dep.AmountDep(dep))
            {
                Console.WriteLine($"введите положительное целое число от 1 до {dep.AmountDep(dep)}");
                isInt = Int32.TryParse(Console.ReadLine(), out idDep);
            }
            return idDep;
        }
               
        List<Worker> tempWorkers = new List<Worker>();//временная коллекция работников

        /// <summary>
        /// Метод получения коллекции сотрудников с соответствующим именем
        /// </summary>
        /// <param name="dep"></param>
        public void GetWorkerByName(Department dep)
        {
            tempWorkers.Clear();
            while (tempWorkers.Count == 0)
            {
                Console.WriteLine("Введите имя сотрудника");
                string firstname = Console.ReadLine();
                for (int i = 0; i < dep.workers.Count; i++)
                {
                    if (dep.workers[i].Firstname == firstname)
                    {
                        tempWorkers.Add(dep.workers[i]);
                    }
                }
                if (tempWorkers.Count == 0)
                {
                    Console.WriteLine("Сотрудника с таким именем не существует в данном департаменте");
                }
            }           
        }

        Worker tempWorker = new Worker();//создание временного сотрудника

        /// <summary>
        /// Метод получения сотрудника с соответствующей фамилией из коллекции сотрудников с одним именем
        /// </summary>
        /// <returns></returns>
        public Worker GetWorker()
        {
            tempWorker = null;
            do
            {
                Console.WriteLine("Введите фамилию сотрудника");
                string lastname = Console.ReadLine();
                for (int i = 0; i < tempWorkers.Count; i++)
                {
                    if (tempWorkers[i].Lastname == lastname)
                    {
                        tempWorker = tempWorkers[i];
                    }
                    else
                    {
                        Console.WriteLine($"Сотрудника по имени {tempWorkers[i].Firstname} с фамилией {lastname} не существует, введите другую фамилию");
                    }
                }
            } while (tempWorker==null);
            return tempWorker;
        }

        /// <summary>
        /// Метод получения новой заработной платы и количества проеков сотрудника
        /// </summary>
        /// <returns></returns>
        public (int, int) GetSalaryAndQuantity()
        {
            Console.WriteLine("Введите новую заработную плату сотрудника");
            int newSalary;
            bool isInt = Int32.TryParse(Console.ReadLine(), out newSalary);
            while (!isInt || newSalary < 0)
            {
                Console.WriteLine($"введите положительное число");
                isInt = Int32.TryParse(Console.ReadLine(), out newSalary);
            }

            Console.WriteLine("Введите новые данные о количестве проектов сотрудника");
            int newQuantity;
            isInt = Int32.TryParse(Console.ReadLine(), out newQuantity);
            while (!isInt || newQuantity < 0 || newQuantity > 5)
            {
                Console.WriteLine($"введите положительное число от 1 до 5");
                isInt = Int32.TryParse(Console.ReadLine(), out newQuantity);
            }
            var tuple = (newSalary, newQuantity);

            return tuple;
        }

        /// <summary>
        /// метод удаления сотрудника
        /// </summary>
        /// <param name="department"></param>
        public void DeleteWorker(Department department)
        {
            tempWorkers.Clear();
            GetWorkerByName(department);
            int j = 0;
            do
            {
                Console.WriteLine("Введите фамилию сотрудника");
                string lastname = Console.ReadLine();
                for (int i = 0; i < tempWorkers.Count; i++)
                {
                    if (tempWorkers[i].Lastname == lastname)
                    {
                        department.workers.Remove(tempWorkers[i]);
                        department.Count--;
                        j = 0;
                    }
                    else
                    {
                        Console.WriteLine($"Сотрудника по имени {tempWorkers[i].Firstname} с фамилией {lastname} не существует, введите другую фамилию");
                        j = 1;
                    }
                }
            } while (j == 1); 
        }
        /// <summary>
        /// Меню выбора поля  сотрудников для сортировки
        /// </summary>
        /// <returns></returns>
        public int UserChoiseSortWorker()
        {
            Console.WriteLine("Введите цифру, соответствующую вашему выбору");
            Console.WriteLine();
            Console.WriteLine("1 - Сортировка по возрасту");
            Console.WriteLine("2 - Сортировка по заработной плате");
            Console.WriteLine("3 - Сортировка по количеству проектов");
            int value;
            bool isInt = Int32.TryParse(Console.ReadLine(), out value);
            while (!isInt || value < 1 || value > 3)
            {
                Console.WriteLine("недопустимое значение,введите число  от 1 до 3");
                isInt = Int32.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
    }
}
