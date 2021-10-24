using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Homework_08_2_
{
    class Company
    {       
        public List<Department> tempDepartments = new List<Department>();
        /// <summary>
        /// получение всех департаментов структуры в отдельную коллекцию
        /// </summary>
        /// <param name="dep"></param>
        public void GetAllDepartments(Department dep)
        {
            if (dep.Id == 1)
            {
                tempDepartments.Add(dep);
            }
            if (dep.departments.Count > 0)
            {
                foreach (var item in dep.departments)
                {
                    tempDepartments.Add(item);

                    GetAllDepartments(item);
                }
            }
        }

        public Department selectedDep;

        /// <summary>
        /// Метод получения департамента по его ID
        /// </summary>
        /// <param name="department"></param>
        /// <param name="name">имя департамента</param>
        /// 
        public void GetSelectedDep(Department department, int id)
        {
            if (department.Id == id)
            {
                selectedDep = department;
                return;
            }
            if (department.departments.Count > 0)
            {
                for (int i = 0; i < department.departments.Count; i++)
                {
                    GetSelectedDep(department.departments[i], id);
                }
            }
        }

        /// <summary>
        /// Метод десериализации из xml файла
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public Department DeserializeDepartment(string Path)
        {
            Department tempDepartment = new Department();
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации

            tempDepartment = xmlSerializer.Deserialize(fStream) as Department;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempDepartment;
        }

        /// <summary>
        /// сериализация структуры в XML файл
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="Path"></param>
        public void SerializeDepartment(Department dep, string Path)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, dep);

            // Закрываем поток
            fStream.Close();
        }
    }
}
