using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework_08_2_
{    
    class Program
    {           
        static void Main(string[] args)
        {    
            ConsoleInputOuntut consoleInputOuntut = new ConsoleInputOuntut();

            Department department = new Department();

            Company company = new Company();

            FileInfo fileInfo = new FileInfo("_ministry.xml");
            if (fileInfo.Exists)
            {
                department = company.DeserializeDepartment("_ministry.xml");
            }
            else
            {
                department = consoleInputOuntut.DepartmentCreate();                
            }

            char key;// переменная для продолжения (прерывания цикла добавления, редактирования, удаления, сортировки)
            int i = 0;//переменная для прерывания цикла (при i=1 цикл прекращается)
            do
            {                
                switch (consoleInputOuntut.UserChoise())
                {                    
                    case 1:
                        #region Добавление департамента
                        do
                        {                            
                            consoleInputOuntut.PrintDepartment(department);

                            int idParentDep = consoleInputOuntut.GetIdParentDep();

                            if (idParentDep != 1)
                            {
                                company.tempDepartments.Clear();
                                company.GetAllDepartments(department);
                                do
                                {
                                    if (department.CheckExistDepartment(company.tempDepartments, idParentDep) == true)
                                        break;
                                    else
                                        Console.WriteLine("Департамента с таким номером ID не существует, введите ID существующего департамента");
                                    idParentDep = consoleInputOuntut.GetIdParentDep();
                                } while (department.CheckExistDepartment(company.tempDepartments, idParentDep) == false);
                            }

                            company.GetSelectedDep(department, idParentDep);

                            string name = consoleInputOuntut.GetNameDepartnent();

                            DateTime dateCreate = consoleInputOuntut.GetTimeCreate();

                            int countWorks = consoleInputOuntut.GetCountWorks();

                            company.GetAllDepartments(department);

                            List<Department> sortedById = company.tempDepartments.OrderBy(a => a.Id).ToList();

                            int id = department.GetId(sortedById);

                            department.AddDepartment(company.selectedDep, name, dateCreate, countWorks, id);

                            Console.Write("Создать (редактировать) следующий департамент н/д?"); key = Console.ReadKey(true).KeyChar;

                            Console.WriteLine();

                        } while (char.ToLower(key) == 'д');

                        #endregion
                        break;
                    case 2:
                        #region Редактирование департамента                        
                        int idDep = consoleInputOuntut.ChoiseDepartmentForEdit(department);

                        company.GetSelectedDep(department, idDep);

                        consoleInputOuntut.EditDepartment(company.selectedDep);
                        #endregion
                        break;
                    case 3:
                        #region Удаление департамента
                        idDep = consoleInputOuntut.ChoiseDepartmentForEdit(department);

                        department.RemoveDepartment(department, idDep);
                        #endregion
                        break;
                    case 4:
                        #region Добавление сотрудника

                        idDep = consoleInputOuntut.ChoiseDepartmentForAddWorker(department);

                        company.GetSelectedDep(department, idDep);

                        string nameDep = company.selectedDep.Name;

                        var tuple = consoleInputOuntut.FillFildsWorker();

                        department.AddWorkerToDep(company.selectedDep, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, nameDep, tuple.Item5);

                        #endregion
                        break;
                    case 5:
                        #region Редактирование данных сотрудника
                        idDep = consoleInputOuntut.ChoiseDepartmentForEditRemoveWorker(department);

                        company.GetSelectedDep(department, idDep);

                        consoleInputOuntut.GetWorkerByName(company.selectedDep);

                        Worker selectedWorker = consoleInputOuntut.GetWorker();

                        var tuple2 = consoleInputOuntut.GetSalaryAndQuantity();

                        department.EditWorker(selectedWorker, tuple2.Item1, tuple2.Item2);
                        #endregion
                        break;
                    case 6:
                        #region Удаление сотрудника из списка департамента
                        idDep = consoleInputOuntut.ChoiseDepartmentForEditRemoveWorker(department);

                        company.GetSelectedDep(department, idDep);

                        consoleInputOuntut.DeleteWorker(company.selectedDep);
                        #endregion
                        break;
                    case 7:
                        #region Сортировка всех сотрудников компании
                        
                        switch (consoleInputOuntut.UserChoiseSortWorker())
                        {
                            case 1:                                
                                department.PrintListOfWorker(department.SortedByAge(department));
                                break;
                            case 2:                                
                                department.PrintListOfWorker(department.SortedBySalary(department));
                                break;
                            case 3:                                
                                department.PrintListOfWorker(department.SortedByQuantity(department));
                                break;
                        }
                        #endregion
                        break;
                    case 8:
                        consoleInputOuntut.PrintOrganisation(department);
                        break;
                    case 9:
                        i = 1;
                        break;
                }
                Console.WriteLine();
            } while (i == 0);
            company.SerializeDepartment(department, "_ministry.xml");
        }
    }
}
