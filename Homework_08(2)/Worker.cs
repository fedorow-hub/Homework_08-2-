using System;

namespace Homework_08_2_
{
    public class Worker
    {
        #region Поля
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        string firstname;
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        string lastname;
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        int age;
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        int salary;
        /// <summary>
        /// Департамет, в котором работает сотрудник
        /// </summary>
        string department;
        /// <summary>
        /// Количество проектов, закрепленных за сотрудником
        /// </summary>
        int quantity;
        /// <summary>
        /// идентификационный номер сотрудника
        /// </summary>
        Guid id;
        #endregion
        #region Конструктор
        public Worker(){}

        /// <summary>
        /// Конструктор создания работника
        /// </summary>
        /// <param name="Firstname">Имя</param>
        /// <param name="Lastname">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Месячная зарплата</param>
        /// <param name="Id">Идентификационный номер</param>
        ///// <param name="Department">Департамент, в котором числится работник</param>
        /// <param name="Quantity">Количество проектов, в которых задействован работник</param>
        public Worker(string Firstname, string Lastname, int Age, int Salary, Guid Id, string Department, int Quantity)
        {
            this.firstname = Firstname;
            this.lastname = Lastname;
            this.age = Age;
            this.salary = Salary;
            this.id = Id;
            this.department = Department;
            this.quantity = Quantity;
        }
        #endregion

        /// <summary>
        /// вывод в консоль информации о работнике
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public string PrintWorker(Worker worker)
        {
            return $"{worker.firstname,10} {worker.lastname,13} {worker.age,13} {worker.salary,13} {worker.department,18} {worker.quantity,10}";
        }

        #region Свойства
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Firstname { get { return this.firstname; } set { this.firstname = value; } }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Lastname { get { return this.lastname; } set { this.lastname = value; } }
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public int Salary { get { return this.salary; } set { this.salary = value; } }
        /// <summary>
        /// Департамент, в котором работает сотрудник
        /// </summary>
        public string Department { get { return this.department; } set { this.department = value; } }
        /// <summary>
        /// Количество проектов, закрепленных за сотрудником
        /// </summary>
        public int Quantity { get { return this.quantity; } set { this.quantity = value; } }

        public Guid Id { get { return this.id; } set { this.id = value; } }
        #endregion        
    }
}
