using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_08_2_
{
    public class Department
    {
        #region Поля
        /// <summary>
        /// Наименование департамента
        /// </summary>
        string name;
        /// <summary>
        /// Дата создания департампента
        /// </summary>
        DateTime timeOfCreate;
        /// <summary>
        /// Количество сотрудников департамента
        /// </summary>
        int count;
        /// <summary>
        /// идентификационный номер департамента
        /// </summary>
        int id;
        
        /// <summary>
        /// База данных имён
        /// </summary>
        static readonly string[] firstNames;

        /// <summary>
        /// База данных фамилий
        /// </summary>
        static readonly string[] lastNames;

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random randomize;
        #endregion

        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах и фамилиях баз данных firstNames и lastNames
        /// </summary>
        static Department()
        {
            randomize = new Random(); // Размещение в памяти генератора случайных чисел

            // Размещение имен в базе данных firstNames
            firstNames = new string[] {
                "Александр",
                "Алексей",
                "Артем",
                "Артур",
                "Антон",
                "Альберт",
                "Борис",
                "Владимир",
                "Василий",
                "Вениамин",
                "Вячеслав",
                "Виктор",
                "Григорий",
                "Георгий",
                "Геннадий",
                "Дмитрий",
                "Денис",
                "Евгений",
                "Зиновий",
                "Иван",
                "Игнат",
                "Илья",
                "Игорь",
                "Константин",
                "Кондрат",
                "Леонид",
                "Лаврентий",
                "Лука",
                "Михаил",
                "Максим",
                "Николай",
                "Никита",
                "Олег",
                "Петр",
                "Роман",
                "Роберт",
                "Степан",
                "Семен",
                "Сергей",
                "Серафим",
                "Тимофей",
                "Тимур",
                "Федор",
                "Фома",
                "Харитон",
                "Эдуартд",
                "Эвклид",
                "Юрий",
                "Яков"
            };

            // Размещение фамилий в базе данных lastNames
            lastNames = new string[]
            {
                "Иванов",
                "Петров",
                "Васильев",
                "Кузнецов",
                "Ковалёв",
                "Попов",
                "Пономарёв",
                "Дьячков",
                "Коновалов",
                "Соколов",
                "Лебедев",
                "Соловьёв",
                "Козлов",
                "Волков",
                "Зайцев",
                "Ершов",
                "Карпов",
                "Щукин",
                "Виноградов",
                "Цветков",
                "Калинин"
            };
        }

        /// <summary>
        /// База данных работников, в которой хранятся 
        /// Имя, фамилия, возраст и зарплаты каждого сотрудника
        /// </summary>
        public List<Worker> workers { get; set; }

        public List<Department> departments { get; set; }

        public Department() {}
        
        /// <summary>
        /// Конструктор, заполняющий базу данных Department
        /// </summary>
        /// <param name="Count">Количество сотрудников, которых нужно создать</param>
        public Department(string Name, DateTime TimeCreate, int Count, int Id)
        {
            this.name = Name;
            this.timeOfCreate = TimeCreate;
            this.workers = new List<Worker>(); // Выделение памяти для хранения базы данных Workers
            for (int i = 0; i < Count; i++)    // Заполнение базы данных Workers. Выполняется Count раз
            {
                // Добавляем нового работника в базы данных Workers
                this.workers.Add(
                    new Worker(
                        // выбираем случайное имя из базы данных имён
                        firstNames[Department.randomize.Next(Department.firstNames.Length)],

                        // выбираем случайную фамилию из базы данных фамилий
                        lastNames[Department.randomize.Next(Department.lastNames.Length)],

                        // Генерируем случайный возраст в диапазоне 19 лет - 60 лет
                        randomize.Next(19, 60),

                        // Генерируем случайную зарплату в диапазоне 10000руб - 80000руб
                        randomize.Next(10000, 80000),

                        // присваиваем номер ID
                        Guid.NewGuid(), //GetId(tempWorkers),                                               

                        //наименование департамента, в котором числится сотрудник
                        Name,

                        // количество проектов, над которыми работает сотрудник
                        randomize.Next(1, 5)
                        )); ;
            }
            this.count = Count;
            this.id = Id;
            this.departments = new List<Department>();
        }

        public int amount;
        /// <summary>
        /// метод подсчета общего количества департаментов
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public int AmountDep(Department dep)
        {
            
            if (dep.Id == 1)
            {
                amount = 1;
            }
            if (dep.departments.Count > 0)
            {
                foreach (var item in dep.departments)
                {
                    amount++;
                    if (item.departments.Count > 0)
                    {
                        AmountDep(item);
                    }
                }
            }            
            return amount;
        }

        /// <summary>
        /// метод добавления департамента в структуру вышестоящего департамента
        /// </summary>
        /// <param name="dep">структура вышестоящего депарамента</param>
        /// <param name="Name">название добавляемого департамента</param>
        /// <param name="TimeCreate">дата создания</param>
        /// 
        public void AddDepartment(Department dep, string name, DateTime timeCreate, int countWorks, int id)
        {
            dep.departments.Add(new Department(name, timeCreate, countWorks, id));
        }

        /// <summary>
        /// Метод удаления департамента
        /// </summary>
        /// <param name="department"></param>
        /// <param name="id">ID департамента</param>
        public void RemoveDepartment(Department department, int id)
        {
            if (department.departments.Count > 0)
            {
                foreach (var item in department.departments)
                {
                    if (item.Id == id)
                    {
                        department.departments.Remove(item);
                        return;
                    }
                    else
                    {
                        RemoveDepartment(item, id);
                    }
                }
            }
        }

        /// <summary>
        /// Методо добавления сотрудника
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Месячная зарплата</param>
        /// <param name="id">Идентификационный номер</param>
        /// <param name="department">Наименование департамента, в котором числится работник</param>
        /// <param name="quantity">Количество проектов, в которых задействован работник</param>        
        public void AddWorker(string firstName, string lastName, byte age, int salary, string department, byte quantity)
        {
            workers.Add(new Worker(firstName, lastName, age, salary, Guid.NewGuid(), department, quantity));
            this.count++;
        }
        /// <summary>
        /// метод добавления работника в конкретный департамент
        /// </summary>
        /// <param name="firstName">Имя работника</param>
        /// <param name="lastName">Фамилия работника</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="salary">Месячная зарплата работника</param>        
        /// <param name="title">наименование департамента, в котором числится работник</param>
        /// <param name="quantity">количество проектов, в которых задействован работник</param>
        public void AddWorkerToDep(Department dep, string firstName, string lastName, byte age, int salary, string title, byte quantity)
        {
            dep.AddWorker(firstName, lastName, age, salary, title, quantity);
        }
        /// <summary>
        /// Метод редактирования заработной платы и числа проектов сотрудника
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="salary"></param>
        public void EditWorker(Worker worker, int salary, int quatnity)
        {
            worker.Salary = salary;
            worker.Quantity = quatnity;
        }

        List<Worker> tempWorkers = new List<Worker>();

        /// <summary>
        /// метод получения всех работников из всех департаментов организации
        /// </summary>
        /// <param name="dep"></param>
        public void GetAllWorkers(Department dep)
        {
            if (dep.Id == 1)
            {
                foreach (var item in dep.workers)
                {
                    tempWorkers.Add(item);
                }
            }
            if (dep.departments.Count > 0)
            {
                foreach (var item in dep.departments)
                {
                    if (item.workers.Count > 0)
                    {
                        foreach (var items in item.workers)
                        {
                            tempWorkers.Add(items);
                        }
                    }
                    GetAllWorkers(item);
                }
            }
        }

        /// <summary>
        /// выводит в консоль информацию о всех работниках организации
        /// </summary>
        /// <param name="workers"></param>
        public void PrintListOfWorker(List<Worker> workers)
        {
            Console.WriteLine($"{"Имя",10} {"Фамилия",13} {"Возраст",13} {"Зарплата",13} {"Департамент",18} {"Проектов",10}");
            foreach (var item in workers)
            {
                Console.WriteLine(item.PrintWorker(item));
            }
        }

        /// <summary>
        /// Сортировка сотрудников по возрасту
        /// </summary>
        /// <param name="department"></param>
        public List<Worker> SortedByAge(Department department)
        {
            tempWorkers.Clear();
            GetAllWorkers(department);
            List<Worker> sortedByAge = tempWorkers.OrderBy(a => a.Age).ToList();
            return sortedByAge;
        }

        /// <summary>
        /// сортировка работников по заработной плате
        /// </summary>
        /// <param name="department"></param>
        public List<Worker> SortedBySalary(Department department)
        {
            tempWorkers.Clear();
            GetAllWorkers(department);
            List<Worker> sortedBySalary = tempWorkers.OrderBy(b => b.Salary).ToList();
            return sortedBySalary;            
        }

        /// <summary>
        /// Сортировка работников по количеству проектов
        /// </summary>
        /// <param name="department"></param>
        public List<Worker> SortedByQuantity(Department department)
        {
            tempWorkers.Clear();
            GetAllWorkers(department);
            List<Worker> sortedByQuantity = tempWorkers.OrderBy(c => c.Quantity).ToList();
            return sortedByQuantity;
        }           

        /// <summary>
        /// Метод проверки наличия департамента по номеру ID
        /// </summary>
        /// <param name="dep">структура депарамента, в котором производится поиск</param>
        /// <param name="title">название департамента, наличие которого проверяется</param>
        /// <returns></returns>
        public bool CheckExistDepartment(List<Department> departments, int id)
        {
            foreach (var item in departments)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// получение индивидуального номера департамента
        /// </summary>
        /// <param name="sortedById"></param>
        /// <returns></returns>
        public int GetId(List<Department> sortedById)
        {
            int maxId = sortedById[sortedById.Count - 1].Id + 1;
            return maxId;
        }
        
        #region Свойства
        /// <summary>
        /// Наименование департамента
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime TimeOfCreate { get { return this.timeOfCreate; } set { this.timeOfCreate = value; } }
        /// <summary>
        /// Количество сотрудников департамента
        /// </summary>
        public int Count { get { return this.count; } set { this.count = value; } }
        /// <summary>
        /// Идентификационный номер департамента
        /// </summary>
        public int Id { get { return this.id; } set { this.id = value; } }

        #endregion     
                
    }
}
